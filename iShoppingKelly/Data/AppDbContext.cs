using iShoppingKelly.Models;
using System.Data.Entity;

namespace iShoppingKelly.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base(GetConnectionString())
        {
        }

        private static string GetConnectionString()
        {
            return @"Server=(localdb)\MSSQLLocalDB;Database=iShoppingKellyDb;Trusted_Connection=True;TrustServerCertificate=True;";
        }

        public DbSet<Utilizador> Utilizadores { get; set; }
        public DbSet<TipoArtigo> TiposArtigo { get; set; }
        public DbSet<Artigo> Artigos { get; set; }
        public DbSet<Orcamento> Orcamentos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<ItemCompra> ItensCompra { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orcamento>()
                .HasRequired(o => o.CriadoPor)
                .WithMany(u => u.OrcamentosCriados)
                .HasForeignKey(o => o.CriadoPorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Orcamento>()
                .HasOptional(o => o.AlteradoPor)
                .WithMany(u => u.OrcamentosAlterados)
                .HasForeignKey(o => o.AlteradoPorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Compra>()
                .HasRequired(c => c.CriadaPor)
                .WithMany(u => u.ComprasCriadas)
                .HasForeignKey(c => c.CriadaPorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Compra>()
                .HasOptional(c => c.FechadaPor)
                .WithMany(u => u.ComprasFechadas)
                .HasForeignKey(c => c.FechadaPorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Compra>()
                .HasMany(c => c.Itens)
                .WithRequired(i => i.Compra)
                .HasForeignKey(i => i.CompraId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ItemCompra>()
                .HasRequired(i => i.Artigo)
                .WithMany(a => a.ItensCompra)
                .HasForeignKey(i => i.ArtigoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ItemCompra>()
                .HasRequired(i => i.CriadoPor)
                .WithMany(u => u.ItensCriados)
                .HasForeignKey(i => i.CriadoPorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ItemCompra>()
                .HasOptional(i => i.AlteradoPor)
                .WithMany(u => u.ItensAlterados)
                .HasForeignKey(i => i.AlteradoPorId)
                .WillCascadeOnDelete(false);
        }
    }
}
