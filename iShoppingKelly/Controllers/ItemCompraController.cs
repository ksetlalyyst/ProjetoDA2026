using iShoppingKelly.Data;
using iShoppingKelly.Models;
using iShoppingKelly.Controllers;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShoppingKelly.Controllers
{
    public class ItemCompraController
    {
        public List<ItemCompra> ListarPorCompra(int compraId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.ItensCompra
                    .Include(i => i.Artigo)
                    .Where(i => i.CompraId == compraId)
                    .ToList();
            }
        }

        public void AdicionarItemPrevisto(
            int compraId,
            int artigoId,
            int quantidade,
            int utilizadorId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                ItemCompra item = new ItemCompra();

                item.CompraId = compraId;
                item.ArtigoId = artigoId;

                item.Previsto = true;

                item.QuantidadePrevista = quantidade;

                item.CriadoPorId = utilizadorId;

                context.ItensCompra.Add(item);

                context.SaveChanges();
            }
        }

        public void AdicionarItemNaoPrevisto(
            int compraId,
            int artigoId,
            int quantidade,
            decimal precoUnitario,
            string observacoes,
            int utilizadorId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                ItemCompra item = new ItemCompra();

                item.CompraId = compraId;
                item.ArtigoId = artigoId;

                item.Previsto = false;

                item.Adquirido = true;

                item.QuantidadeAdquirida = quantidade;
                item.PrecoUnitario = precoUnitario;
                item.Observacoes = observacoes;

                item.CriadoPorId = utilizadorId;

                context.ItensCompra.Add(item);

                context.SaveChanges();
            }
        }

        public void AtualizarQuantidadeAdquirida(
            int itemId,
            int quantidade,
            decimal precoUnitario,
            int utilizadorId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                ItemCompra item =
                    context.ItensCompra
                    .FirstOrDefault(i => i.Id == itemId);

                if (item != null)
                {
                    item.QuantidadeAdquirida = quantidade;

                    item.PrecoUnitario = precoUnitario;

                    item.Adquirido = true;

                    item.AlteradoPorId = utilizadorId;
                    item.DataAlteracao = DateTime.Now;

                    context.SaveChanges();
                }
            }
        }

        public void AtualizarItemPrevisto(
            int itemId,
            int artigoId,
            int quantidadePrevista,
            int utilizadorId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                ItemCompra item =
                    context.ItensCompra
                    .FirstOrDefault(i => i.Id == itemId);

                if (item != null)
                {
                    item.ArtigoId = artigoId;

                    item.QuantidadePrevista =
                        quantidadePrevista;

                    item.AlteradoPorId =
                        utilizadorId;

                    item.DataAlteracao =
                        DateTime.Now;

                    context.SaveChanges();
                }
            }
        }

        public void Eliminar(int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                ItemCompra item =
                    context.ItensCompra
                    .FirstOrDefault(i => i.Id == id);

                if (item != null)
                {
                    context.ItensCompra.Remove(item);

                    context.SaveChanges();
                }
            }
        }
    }
}