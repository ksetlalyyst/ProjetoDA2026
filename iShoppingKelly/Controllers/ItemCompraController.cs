using iShoppingKelly.Data;
using iShoppingKelly.Models;
using iShoppingKelly.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShoppingKelly.Controllers
{
    public class ItemCompraController
    {
            public void AdicionarItem(int compraId, int artigoId, decimal quantidadePrevista, int utilizadorId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                ItemCompra item = new ItemCompra();

                item.CompraId = compraId;
                item.ArtigoId = artigoId;
                item.QuantidadePrevista = quantidadePrevista;
                item.CriadoPorId = utilizadorId;
                

                context.ItensCompra.Add(item);

                context.SaveChanges();
            }
        }

        public void EliminarItem(int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                ItemCompra item = context.ItensCompra.FirstOrDefault(i => i.Id == id);

                if (item == null)
                {
                    throw new InvalidOperationException("ItemCompra não encontrado.");
                }

                context.ItensCompra.Remove(item);
                context.SaveChanges();
            }
        }

        public void EditarItem(int id,decimal quantidadePrevista,int utilizadorId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                ItemCompra item =context.ItensCompra.FirstOrDefault(i => i.Id == id);

                if (item == null)
                {
                    throw new InvalidOperationException("Item não encontrado.");
                }

                item.QuantidadePrevista = quantidadePrevista;
                item.AlteradoPorId = utilizadorId;
                item.DataAlteracao = DateTime.Now;

                context.SaveChanges();
            }
        }

        public void MarcarAdquirido(int itemId, decimal quantidadeAdquirida, decimal precoUnitario, int utilizadorId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                ItemCompra item = context.ItensCompra
                    .FirstOrDefault(i => i.Id == itemId);

                if (item == null)
                {
                    throw new InvalidOperationException("Item não encontrado.");
                }

                item.QuantidadeAdquirida = quantidadeAdquirida;
                item.PrecoUnitario = precoUnitario;
                item.Adquirido = true;
                item.AlteradoPorId = utilizadorId;
                item.DataAlteracao = DateTime.Now;

                context.SaveChanges();
            }
        }
    }
}
