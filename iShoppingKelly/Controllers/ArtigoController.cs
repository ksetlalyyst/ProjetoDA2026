using iShoppingKelly.Data;
using iShoppingKelly.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iShoppingKelly.Controllers
{
    public class ArtigoController
    {
        public List<Artigo> ListarTodos()
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Artigos.Include("TipoArtigo").ToList();
            }
        }

        public List<Artigo> ListarPorTipo(int tipoArtigoId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Artigos.Include("TipoArtigo")
                    .Where(a => a.TipoArtigoId == tipoArtigoId)
                    .ToList();
            }
        }

        public List<Artigo> ListarPorNome(string nome)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Artigos.Include("TipoArtigo")
                    .Where(a => a.Nome.Contains(nome))
                    .ToList();
            }
        }

        public List<Artigo> ListarPorTipoENome(int tipoArtigoId, string nome)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Artigos.Include("TipoArtigo")
                    .Where(a => a.TipoArtigoId == tipoArtigoId && a.Nome.Contains(nome))
                    .ToList();
            }
        }

        public Artigo ObterPorId(int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Artigos.Include("TipoArtigo")
                    .FirstOrDefault(a => a.Id == id);
            }
        }
        // formartigo
        public void AdicionarArtigo(string nome, int tipoArtigoId)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new InvalidOperationException("O nome do artigo é obrigatório.");

            using (AppDbContext context = new AppDbContext())
            {
                Artigo artigo = new Artigo();

                artigo.Nome = nome;
                artigo.TipoArtigoId = tipoArtigoId;
                

                context.Artigos.Add(artigo);
                context.SaveChanges();
            }
        }

        public void EditarArtigo(int id, string novoNome, int tipoArtigoId)
        {
            
            using (AppDbContext context = new AppDbContext())
            {
                Artigo artigo = context.Artigos.FirstOrDefault(a => a.Id == id);

                if (artigo == null)
                    throw new InvalidOperationException("Artigo não encontrado.");

                artigo.Nome = novoNome;
                artigo.TipoArtigoId = tipoArtigoId;
                context.SaveChanges();
            }
        }

        public void EliminarArtigo(int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                Artigo artigo = context.Artigos.FirstOrDefault(a => a.Id == id);

                if (artigo == null)
                    throw new InvalidOperationException("Artigo não encontrado.");

                context.Artigos.Remove(artigo);
                context.SaveChanges();
            }
        }
    }
}
