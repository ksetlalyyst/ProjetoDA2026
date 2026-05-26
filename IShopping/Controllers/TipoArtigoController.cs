using iShopping.Data;
using iShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iShopping.Controllers
{
    public class TipoArtigoController
    {
        public List<TipoArtigo> GetTodos()
        {
            using var db = new AppDbContext();
            return db.TiposArtigo.OrderBy(t => t.Nome).ToList();
        }

        public TipoArtigo GetPorId(int id)
        {
            using var db = new AppDbContext();
            return db.TiposArtigo.Find(id);
        }

        public (bool sucesso, string erro) Criar(string nome, string descricao)
        {
            try
            {
                using var db = new AppDbContext();
                db.TiposArtigo.Add(new TipoArtigo { Nome = nome, Descricao = descricao });
                db.SaveChanges();
                return (true, null);
            }
            catch (Exception ex) { return (false, ex.Message); }
        }

        public (bool sucesso, string erro) Atualizar(int id, string nome, string descricao)
        {
            try
            {
                using var db = new AppDbContext();
                var t = db.TiposArtigo.Find(id);
                if (t == null) return (false, "Tipo não encontrado.");
                t.Nome = nome;
                t.Descricao = descricao;
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
                var t = db.TiposArtigo.Find(id);
                if (t == null) return (false, "Tipo não encontrado.");
                db.TiposArtigo.Remove(t);
                db.SaveChanges();
                return (true, null);
            }
            catch (Exception ex) { return (false, "Não é possível eliminar: " + ex.InnerException?.Message ?? ex.Message); }
        }
    }
}
