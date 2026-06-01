using iShoppingKelly.Data;
using iShoppingKelly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShoppingKelly.Controllers
{
    internal class ArtigoController
    {
            private readonly AppDbContext _context;

            public ArtigoController(AppDbContext context)
            {
                _context = context;
            }

            public List<Artigo> ListarTodos()
            {
                return _context.Artigos.Include(a => a.TipoArtigo).OrderBy(a => a.Nome).ToList();
            }

            public List<Artigo> ListarPorTipo(int tipoId)
            {
                return _context.Artigos.Include(a => a.TipoArtigo)
                    .Where(a => a.TipoArtigoId == tipoId)
                    .OrderBy(a => a.Nome)
                    .ToList();
            }

            public Artigo ObterPorId(int id)
            {
                return _context.Artigos.Include(a => a.TipoArtigo).FirstOrDefault(a => a.Id == id);
            }

            public void Criar(string nome, int tipoId)
            {
                _context.Artigos.Add(new Artigo { Nome = nome, TipoArtigoId = tipoId });
                _context.SaveChanges();
            }

            public void Atualizar(int id, string nome, int tipoId)
            {
                var artigo = _context.Artigos.Find(id);
                if (artigo != null)
                {
                    artigo.Nome = nome;
                    artigo.TipoArtigoId = tipoId;
                    _context.SaveChanges();
                }
            }

            public void Eliminar(int id)
            {
                var artigo = _context.Artigos.Find(id);
                if (artigo != null)
                {
                    _context.Artigos.Remove(artigo);
                    _context.SaveChanges();
                }
            }
        }
    }
