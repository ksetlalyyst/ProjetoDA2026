<<<<<<< HEAD
using iShopping.Models;
using Microsoft.EntityFrameworkCore;
=======
﻿using iShopping.Models;
using IShopping.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;
>>>>>>> origin/main

namespace iShopping.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Utilizador> Utilizadores { get; set; }
        public DbSet<TipoArtigo> TiposArtigo { get; set; }
        public DbSet<Artigo> Artigos { get; set; }
        public DbSet<Orcamento> Orcamentos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<ItemCompra> ItensCompra { get; set; }

        // -------------------------------------------------------
        // Altere os valores abaixo para corresponder à sua
        // instalação do MySQL Workbench
        // -------------------------------------------------------
        private const string Host     = "localhost";
        private const string Port     = "3306";
        private const string Database = "iShoppingDB";
        private const string User     = "root";
        private const string Password = "gay"; // coloque aqui a sua password do MySQL

<<<<<<< HEAD
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString =
                $"Server={Host};Port={Port};Database={Database};User={User};Password={Password};";

            optionsBuilder.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString)
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Utilizador - username único
            modelBuilder.Entity<Utilizador>()
                .HasIndex(u => u.Username)
                .IsUnique();

            // Orcamento - mes+ano único
            modelBuilder.Entity<Orcamento>()
                .HasIndex(o => new { o.Mes, o.Ano })
                .IsUnique();

            // Compra -> CriadaPor
            modelBuilder.Entity<Compra>()
                .HasOne(c => c.CriadaPor)
                .WithMany(u => u.ComprasCriadas)
                .HasForeignKey(c => c.CriadaPorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Compra -> FechadaPor
            modelBuilder.Entity<Compra>()
                .HasOne(c => c.FechadaPor)
                .WithMany(u => u.ComprasFechadas)
                .HasForeignKey(c => c.FechadaPorId)
                .OnDelete(DeleteBehavior.Restrict);

            // ItemCompra -> CriadoPor
            modelBuilder.Entity<ItemCompra>()
                .HasOne(i => i.CriadoPor)
                .WithMany(u => u.ItensCriados)
                .HasForeignKey(i => i.CriadoPorId)
                .OnDelete(DeleteBehavior.Restrict);

            // ItemCompra -> AlteradoPor
            modelBuilder.Entity<ItemCompra>()
                .HasOne(i => i.AlteradoPor)
                .WithMany(u => u.ItensAlterados)
                .HasForeignKey(i => i.AlteradoPorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Orcamento -> CriadoPor
            modelBuilder.Entity<Orcamento>()
                .HasOne(o => o.CriadoPor)
                .WithMany(u => u.OrcamentosCriados)
                .HasForeignKey(o => o.CriadoPorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Orcamento -> AlteradoPor
            modelBuilder.Entity<Orcamento>()
                .HasOne(o => o.AlteradoPor)
                .WithMany(u => u.OrcamentosAlterados)
                .HasForeignKey(o => o.AlteradoPorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Decimais com precisão
            modelBuilder.Entity<Orcamento>()
                .Property(o => o.Valor)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<ItemCompra>()
                .Property(i => i.QuantidadePrevista)
                .HasColumnType("decimal(18,3)");

            modelBuilder.Entity<ItemCompra>()
                .Property(i => i.QuantidadeAdquirida)
                .HasColumnType("decimal(18,3)");

            modelBuilder.Entity<ItemCompra>()
                .Property(i => i.PrecoUnitario)
                .HasColumnType("decimal(18,2)");
        }
=======
>>>>>>> origin/main
    }
}
