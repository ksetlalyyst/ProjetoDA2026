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
        //Lista todos os itens de uma compra específica, incluindo o artigo associado
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

        //Adiciona um item previsto a uma compra (artigo planeado para comprar)
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

                //Marca como item previsto (não adquirido)
                item.Previsto = true;

                item.QuantidadePrevista = quantidade;

                //Regista o utilizador que criou o item
                item.CriadoPorId = utilizadorId;

                context.ItensCompra.Add(item);

                context.SaveChanges();
            }
        }

        //Adiciona um item não previsto a uma compra (artigo comprado não planeado)
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

                //Marca como não previsto
                item.Previsto = false;

                //Entra logo como adquirido (requisito 16)
                item.Adquirido = true;

                item.QuantidadeAdquirida = quantidade;
                item.PrecoUnitario = precoUnitario;
                item.Observacoes = observacoes;

                //Regista o utilizador que criou o item
                item.CriadoPorId = utilizadorId;

                context.ItensCompra.Add(item);

                context.SaveChanges();
            }
        }

        //Atualiza a quantidade adquirida e preço de um item (marca como adquirido)
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

                    //Marca como efetivamente adquirido
                    item.Adquirido = true;

                    //Regista o utilizador que alterou e a data
                    item.AlteradoPorId = utilizadorId;
                    item.DataAlteracao = DateTime.Now;

                    context.SaveChanges();
                }
            }
        }

        //Atualiza os dados de um item previsto (artigo e quantidade)
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

                    //Regista o utilizador que alterou e a data
                    item.AlteradoPorId =
                        utilizadorId;

                    item.DataAlteracao =
                        DateTime.Now;

                    context.SaveChanges();
                }
            }
        }

        //Elimina um item da compra
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
