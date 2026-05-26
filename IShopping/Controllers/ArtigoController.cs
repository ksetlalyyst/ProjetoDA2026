using iShopping.Data;
using iShopping.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iShopping.Controllers
{
    public class ArtigoController
    {
        public List<Artigo> GetTodos()
        {
            using var db = new AppDbContext();
            return db.Artigos.Include(a => a.TipoArtigo).OrderBy(a => a.Nome).ToList();
        }

        public List<Artigo> GetPorTipo(int tipoId)
        {
            using var db = new AppDbContext();
            return db.Artigos.Include(a => a.TipoArtigo)
                .Where(a => a.TipoArtigoId == tipoId)
                .OrderBy(a => a.Nome).ToList();
        }

        public Artigo GetPorId(int id)
        {
            using var db = new AppDbContext();
            return db.Artigos.Include(a => a.TipoArtigo).FirstOrDefault(a => a.Id == id);
        }

        public (bool sucesso, string erro) Criar(string nome, int tipoArtigoId)
        {
            try
            {
                using var db = new AppDbContext();
                db.Artigos.Add(new Artigo { Nome = nome, TipoArtigoId = tipoArtigoId });
                db.SaveChanges();
                return (true, null);
            }
            catch (Exception ex) { return (false, ex.Message); }
        }

        public (bool sucesso, string erro) Atualizar(int id, string nome, int tipoArtigoId)
        {
            try
            {
                using var db = new AppDbContext();
                var a = db.Artigos.Find(id);
                if (a == null) return (false, "Artigo não encontrado.");
                a.Nome = nome;
                a.TipoArtigoId = tipoArtigoId;
                db.SaveChanges();
                return (true, null);
            }
            catch (Exception ex) { return (false, ex.Message); }
        }

        public (bool sucesso, string erro) Eliminar(int id)
        {
            try
            {
                using var db = new AppDbContext();
                var a = db.Artigos.Find(id);
                if (a == null) return (false, "Artigo não encontrado.");
                db.Artigos.Remove(a);
                db.SaveChanges();
                return (true, null);
            }
            catch (Exception ex) { return (false, "Não é possível eliminar: " + (ex.InnerException?.Message ?? ex.Message)); }
        }
    }
}
