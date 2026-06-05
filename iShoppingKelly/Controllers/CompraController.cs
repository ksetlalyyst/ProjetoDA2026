using iShoppingKelly.Data;
using iShoppingKelly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShoppingKelly.Controllers
{
    internal class CompraController
    {

        public void AdicionarCompra(string nome, int utilizadorId)
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

        public void EditarCompra(int id, string novoNome)
        {
            using (AppDbContext context = new AppDbContext())
            {
                Compra compra = context.Compras.FirstOrDefault(c => c.Id == id);

                if (compra == null)
                {
                    throw new InvalidOperationException("Compra não encontrada.");
                }

                compra.Nome = novoNome;
                context.SaveChanges();
            }
        }

        public void EliminarCompra(int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                Compra compra = context.Compras.FirstOrDefault(c => c.Id == id);

                if (compra == null)
                {
                    throw new InvalidOperationException("Compra não encontrada.");
                }

                if (compra.Fechada)
                {
                    throw new InvalidOperationException("Não é possível eliminar uma compra fechada.");
                }
                context.Compras.Remove(compra);
                context.SaveChanges();
            }
        }
            public void EliminarItem(int id)
            {
                using (AppDbContext context = new AppDbContext())
                {
                    ItemCompra item =context.ItensCompra.FirstOrDefault(i => i.Id == id);

                    if (item == null)
                    {
                        throw new InvalidOperationException("Item não encontrado.");
                    }

                    context.ItensCompra.Remove(item);

                    context.SaveChanges();
                }
            }
        public void FecharCompra(int compraId, int utilizadorId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                Compra compra =
                    context.Compras.FirstOrDefault(c => c.Id == compraId);

                if (compra == null)
                {
                    throw new InvalidOperationException(
                        "Compra não encontrada.");
                }

                compra.Fechada = true;
                compra.DataFechada = DateTime.Now;
                compra.FechadaPorId = utilizadorId;

                context.SaveChanges();
            }
        }
    }
}

