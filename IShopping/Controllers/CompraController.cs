using iShopping.Data;
using iShopping.Helpers;
using iShopping.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace iShopping.Controllers
{
    public class CompraController
    {
        public List<Compra> GetTodas()
        {
            using var db = new AppDbContext();
            return db.Compras.Include(c => c.CriadaPor).Include(c => c.FechadaPor)
                .OrderByDescending(c => c.DataCriacao).ToList();
        }

        public List<Compra> GetAbertas()
        {
            using var db = new AppDbContext();
            return db.Compras.Include(c => c.CriadaPor)
                .Where(c => !c.Fechada)
                .OrderByDescending(c => c.DataCriacao).ToList();
        }

        public List<Compra> GetFechadas()
        {
            using var db = new AppDbContext();
            return db.Compras.Include(c => c.CriadaPor).Include(c => c.FechadaPor)
                .Where(c => c.Fechada)
                .OrderByDescending(c => c.DataFechada).ToList();
        }

        public Compra GetPorId(int id)
        {
            using var db = new AppDbContext();
            return db.Compras
                .Include(c => c.CriadaPor)
                .Include(c => c.FechadaPor)
                .Include(c => c.Itens).ThenInclude(i => i.Artigo).ThenInclude(a => a.TipoArtigo)
                .Include(c => c.Itens).ThenInclude(i => i.CriadoPor)
                .Include(c => c.Itens).ThenInclude(i => i.AlteradoPor)
                .FirstOrDefault(c => c.Id == id);
        }

        public (bool sucesso, string erro, int id) Criar(string nome)
        {
            try
            {
                using var db = new AppDbContext();
                var compra = new Compra
                {
                    Nome = nome,
                    DataCriacao = DateTime.Now,
                    CriadaPorId = Sessao.UtilizadorId
                };
                db.Compras.Add(compra);
                db.SaveChanges();
                return (true, null, compra.Id);
            }
            catch (Exception ex) { return (false, ex.Message, 0); }
        }

        public (bool sucesso, string erro) AtualizarNome(int id, string nome)
        {
            try
            {
                using var db = new AppDbContext();
                var c = db.Compras.Find(id);
                if (c == null) return (false, "Compra não encontrada.");
                if (c.Fechada) return (false, "Compra fechada não pode ser alterada.");
                c.Nome = nome;
                db.SaveChanges();
                return (true, null);
            }
            catch (Exception ex) { return (false, ex.Message); }
        }

        public (bool sucesso, string erro) Fechar(int id)
        {
            try
            {
                using var db = new AppDbContext();
                var c = db.Compras.Find(id);
                if (c == null) return (false, "Compra não encontrada.");
                if (c.Fechada) return (false, "Compra já está fechada.");
                c.Fechada = true;
                c.DataFechada = DateTime.Now;
                c.FechadaPorId = Sessao.UtilizadorId;
                db.SaveChanges();
                return (true, null);
            }
            catch (Exception ex) { return (false, ex.Message); }
        }

        public (bool sucesso, string erro) Eliminar(int id)
        {
            try
            {
                using var db = new AppDbContext();
                var c = db.Compras.Include(x => x.Itens).FirstOrDefault(x => x.Id == id);
                if (c == null) return (false, "Compra não encontrada.");
                if (c.Fechada) return (false, "Compra fechada não pode ser eliminada.");
                db.ItensCompra.RemoveRange(c.Itens);
                db.Compras.Remove(c);
                db.SaveChanges();
                return (true, null);
            }
            catch (Exception ex) { return (false, ex.Message); }
        }

        // ==================== ITENS ====================

        public (bool sucesso, string erro) AdicionarItemPrevisto(int compraId, int artigoId, decimal qtdPrevista)
        {
            try
            {
                using var db = new AppDbContext();
                var c = db.Compras.Find(compraId);
                if (c == null || c.Fechada) return (false, "Compra inválida ou fechada.");
                db.ItensCompra.Add(new ItemCompra
                {
                    CompraId = compraId,
                    ArtigoId = artigoId,
                    Previsto = true,
                    QuantidadePrevista = qtdPrevista,
                    CriadoPorId = Sessao.UtilizadorId,
                    DataCriacao = DateTime.Now
                });
                db.SaveChanges();
                return (true, null);
            }
            catch (Exception ex) { return (false, ex.Message); }
        }

        public (bool sucesso, string erro) AtualizarItemPrevisto(int itemId, int artigoId, decimal qtdPrevista)
        {
            try
            {
                using var db = new AppDbContext();
                var item = db.ItensCompra.Include(i => i.Compra).FirstOrDefault(i => i.Id == itemId);
                if (item == null || item.Compra.Fechada) return (false, "Item inválido ou compra fechada.");
                item.ArtigoId = artigoId;
                item.QuantidadePrevista = qtdPrevista;
                item.AlteradoPorId = Sessao.UtilizadorId;
                item.DataAlteracao = DateTime.Now;
                db.SaveChanges();
                return (true, null);
            }
            catch (Exception ex) { return (false, ex.Message); }
        }

        public (bool sucesso, string erro) AtualizarAquisicao(int itemId, decimal qtdAdquirida, decimal precoUnitario)
        {
            try
            {
                using var db = new AppDbContext();
                var item = db.ItensCompra.Include(i => i.Compra).FirstOrDefault(i => i.Id == itemId);
                if (item == null || item.Compra.Fechada) return (false, "Item inválido ou compra fechada.");
                item.QuantidadeAdquirida = qtdAdquirida;
                item.PrecoUnitario = precoUnitario;
                item.Adquirido = qtdAdquirida > 0;
                item.AlteradoPorId = Sessao.UtilizadorId;
                item.DataAlteracao = DateTime.Now;
                db.SaveChanges();
                return (true, null);
            }
            catch (Exception ex) { return (false, ex.Message); }
        }

        public (bool sucesso, string erro) AdicionarItemNaoPrevisto(int compraId, int artigoId, decimal qtd, decimal preco, string obs)
        {
            try
            {
                using var db = new AppDbContext();
                var c = db.Compras.Find(compraId);
                if (c == null || c.Fechada) return (false, "Compra inválida ou fechada.");
                db.ItensCompra.Add(new ItemCompra
                {
                    CompraId = compraId,
                    ArtigoId = artigoId,
                    Previsto = false,
                    QuantidadeAdquirida = qtd,
                    PrecoUnitario = preco,
                    Adquirido = true,
                    Observacoes = obs,
                    CriadoPorId = Sessao.UtilizadorId,
                    DataCriacao = DateTime.Now
                });
                db.SaveChanges();
                return (true, null);
            }
            catch (Exception ex) { return (false, ex.Message); }
        }

        public (bool sucesso, string erro) EliminarItem(int itemId)
        {
            try
            {
                using var db = new AppDbContext();
                var item = db.ItensCompra.Include(i => i.Compra).FirstOrDefault(i => i.Id == itemId);
                if (item == null) return (false, "Item não encontrado.");
                if (item.Compra.Fechada) return (false, "Compra fechada não pode ser alterada.");
                db.ItensCompra.Remove(item);
                db.SaveChanges();
                return (true, null);
            }
            catch (Exception ex) { return (false, ex.Message); }
        }

        // ==================== TOTAIS ====================

        public decimal GetTotalGastoMes(int mes, int ano)
        {
            using var db = new AppDbContext();
            var comprasFechadas = db.Compras
                .Include(c => c.Itens)
                .Where(c => c.Fechada && c.DataFechada.HasValue
                    && c.DataFechada.Value.Month == mes && c.DataFechada.Value.Year == ano)
                .ToList();

            return comprasFechadas.SelectMany(c => c.Itens)
                .Where(i => i.Adquirido && i.QuantidadeAdquirida.HasValue && i.PrecoUnitario.HasValue)
                .Sum(i => i.QuantidadeAdquirida.Value * i.PrecoUnitario.Value);
        }

        public decimal GetTotalCompra(int compraId)
        {
            using var db = new AppDbContext();
            return db.ItensCompra
                .Where(i => i.CompraId == compraId && i.Adquirido && i.QuantidadeAdquirida.HasValue && i.PrecoUnitario.HasValue)
                .Sum(i => i.QuantidadeAdquirida.Value * i.PrecoUnitario.Value);
        }

        // ==================== EXPORTAÇÃO CSV ====================

        public (bool sucesso, string erro) ExportarCSV(string caminho)
        {
            try
            {
                using var db = new AppDbContext();
                var compras = db.Compras
                    .Include(c => c.Itens).ThenInclude(i => i.Artigo)
                    .Where(c => c.Fechada && c.CriadaPorId == Sessao.UtilizadorId)
                    .ToList();

                var sb = new StringBuilder();
                sb.AppendLine("NomeCompra;DataCriacao;DataFechada;NomeArtigo;ArtigoPrevisto;ArtigoNaoPrevisto;QuantidadePrevista;QuantidadeAdquirida;PrecoUnitario");

                foreach (var compra in compras)
                {
                    foreach (var item in compra.Itens)
                    {
                        sb.AppendLine(string.Join(";",
                            compra.Nome,
                            compra.DataCriacao.ToString("yyyy-MM-dd HH:mm"),
                            compra.DataFechada?.ToString("yyyy-MM-dd HH:mm") ?? "",
                            item.Artigo?.Nome ?? "",
                            item.Previsto ? "Sim" : "Não",
                            !item.Previsto ? "Sim" : "Não",
                            item.QuantidadePrevista?.ToString("F3", CultureInfo.InvariantCulture) ?? "",
                            item.QuantidadeAdquirida?.ToString("F3", CultureInfo.InvariantCulture) ?? "",
                            item.PrecoUnitario?.ToString("F2", CultureInfo.InvariantCulture) ?? ""
                        ));
                    }
                }

                File.WriteAllText(caminho, sb.ToString(), Encoding.UTF8);
                return (true, null);
            }
            catch (Exception ex) { return (false, ex.Message); }
        }

        // ==================== ESTATÍSTICAS ====================

        public List<(int Mes, int Ano, decimal Orcamento, decimal TotalCompras, decimal Diferenca)> GetEstatisticasMensais()
        {
            using var db = new AppDbContext();
            var orcamentos = db.Orcamentos.ToList();
            var resultado = new List<(int, int, decimal, decimal, decimal)>();

            foreach (var o in orcamentos.OrderByDescending(x => x.Ano).ThenByDescending(x => x.Mes))
            {
                var total = GetTotalGastoMes(o.Mes, o.Ano);
                resultado.Add((o.Mes, o.Ano, o.Valor, total, o.Valor - total));
            }
            return resultado;
        }

        public List<(Compra Compra, int TotalItens, int Previstos, int NaoPrevistos, double PctPrev, double PctNaoPrev)> GetEstatisticasCompras()
        {
            using var db = new AppDbContext();
            var compras = db.Compras.Include(c => c.Itens).Where(c => c.Fechada).ToList();
            var resultado = new List<(Compra, int, int, int, double, double)>();

            foreach (var c in compras)
            {
                int total = c.Itens.Count;
                int prev = c.Itens.Count(i => i.Previsto);
                int naoPrev = c.Itens.Count(i => !i.Previsto);
                double pctP = total > 0 ? (double)prev / total * 100 : 0;
                double pctNP = total > 0 ? (double)naoPrev / total * 100 : 0;
                resultado.Add((c, total, prev, naoPrev, pctP, pctNP));
            }
            return resultado;
        }

        public List<string> SugerirListaCompras()
        {
            using var db = new AppDbContext();
            int semanaAtual = ((DateTime.Now.Day - 1) / 7) + 1;

            // Compras fechadas feitas na mesma semana dos meses anteriores
            var comprasAnteriores = db.Compras
                .Include(c => c.Itens).ThenInclude(i => i.Artigo)
                .Where(c => c.Fechada && c.DataCriacao.Year <= DateTime.Now.Year)
                .ToList()
                .Where(c =>
                {
                    int semana = ((c.DataCriacao.Day - 1) / 7) + 1;
                    return semana == semanaAtual &&
                           !(c.DataCriacao.Month == DateTime.Now.Month && c.DataCriacao.Year == DateTime.Now.Year);
                })
                .ToList();

            return comprasAnteriores
                .SelectMany(c => c.Itens)
                .Where(i => i.Artigo != null)
                .GroupBy(i => i.Artigo.Nome)
                .OrderByDescending(g => g.Count())
                .Take(10)
                .Select(g => $"{g.Key} (aparece em {g.Count()} compra(s))")
                .ToList();
        }
    }
}
