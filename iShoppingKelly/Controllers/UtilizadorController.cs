using iShoppingKelly.Data;
using iShoppingKelly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace iShoppingKelly.Controllers
{
    public class UtilizadorController
    {
        //Autentica um utilizador com base no username e password
        public Utilizador Login(string username, string password)
        {
            using (AppDbContext context = new AppDbContext())
            {
                //Procura o utilizador pelo username
                Utilizador utilizador = context.Utilizadores.FirstOrDefault(u => u.Username == username);

                if (utilizador == null)
                {
                    throw new InvalidOperationException("Utilizador não existe.");
                }

                //Compara o hash da password fornecida com o hash guardado
                if (utilizador.PasswordHash != HashPassword(password))
                {
                    throw new InvalidOperationException("Password incorreta.");
                }
                return utilizador;
            }
        }

        //Verifica se um username já existe na base de dados
        public bool UsernameExists(string username)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Utilizadores.Any(u => u.Username == username);
            }
        }

        //Cria um novo utilizador com username e password (sem nome)
        public void Criar(string username, string password)
        {
            using (AppDbContext context = new AppDbContext())
            {
                Utilizador utilizador = new Utilizador();

                utilizador.Username = username;
                utilizador.PasswordHash = HashPassword(password);

                context.Utilizadores.Add(utilizador);

                context.SaveChanges();
            }
        }

        //Lista todos os utilizadores da base de dados
        public List<Utilizador> ListarTodos()
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Utilizadores.ToList();
            }
        }

        //Obtém um utilizador pelo seu ID
        public Utilizador ObterPorId(int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Utilizadores
                    .FirstOrDefault(u => u.Id == id);
            }
        }

        //Atualiza os dados de um utilizador (recebe objeto Utilizador)
        public void Atualizar(Utilizador utilizador)
        {
            using (AppDbContext context = new AppDbContext())
            {
                Utilizador existente = context.Utilizadores
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

        //Atualiza os dados de um utilizador (recebe parâmetros individuais)
        public void Atualizar(int id, string nome, string username, string password)
        {
            using (AppDbContext context = new AppDbContext())
            {
                Utilizador existente = context.Utilizadores
                    .FirstOrDefault(u => u.Id == id);

                if (existente != null)
                {
                    //Verifica se o novo username já existe (se foi alterado)
                    if (!string.Equals(existente.Username, username, StringComparison.OrdinalIgnoreCase)
                        && context.Utilizadores.Any(u => u.Username == username))
                    {
                        throw new InvalidOperationException("Username já existe.");
                    }

                    existente.Nome = nome;
                    existente.Username = username;
                    if (!string.IsNullOrEmpty(password))
                    {
                        existente.PasswordHash = HashPassword(password);
                    }

                    context.SaveChanges();
                }
            }
        }

        //Regista um novo utilizador com nome, username e password (valida duplicados)
        public void Registar(string nome, string username, string password)
        {
            using (AppDbContext context = new AppDbContext())
            {
                //Verifica se o username já está em uso
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
                    utilizador.PasswordHash = HashPassword(password);

                    context.Utilizadores.Add(utilizador);
                    context.SaveChanges();
                }
            }
        }

        //Calcula o hash SHA-256 de uma password
        private static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        //Elimina um utilizador da base de dados pelo seu ID
        public void Eliminar(int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                Utilizador utilizador = context.Utilizadores
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
