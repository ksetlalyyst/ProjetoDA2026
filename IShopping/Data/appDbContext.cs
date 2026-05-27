using iShopping.Models;
using Microsoft.EntityFrameworkCore;

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

        private const string Host       = "localhost";
        private const string Port       = "3306";
        private const string NomeBD     = "iShoppingDB";
        private const string User       = "root";
        private const string Password   = "";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString =
                $"Server={Host};Port={Port};Database={NomeBD};User={User};Password={Password};";

            optionsBuilder.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString)
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Utilizador>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<Orcamento>()
                .HasIndex(o => new { o.Mes, o.Ano })
                .IsUnique();

            modelBuilder.Entity<Compra>()
                .HasOne(c => c.CriadaPor)
                .WithMany(u => u.ComprasCriadas)
                .HasForeignKey(c => c.CriadaPorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Compra>()
                .HasOne(c => c.FechadaPor)
                .WithMany(u => u.ComprasFechadas)
                .HasForeignKey(c => c.FechadaPorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ItemCompra>()
                .HasOne(i => i.CriadoPor)
                .WithMany(u => u.ItensCriados)
                .HasForeignKey(i => i.CriadoPorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ItemCompra>()
                .HasOne(i => i.AlteradoPor)
                .WithMany(u => u.ItensAlterados)
                .HasForeignKey(i => i.AlteradoPorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Orcamento>()
                .HasOne(o => o.CriadoPor)
                .WithMany(u => u.OrcamentosCriados)
                .HasForeignKey(o => o.CriadoPorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Orcamento>()
                .HasOne(o => o.AlteradoPor)
                .WithMany(u => u.OrcamentosAlterados)
                .HasForeignKey(o => o.AlteradoPorId)
                .OnDelete(DeleteBehavior.Restrict);

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
    }
}
