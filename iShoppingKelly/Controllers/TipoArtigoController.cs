using iShoppingKelly.Data;
using iShoppingKelly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShoppingKelly.Controllers
{
    public class TipoArtigoController
    {
        //Lista todos os tipos de artigo ordenados por nome
        public List<TipoArtigo> ListarTodos()
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.TiposArtigo
                    .OrderBy(t => t.Nome)
                    .ToList();
            }
        }

        //Obtém um tipo de artigo pelo seu ID
        public TipoArtigo ObterPorId(int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.TiposArtigo
                    .FirstOrDefault(t => t.Id == id);
            }
        }

        //Cria um novo tipo de artigo
        public void Criar(string nome)
        {
            using (AppDbContext context = new AppDbContext())
            {
                TipoArtigo tipoArtigo = new TipoArtigo();

                tipoArtigo.Nome = nome;

                context.TiposArtigo.Add(tipoArtigo);

                context.SaveChanges();
            }
        }

        //Atualiza o nome de um tipo de artigo
        public void Atualizar(int id, string nome)
        {
            using (AppDbContext context = new AppDbContext())
            {
                TipoArtigo tipoArtigo = context.TiposArtigo
                    .FirstOrDefault(t => t.Id == id);

                if (tipoArtigo != null)
                {
                    tipoArtigo.Nome = nome;

                    context.SaveChanges();
                }
            }
        }

        //Elimina um tipo de artigo pelo seu ID
        public void Eliminar(int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                TipoArtigo tipoArtigo = context.TiposArtigo
                    .FirstOrDefault(t => t.Id == id);

                if (tipoArtigo != null)
                {
                    context.TiposArtigo.Remove(tipoArtigo);

                    context.SaveChanges();
                }
            }
        }
    }
}
