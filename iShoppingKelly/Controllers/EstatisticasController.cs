using iShoppingKelly.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShoppingKelly.Controllers
{
    public class EstatisticasController
    {
        //Obtém estatísticas mensais: orçamento, total gasto e diferença por mês/ano
        public List<object> ObterEstatisticasMensais()
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Orcamentos
                    .ToList()
                    .Select(o => new
                    {
                        o.Mes,
                        o.Ano,
                        Orcamento = o.Valor,

                        //Calcula o total gasto em compras fechadas nesse mês/ano
                        TotalGasto = context.ItensCompra
                            .Where(i =>
                                i.Adquirido &&
                                i.Compra.DataFechada.HasValue &&
                                i.Compra.DataFechada.Value.Month == o.Mes &&
                                i.Compra.DataFechada.Value.Year == o.Ano)
                            .ToList()
                            .Sum(i =>
                                (i.QuantidadeAdquirida ?? 0) *
                                (i.PrecoUnitario ?? 0)),

                        //Diferença entre o orçamento e o total gasto
                        Diferenca =
                            o.Valor -
                            context.ItensCompra
                                .Where(i =>
                                    i.Adquirido &&
                                    i.Compra.DataFechada.HasValue &&
                                    i.Compra.DataFechada.Value.Month == o.Mes &&
                                    i.Compra.DataFechada.Value.Year == o.Ano)
                                .ToList()
                                .Sum(i =>
                                    (i.QuantidadeAdquirida ?? 0) *
                                    (i.PrecoUnitario ?? 0))
                    })
                    .Cast<object>()
                    .ToList();
            }
        }

        //Obtém percentagens de artigos previstos e não previstos por compra fechada
        public List<object> ObterPercentagensCompras()
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Compras
                    .Where(c => c.Fechada)
                    .ToList()
                    .Select(c => new
                    {
                        c.Nome,
                        c.DataFechada,

                        //Percentagem de artigos previstos na compra
                        PercentagemPrevistos =
                            c.Itens.Count == 0
                                ? 0
                                : Math.Round(
                                    (decimal)c.Itens.Count(i => i.Previsto)
                                    / c.Itens.Count * 100, 2),

                        //Percentagem de artigos não previstos na compra
                        PercentagemNaoPrevistos =
                            c.Itens.Count == 0
                                ? 0
                                : Math.Round(
                                    (decimal)c.Itens.Count(i => !i.Previsto)
                                    / c.Itens.Count * 100, 2)
                    })
                    .Cast<object>()
                    .ToList();
            }
        }

        //Sugere um orçamento para o próximo mês baseado na média dos gastos mensais anteriores
        public decimal SugerirOrcamentoProximoMes()
        {
            using (AppDbContext context = new AppDbContext())
            {
                //Agrupa compras fechadas por mês/ano e calcula a média dos gastos mensais
                var gastosMensais =
                    context.Compras
                    .Where(c => c.Fechada)
                    .ToList()
                    .GroupBy(c => new
                    {
                        Mes = c.DataFechada.Value.Month,
                        Ano = c.DataFechada.Value.Year
                    })
                    .Select(g => g.Sum(c =>
                        c.Itens.Sum(i =>
                            (i.QuantidadeAdquirida ?? 0) *
                            (i.PrecoUnitario ?? 0))))
                    .ToList();

                if (gastosMensais.Count == 0)
                {
                    return 0;
                }

                return gastosMensais.Average();
            }
        }

        //Sugere uma lista de compras com base na semana atual do mês (1ª a 4ª)
        //Considera compras fechadas de meses anteriores na mesma semana
        public List<object> SugerirListaCompras()
        {
            using (AppDbContext context = new AppDbContext())
            {
                DateTime hoje = DateTime.Now;
                int dia = hoje.Day;
                //Calcula a semana atual do mês (1-7 = semana 1, 8-14 = semana 2, etc.)
                int semanaAtual = (dia - 1) / 7 + 1;

                //Obtém os IDs das compras fechadas de meses anteriores na mesma semana
                var comprasSemanaAnterior = context.Compras
                    .Where(c => c.Fechada && c.DataFechada.HasValue)
                    .ToList()
                    .Where(c =>
                    {
                        DateTime df = c.DataFechada.Value;
                        int semana = (df.Day - 1) / 7 + 1;
                        return semana == semanaAtual && df.Month != hoje.Month;
                    })
                    .Select(c => c.Id)
                    .ToList();

                //Agrupa os artigos dessas compras e ordena pelos mais comprados
                return context.ItensCompra
                    .Where(i => comprasSemanaAnterior.Contains(i.CompraId) && i.Adquirido)
                    .GroupBy(i => i.Artigo.Nome)
                    .Select(g => new
                    {
                        Artigo = g.Key,

                        VezesComprado = g.Count(),

                        QuantidadeTotal =
                            g.Sum(i =>
                                i.QuantidadeAdquirida ?? 0)
                    })
                    .OrderByDescending(x => x.VezesComprado)
                    .Take(10)
                    .Cast<object>()
                    .ToList();
            }
        }

        //Exporta as compras fechadas do utilizador para um ficheiro CSV
        //Formato: NomeCompra;DataCriacao;DataFechada;NomeArtigo;ArtigoPrevisto;ArtigoNaoPrevisto;QuantidadePrevista;QuantidadeAdquirida;PrecoUnitario
        public void ExportarComprasCsv(
            string caminho,
            int utilizadorId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                //Abre stream para escrita do ficheiro
                FileStream fs =
                    new FileStream(
                        caminho,
                        FileMode.Create,
                        FileAccess.Write);

                StreamWriter sw =
                    new StreamWriter(fs);

                //Escreve o cabeçalho com os nomes das colunas
                sw.WriteLine(
                    "NomeCompra;DataCriacao;DataFechada;NomeArtigo;ArtigoPrevisto;ArtigoNaoPrevisto;QuantidadePrevista;QuantidadeAdquirida;PrecoUnitario");

                //Obtém os itens de compras fechadas do utilizador atual
                var itens = context.ItensCompra
                    .Include(i => i.Compra)
                    .Include(i => i.Artigo)
                    .Where(i => i.Compra.Fechada && i.Compra.CriadaPorId == utilizadorId)
                    .ToList();

                //Escreve cada item como uma linha CSV
                foreach (var item in itens)
                {
                    sw.WriteLine(
                        item.Compra.Nome + ";" +
                        item.Compra.DataCriacao + ";" +
                        item.Compra.DataFechada + ";" +
                        item.Artigo.Nome + ";" +
                        (item.Previsto ? "Sim" : "") + ";" +
                        (!item.Previsto ? "Sim" : "") + ";" +
                        item.QuantidadePrevista + ";" +
                        item.QuantidadeAdquirida + ";" +
                        item.PrecoUnitario);
                }

                sw.Close();
                fs.Close();
            }
        }
    }
}
