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
    //DTO para estatísticas mensais
    public class EstatisticaMensalDTO
    {
        public int Mes { get; set; }
        public int Ano { get; set; }
        public decimal Orcamento { get; set; }
        public decimal TotalGasto { get; set; }
        public decimal Diferenca { get; set; }
    }

    //DTO para percentagens de artigos por compra fechada
    public class PercentagemCompraDTO
    {
        public string Nome { get; set; }
        public DateTime DataFechada { get; set; }
        public decimal PercentagemPrevistos { get; set; }
        public decimal PercentagemNaoPrevistos { get; set; }
    }

    //DTO para sugestão de lista de compras
    public class SugestaoArtigoDTO
    {
        public string Artigo { get; set; }
        public int VezesComprado { get; set; }
        public decimal QuantidadeTotal { get; set; }
    }

    public class EstatisticasController
    {
        //Obtém estatísticas mensais: orçamento, total gasto e diferença por mês/ano
        public List<EstatisticaMensalDTO> ObterEstatisticasMensais()
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Orcamentos
                    .ToList()
                    .Select(o => new EstatisticaMensalDTO
                    {
                        Mes = o.Mes,
                        Ano = o.Ano,
                        Orcamento = o.Valor,

                        TotalGasto = context.ItensCompra
                            .Where(i =>
                                i.Adquirido &&
                                i.Compra.Fechada &&
                                i.Compra.DataFechada.Year == o.Ano &&
                                i.Compra.DataFechada.Month == o.Mes)
                            .ToList()
                            .Sum(i =>
                                i.QuantidadeAdquirida *
                                i.PrecoUnitario),

                        Diferenca =
                            o.Valor -
                            context.ItensCompra
                                .Where(i =>
                                    i.Adquirido &&
                                    i.Compra.Fechada &&
                                    i.Compra.DataFechada.Year == o.Ano &&
                                    i.Compra.DataFechada.Month == o.Mes)
                                .ToList()
                                .Sum(i =>
                                    i.QuantidadeAdquirida *
                                    i.PrecoUnitario)
                    })
                    .ToList();
            }
        }

        //Obtém percentagens de artigos previstos e não previstos por compra fechada
        public List<PercentagemCompraDTO> ObterPercentagensCompras()
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Compras
                    .Where(c => c.Fechada)
                    .ToList()
                    .Select(c => new PercentagemCompraDTO
                    {
                        Nome = c.Nome,
                        DataFechada = c.DataFechada,

                        PercentagemPrevistos =
                            c.Itens.Count == 0
                                ? 0
                                : Math.Round(
                                    (decimal)c.Itens.Count(i => i.Previsto)
                                    / c.Itens.Count * 100, 2),

                        PercentagemNaoPrevistos =
                            c.Itens.Count == 0
                                ? 0
                                : Math.Round(
                                    (decimal)c.Itens.Count(i => !i.Previsto)
                                    / c.Itens.Count * 100, 2)
                    })
                    .ToList();
            }
        }

        //Sugere um orçamento para o próximo mês baseado na média dos gastos mensais anteriores
        public decimal SugerirOrcamentoProximoMes()
        {
            using (AppDbContext context = new AppDbContext())
            {
                var gastosMensais =
                    context.Compras
                    .Where(c => c.Fechada)
                    .ToList()
                    .GroupBy(c => new
                    {
                        Mes = c.DataFechada.Month,
                        Ano = c.DataFechada.Year
                    })
                    .Select(g => g.Sum(c =>
                        c.Itens.Sum(i =>
                            i.QuantidadeAdquirida *
                            i.PrecoUnitario)))
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
        public List<SugestaoArtigoDTO> SugerirListaCompras()
        {
            using (AppDbContext context = new AppDbContext())
            {
                DateTime hoje = DateTime.Now;
                int dia = hoje.Day;
                int semanaAtual = (dia - 1) / 7 + 1;

                var comprasSemanaAnterior = context.Compras
                    .Where(c => c.Fechada)
                    .ToList()
                    .Where(c =>
                    {
                        DateTime df = c.DataFechada;
                        int semana = (df.Day - 1) / 7 + 1;
                        return semana == semanaAtual && df.Month != hoje.Month;
                    })
                    .Select(c => c.Id)
                    .ToList();

                return context.ItensCompra
                    .Where(i => comprasSemanaAnterior.Contains(i.CompraId) && i.Adquirido)
                    .ToList()
                    .GroupBy(i => i.Artigo.Nome)
                    .Select(g => new SugestaoArtigoDTO
                    {
                        Artigo = g.Key,
                        VezesComprado = g.Count(),
                        QuantidadeTotal = g.Sum(i => i.QuantidadeAdquirida)
                    })
                    .OrderByDescending(x => x.VezesComprado)
                    .Take(10)
                    .ToList();
            }
        }

        //Exporta as compras fechadas do utilizador para um ficheiro CSV
        public void ExportarComprasCsv(
            string caminho,
            int utilizadorId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                FileStream fs =
                    new FileStream(
                        caminho,
                        FileMode.Create,
                        FileAccess.Write);

                StreamWriter sw =
                    new StreamWriter(fs);

                sw.WriteLine(
                    "NomeCompra;DataCriacao;DataFechada;NomeArtigo;ArtigoPrevisto;ArtigoNaoPrevisto;QuantidadePrevista;QuantidadeAdquirida;PrecoUnitario");

                var itens = context.ItensCompra
                    .Include(i => i.Compra)
                    .Include(i => i.Artigo)
                    .Where(i => i.Compra.Fechada && i.Compra.CriadaPorId == utilizadorId)
                    .ToList();

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
