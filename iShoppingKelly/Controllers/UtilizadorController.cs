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

        public bool UsernameExists(string username)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Utilizadores .Any(u => u.Username == username);
            }
        }
        public void Criar(string username, string password)
        {
            using (AppDbContext context = new AppDbContext())
            {
                Utilizador utilizador = new Utilizador();

                utilizador.Username = username;
                utilizador.PasswordHash = password;

                context.Utilizadores.Add(utilizador);

                context.SaveChanges();
            }
        }

        public List<Utilizador> ListarTodos()
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Utilizadores.ToList();
            }
        }

        public Utilizador ObterPorId(int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Utilizadores
                    .FirstOrDefault(u => u.Id == id);
            }
        }

        public void Atualizar(Utilizador utilizador)
        {
            using (AppDbContext context = new AppDbContext())
            {
                Utilizador existente =
                    context.Utilizadores
                    .FirstOrDefault(u => u.Id == utilizador.Id);

                if (existente != null)
                {
                    existente.Nome = utilizador.Nome;
                    existente.Username = utilizador.Username;
                    if (!string.IsNullOrEmpty(utilizador.PasswordHash))
                    {
                        existente.PasswordHash = utilizador.PasswordHash;
                    }

                    context.SaveChanges();
                }
            }
        }

        public void Atualizar(int id, string nome, string username, string password)
        {
            using (AppDbContext context = new AppDbContext())
            {
                Utilizador existente =
                    context.Utilizadores
                    .FirstOrDefault(u => u.Id == id);

                if (existente != null)
                {
                    existente.Nome = nome;
                    existente.Username = username;
                    if (!string.IsNullOrEmpty(password))
                    {
                        existente.PasswordHash = password;
                    }

                    context.SaveChanges();
                }
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

        public void Eliminar(int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                Utilizador utilizador =
                    context.Utilizadores
                    .FirstOrDefault(u => u.Id == id);

                if (utilizador != null)
                {
                    context.Utilizadores.Remove(utilizador);

                    context.SaveChanges();
                }
            }
        }
    }
}
