using iShoppingKelly.Data;
using iShoppingKelly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShoppingKelly.Controllers
{
    public class UtilizadorController
    {
        private readonly AppDbContext Context;
        public UtilizadorController(AppDbContext context)
        {
                        Context = context;
        }

        public Utilizador Login(string username, string password)
        {
            return Context.Utilizadores
                .FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public bool UsernameExists(string username)
        {
            return Context.Utilizadores.Any(u => u.Username == username);
        }

        public void Criar(string username, string password)
        {
            var utilizador = new Utilizador
            {
                Username = username,
                Password = password
            };
            Context.Utilizadores.Add(utilizador);
            Context.SaveChanges();
        }

        public List<Utilizador> ListarTodos()
        {
            return Context.Utilizadores.OrderBy(u => u.Username).ToList();
        }

        public Utilizador ObterPorId(int id)
        {
            return Context.Utilizadores.Find(id);
        }

        public void Atualizar(int id, string username, string password)
        {
            var utilizador = Context.Utilizadores.Find(id);
            if (utilizador != null)
            {
                utilizador.Username = username;
                utilizador.Password = password;
                Context.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            var utilizador = Context.Utilizadores.Find(id);
            if (utilizador != null)
            {
                Context.Utilizadores.Remove(utilizador);
                Context.SaveChanges();
            }
        }
    }
}
