using iShoppingKelly.Data;
using iShoppingKelly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShoppingKelly.Controllers
{
    internal class TipoArtigoController
    {
        public void AdicionarTipoArtigo(string nome) 
        {
            if(string.IsNullOrEmpty(nome))
            {
                throw new InvalidOperationException("Introduza um nome válido para o tipo de artigo.");
            }

            using (AppDbContext context = new AppDbContext())
            {
                TipoArtigo tipoExistente = context.TiposArtigo
                    .FirstOrDefault(t => t.Nome == nome);

                if (tipoExistente != null)
                {
                    throw new InvalidOperationException ("Tipo de artigo já existe.");
                }

                TipoArtigo tipo = new TipoArtigo();
                tipo.Nome = nome;
                context.TiposArtigo.Add(tipo);
                context.SaveChanges();
            }
        }

        public void RemoverTipoArtigo(int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                TipoArtigo tipo = context.TiposArtigo.FirstOrDefault(t => t.Id == id);

                if (tipo == null)
                {
                    throw new InvalidOperationException("Tipo não encontrado.");
                }
                context.TiposArtigo.Remove(tipo);
                context.SaveChanges();
            }
        }

        public void EditarTipoArtigo(int id, string novoNome)
        {
            using (AppDbContext context = new AppDbContext())
            {
                TipoArtigo tipo = context.TiposArtigo.FirstOrDefault(t => t.Id == id);

                if(tipo == null)
                {
                    throw new InvalidOperationException("Tipo não encontrado.");
                }

                tipo.Nome = novoNome;
                context.SaveChanges();
            }
        }
    }
}
