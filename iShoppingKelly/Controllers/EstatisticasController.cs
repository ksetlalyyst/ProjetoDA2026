using iShoppingKelly.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShoppingKelly.Controllers
{
    public class EstatisticasController
    {
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
                    .Cast<object>()
                    .ToList();
            }
        }

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

        public List<object> SugerirListaCompras()
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.ItensCompra
                    .Where(i => i.Adquirido)
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
                    .Where(i => i.Compra.Fechada)
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