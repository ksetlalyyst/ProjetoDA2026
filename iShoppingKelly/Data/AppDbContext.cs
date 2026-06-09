using iShoppingKelly.Models;
using System.Data.Entity;

namespace iShoppingKelly.Data
{
    public class AppDbInitializer : CreateDatabaseIfNotExists<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Utilizadores ON");
            context.Utilizadores.Add(new Utilizador { Id = 0, Nome = "Sistema", Username = "system", PasswordHash = "" });
            context.SaveChanges();
            context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Utilizadores OFF");
        }
    }

    //Contexto da base de dados que gere todas as entidades do projeto
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base(GetConnectionString())
        {
            Database.SetInitializer(new AppDbInitializer());
        }

        //String de conexão à base de dados LocalDB
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

        //Configuração dos relacionamentos entre entidades (Fluent API)
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Orçamento -> Utilizador (criador): obrigatório, sem cascade delete
            modelBuilder.Entity<Orcamento>()
                .HasRequired(o => o.CriadoPor)
                .WithMany(u => u.OrcamentosCriados)
                .HasForeignKey(o => o.CriadoPorId)
                .WillCascadeOnDelete(false);

            //Orçamento -> Utilizador (alterador): obrigatório, sem cascade delete
            modelBuilder.Entity<Orcamento>()
                .HasRequired(o => o.AlteradoPor)
                .WithMany(u => u.OrcamentosAlterados)
                .HasForeignKey(o => o.AlteradoPorId)
                .WillCascadeOnDelete(false);

            //Compra -> Utilizador (criador): obrigatório, sem cascade delete
            modelBuilder.Entity<Compra>()
                .HasRequired(c => c.CriadaPor)
                .WithMany(u => u.ComprasCriadas)
                .HasForeignKey(c => c.CriadaPorId)
                .WillCascadeOnDelete(false);

            //Compra -> Utilizador (fechador): obrigatório, sem cascade delete
            modelBuilder.Entity<Compra>()
                .HasRequired(c => c.FechadaPor)
                .WithMany(u => u.ComprasFechadas)
                .HasForeignKey(c => c.FechadaPorId)
                .WillCascadeOnDelete(false);

            //Compra -> Itens: um para muitos, sem cascade delete
            modelBuilder.Entity<Compra>()
                .HasMany(c => c.Itens)
                .WithRequired(i => i.Compra)
                .HasForeignKey(i => i.CompraId)
                .WillCascadeOnDelete(false);

            //ItemCompra -> Artigo: obrigatório, sem cascade delete
            modelBuilder.Entity<ItemCompra>()
                .HasRequired(i => i.Artigo)
                .WithMany(a => a.ItensCompra)
                .HasForeignKey(i => i.ArtigoId)
                .WillCascadeOnDelete(false);

            //ItemCompra -> Utilizador (criador): obrigatório, sem cascade delete
            modelBuilder.Entity<ItemCompra>()
                .HasRequired(i => i.CriadoPor)
                .WithMany(u => u.ItensCriados)
                .HasForeignKey(i => i.CriadoPorId)
                .WillCascadeOnDelete(false);

            //ItemCompra -> Utilizador (alterador): obrigatório, sem cascade delete
            modelBuilder.Entity<ItemCompra>()
                .HasRequired(i => i.AlteradoPor)
                .WithMany(u => u.ItensAlterados)
                .HasForeignKey(i => i.AlteradoPorId)
                .WillCascadeOnDelete(false);
        }
    }
}
