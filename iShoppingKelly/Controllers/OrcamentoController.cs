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
        //Lista todos os orçamentos ordenados por ano e mês
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

        //Obtém um orçamento pelo seu ID
        public Orcamento ObterPorId(int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Orcamentos
                    .FirstOrDefault(o => o.Id == id);
            }
        }

        //Obtém o orçamento de um mês e ano específicos
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

        //Calcula o total gasto em compras fechadas num determinado mês/ano
        public decimal ObterTotalGastoNoMes(int mes, int ano)
        {
            using (AppDbContext context = new AppDbContext())
            {
                //Soma de (QuantidadeAdquirida * PrecoUnitario) dos itens adquiridos
                //em compras fechadas no mês/ano especificados
                return context.ItensCompra
                    .Where(i =>
                        i.Adquirido &&
                        i.Compra.Fechada &&
                        i.Compra.DataFechada.Month == mes &&
                        i.Compra.DataFechada.Year == ano)
                    .ToList()
                    .Sum(i =>
                        i.QuantidadeAdquirida *
                        i.PrecoUnitario);
            }
        }

        //Cria um novo orçamento mensal associado a um utilizador
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

        //Atualiza um orçamento existente e regista quem alterou
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

                    //Regista o utilizador que alterou o orçamento
                    orcamento.AlteradoPorId =
                        utilizadorId;

                    orcamento.DataAlteracao =
                        DateTime.Now;

                    context.SaveChanges();
                }
            }
        }

        //Elimina um orçamento pelo seu ID
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
