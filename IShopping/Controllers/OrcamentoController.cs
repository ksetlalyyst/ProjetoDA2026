using iShopping.Data;
using iShopping.Helpers;
using iShopping.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iShopping.Controllers
{
    public class OrcamentoController
    {
        public List<Orcamento> GetTodos()
        {
            using var db = new AppDbContext();
            return db.Orcamentos
                .Include(o => o.CriadoPor)
                .Include(o => o.AlteradoPor)
                .OrderByDescending(o => o.Ano).ThenByDescending(o => o.Mes)
                .ToList();
        }

        public Orcamento GetPorMesAno(int mes, int ano)
        {
            using var db = new AppDbContext();
            return db.Orcamentos
                .Include(o => o.CriadoPor)
                .Include(o => o.AlteradoPor)
                .FirstOrDefault(o => o.Mes == mes && o.Ano == ano);
        }

        public Orcamento GetAtual()
        {
            var hoje = DateTime.Now;
            return GetPorMesAno(hoje.Month, hoje.Year);
        }

        public (bool sucesso, string erro) CriarOuAtualizar(int mes, int ano, decimal valor)
        {
            try
            {
                using var db = new AppDbContext();
                var existente = db.Orcamentos.FirstOrDefault(o => o.Mes == mes && o.Ano == ano);
                if (existente != null)
                {
                    existente.Valor = valor;
                    existente.AlteradoPorId = Sessao.UtilizadorId;
                    existente.DataAlteracao = DateTime.Now;
                }
                else
                {
                    db.Orcamentos.Add(new Orcamento
                    {
                        Mes = mes,
                        Ano = ano,
                        Valor = valor,
                        CriadoPorId = Sessao.UtilizadorId,
                        DataCriacao = DateTime.Now
                    });
                }
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
                var o = db.Orcamentos.Find(id);
                if (o == null) return (false, "Orçamento não encontrado.");
                db.Orcamentos.Remove(o);
                db.SaveChanges();
                return (true, null);
            }
            catch (Exception ex) { return (false, ex.Message); }
        }

        public decimal SugerirProximoMes()
        {
            using var db = new AppDbContext();
            var orcamentos = db.Orcamentos.OrderByDescending(o => o.Ano).ThenByDescending(o => o.Mes).Take(6).ToList();
            if (!orcamentos.Any()) return 0;
            return Math.Round(orcamentos.Average(o => o.Valor), 2);
        }
    }
}
