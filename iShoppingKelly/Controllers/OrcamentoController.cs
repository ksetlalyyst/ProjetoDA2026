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
        public void AdicionarOrcamento(int mes, int ano, decimal valor, int utilizadorId)
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

        public void EditarOrcamento(int id, int mes, int ano, decimal valor)
        {
            using (AppDbContext context = new AppDbContext())
            {
                Orcamento orcamento = context.Orcamentos.FirstOrDefault(o => o.Id == id);
                if (orcamento == null)
                {
                    throw new InvalidOperationException("Orçamento não encontrado");
                }

                orcamento.Mes = mes;
                orcamento.Ano = ano;
                orcamento.Valor = valor;

                orcamento.DataAlteracao = DateTime.Now;

                context.SaveChanges();
            }
        }

        public void EliminarOrcamento(int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                Orcamento orcamento = context.Orcamentos.FirstOrDefault(o => o.Id == id);

                if (orcamento == null)
                {
                    throw new InvalidOperationException("Orçamento não encontrado");
                }

                context.Orcamentos.Remove(orcamento);
                context.SaveChanges();

            }
        }
    }
}
