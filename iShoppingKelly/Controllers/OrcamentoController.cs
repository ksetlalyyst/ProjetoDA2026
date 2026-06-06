using iShoppingKelly.Data;
using iShoppingKelly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShoppingKelly.Controllers
{
    public class OrcamentoController
    {
        public List<Orcamento> ListarTodos()
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Orcamentos
                    .OrderBy(o => o.Ano)
                    .ThenBy(o => o.Mes)
                    .ToList();
            }
        }

        public Orcamento ObterPorId(int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Orcamentos
                    .FirstOrDefault(o => o.Id == id);
            }
        }

        public Orcamento ObterOrcamentoDoMes(int mes, int ano)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Orcamentos
                    .FirstOrDefault(o =>
                        o.Mes == mes &&
                        o.Ano == ano);
            }
        }

        public decimal ObterTotalGastoNoMes(int mes, int ano)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.ItensCompra
                    .Where(i =>
                        i.Adquirido &&
                        i.Compra.DataFechada.HasValue &&
                        i.Compra.DataFechada.Value.Month == mes &&
                        i.Compra.DataFechada.Value.Year == ano)
                    .ToList()
                    .Sum(i =>
                        (i.QuantidadeAdquirida ?? 0) *
                        (i.PrecoUnitario ?? 0));
            }
        }

        public void Criar(
            int mes,
            int ano,
            decimal valor,
            int utilizadorId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                Orcamento orcamento = new Orcamento();

                orcamento.Mes = mes;
                orcamento.Ano = ano;
                orcamento.Valor = valor;
                orcamento.CriadoPorId = utilizadorId;

                context.Orcamentos.Add(orcamento);

                context.SaveChanges();
            }
        }

        public void Atualizar(
            int id,
            int mes,
            int ano,
            decimal valor,
            int utilizadorId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                Orcamento orcamento =
                    context.Orcamentos
                    .FirstOrDefault(o => o.Id == id);

                if (orcamento != null)
                {
                    orcamento.Mes = mes;
                    orcamento.Ano = ano;
                    orcamento.Valor = valor;

                    orcamento.AlteradoPorId =
                        utilizadorId;

                    orcamento.DataAlteracao =
                        DateTime.Now;

                    context.SaveChanges();
                }
            }
        }

        public void Eliminar(int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                Orcamento orcamento =
                    context.Orcamentos
                    .FirstOrDefault(o => o.Id == id);

                if (orcamento != null)
                {
                    context.Orcamentos.Remove(orcamento);

                    context.SaveChanges();
                }
            }
        }
    }
}
