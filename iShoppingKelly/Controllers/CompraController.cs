using iShoppingKelly.Data;
using iShoppingKelly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShoppingKelly.Controllers
{
    public class CompraController
    {

        public List<Compra> ListarTodas()
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Compras
                    .OrderByDescending(c => c.DataCriacao)
                    .ToList();
            }
        }

        public List<Compra> ListarPorEstado(bool? fechado)
        {
            using (AppDbContext context = new AppDbContext())
            {
                if (fechado == null)
                {
                    return context.Compras
                        .OrderByDescending(c => c.DataCriacao)
                        .ToList();
                }

                return context.Compras
                    .Where(c => c.Fechada == fechado.Value)
                    .OrderByDescending(c => c.DataCriacao)
                    .ToList();
            }
        }

        public Compra ObterPorId(int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Compras
                    .FirstOrDefault(c => c.Id == id);
            }
        }

        public void Criar(string nome, int utilizadorId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                Compra compra = new Compra();

                compra.Nome = nome;
                compra.CriadaPorId = utilizadorId;

                context.Compras.Add(compra);

                context.SaveChanges();
            }
        }

        public void Atualizar(int id, string nome)
        {
            using (AppDbContext context = new AppDbContext())
            {
                Compra compra = context.Compras
                    .FirstOrDefault(c => c.Id == id);

                if (compra != null)
                {
                    compra.Nome = nome;
                    context.SaveChanges();
                }
            }
        }

        public void Fechar(int compraId, int utilizadorId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                Compra compra = context.Compras
                    .FirstOrDefault(c => c.Id == compraId);

                if (compra != null)
                {
                    compra.Fechada = true;

                    compra.DataFechada = DateTime.Now;

                    compra.FechadaPorId = utilizadorId;

                    context.SaveChanges();
                }
            }
        }

        public void Eliminar(int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                Compra compra = context.Compras
                    .FirstOrDefault(c => c.Id == id);

                if (compra != null)
                {
                    if (compra.Fechada)
                    {
                        throw new InvalidOperationException(
                            "Não é possível eliminar uma compra fechada.");
                    }

                    context.Compras.Remove(compra);

                    context.SaveChanges();
                }
            }
        }
    }
}


