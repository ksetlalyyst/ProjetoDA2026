using iShopping.Data;
using iShopping.Helpers;
using iShopping.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iShopping.Controllers
{
    public class UtilizadorController
    {
        public Utilizador Login(string username, string password)
        {
            using var db = new AppDbContext();
            var user = db.Utilizadores.FirstOrDefault(u => u.Username == username);
            if (user == null) return null;
            if (!PasswordHelper.Verificar(password, user.PasswordHash)) return null;
            return user;
        }

        public (bool sucesso, string erro) Registar(string nome, string username, string password)
        {
            try
            {
                using var db = new AppDbContext();
                if (db.Utilizadores.Any(u => u.Username == username))
                    return (false, "Username já existe.");

                var user = new Utilizador
                {
                    Nome = nome,
                    Username = username,
                    PasswordHash = PasswordHelper.Hash(password)
                };
                db.Utilizadores.Add(user);
                db.SaveChanges();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public List<Utilizador> GetTodos()
        {
            using var db = new AppDbContext();
            return db.Utilizadores.OrderBy(u => u.Nome).ToList();
        }

        public Utilizador GetPorId(int id)
        {
            using var db = new AppDbContext();
            return db.Utilizadores.Find(id);
        }

        public (bool sucesso, string erro) Atualizar(int id, string nome, string username, string novaPassword)
        {
            try
            {
                using var db = new AppDbContext();
                if (db.Utilizadores.Any(u => u.Username == username && u.Id != id))
                    return (false, "Username já existe.");

                var user = db.Utilizadores.Find(id);
                if (user == null) return (false, "Utilizador não encontrado.");

                user.Nome = nome;
                user.Username = username;
                if (!string.IsNullOrWhiteSpace(novaPassword))
                    user.PasswordHash = PasswordHelper.Hash(novaPassword);

                db.SaveChanges();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool sucesso, string erro) Eliminar(int id)
        {
            try
            {
                using var db = new AppDbContext();
                var user = db.Utilizadores.Find(id);
                if (user == null) return (false, "Utilizador não encontrado.");
                db.Utilizadores.Remove(user);
                db.SaveChanges();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, "Não é possível eliminar: " + ex.Message);
            }
        }
    }
}
