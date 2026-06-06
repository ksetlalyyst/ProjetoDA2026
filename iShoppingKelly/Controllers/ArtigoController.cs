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

            public Artigo ObterPorId(int id)
            {
                using (AppDbContext context = new AppDbContext())
                {
                    return context.Artigos
                        .Include(a => a.TipoArtigo)
                        .FirstOrDefault(a => a.Id == id);
                }
            }

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
