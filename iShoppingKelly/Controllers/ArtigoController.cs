using iShoppingKelly.Data;
using iShoppingKelly.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace iShoppingKelly.Controllers
{
    public class ArtigoController
    {
        //Lista todos os artigos ordenados por nome, incluindo o tipo de artigo
        public List<Artigo> ListarTodos()
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Artigos
                    .Include(a => a.TipoArtigo)
                    .OrderBy(a => a.Nome)
                    .ToList();
            }
        }

        //Lista os artigos filtrados por tipo, ordenados por nome
        public List<Artigo> ListarPorTipo(int tipoArtigoId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Artigos
                    .Include(a => a.TipoArtigo)
                    .Where(a => a.TipoArtigoId == tipoArtigoId)
                    .OrderBy(a => a.Nome)
                    .ToList();
            }
        }

        //Obtém um artigo pelo seu ID
        public Artigo ObterPorId(int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Artigos
                    .Include(a => a.TipoArtigo)
                    .FirstOrDefault(a => a.Id == id);
            }
        }

        //Cria um novo artigo com nome e tipo
        public void Criar(string nome, int tipoArtigoId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                Artigo artigo = new Artigo();

                artigo.Nome = nome;
                artigo.TipoArtigoId = tipoArtigoId;

                context.Artigos.Add(artigo);

                context.SaveChanges();
            }
        }

        //Atualiza o nome e tipo de um artigo existente
        public void Atualizar(int id, string nome, int tipoArtigoId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                Artigo artigo =
                    context.Artigos
                    .FirstOrDefault(a => a.Id == id);

                if (artigo != null)
                {
                    artigo.Nome = nome;
                    artigo.TipoArtigoId = tipoArtigoId;

                    context.SaveChanges();
                }
            }
        }

        //Elimina um artigo pelo seu ID
        public void Eliminar(int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                Artigo artigo =
                    context.Artigos
                    .FirstOrDefault(a => a.Id == id);

                if (artigo != null)
                {
                    context.Artigos.Remove(artigo);

                    context.SaveChanges();
                }
            }
        }
    }
}
