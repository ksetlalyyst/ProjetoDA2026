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

        //Lista todas as compras ordenadas por data de criação (mais recente primeiro)
        public List<Compra> ListarTodas()
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Compras
                    .OrderByDescending(c => c.DataCriacao)
                    .ToList();
            }
        }

        //Lista compras filtradas por estado (abertas, fechadas ou todas se null)
        public List<Compra> ListarPorEstado(bool? fechado)
        {
            using (AppDbContext context = new AppDbContext())
            {
                //Se fechado for null, retorna todas as compras
                if (fechado == null)
                {
                    return context.Compras
                        .OrderByDescending(c => c.DataCriacao)
                        .ToList();
                }

                //Filtra consoante o estado pretendido
                return context.Compras
                    .Where(c => c.Fechada == fechado.Value)
                    .OrderByDescending(c => c.DataCriacao)
                    .ToList();
            }
        }

        //Obtém uma compra pelo seu ID
        public Compra ObterPorId(int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Compras
                    .FirstOrDefault(c => c.Id == id);
            }
        }

        //Cria uma nova compra associada a um utilizador
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

        //Atualiza o nome de uma compra existente
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

        //Fecha uma compra: regista a data de fecho e quem fechou
        public void Fechar(int compraId, int utilizadorId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                Compra compra = context.Compras
                    .FirstOrDefault(c => c.Id == compraId);

                if (compra != null)
                {
                    compra.Fechada = true;

                    //Regista o momento do fecho
                    compra.DataFechada = DateTime.Now;

                    //Associa o utilizador que fechou a compra
                    compra.FechadaPorId = utilizadorId;

                    context.SaveChanges();
                }
            }
        }

        //Elimina uma compra (apenas se não estiver fechada)
        public void Eliminar(int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                Compra compra = context.Compras
                    .FirstOrDefault(c => c.Id == id);

                if (compra != null)
                {
                    //Impede a eliminação de compras já fechadas
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
