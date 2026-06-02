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
        public Utilizador Login(string username, string password)
        {
            using (AppDbContext context = new AppDbContext())
            {
                Utilizador utilizador = context.Utilizadores.FirstOrDefault(u => u.Username == username);

                if (utilizador == null)
                {
                    throw new InvalidOperationException("Utilizador não existe.");
                }

                if (utilizador.PasswordHash != password)
                {
                    throw new InvalidOperationException("Password incorreta.");
                }
                return utilizador;
            }
        }

        public void Registar(string nome, string username, string password)
        {
            using (AppDbContext context = new AppDbContext())
            {
                Utilizador utilizadorExistente = context.Utilizadores
                    .FirstOrDefault(u => u.Username == username);

                if (utilizadorExistente != null)
                {
                    throw new InvalidOperationException("Username já existe.");
                }
                Utilizador utilizador = new Utilizador();
                {
                    utilizador.Nome = nome;
                    utilizador.Username = username;
                    utilizador.PasswordHash = password;

                    context.Utilizadores.Add(utilizador);
                    context.SaveChanges();
                }
            }
        }
    }
}
