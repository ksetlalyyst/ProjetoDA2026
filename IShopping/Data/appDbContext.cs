using iShopping.Models;
using IShopping.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace iShopping.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ArticleType> ArticleTypes { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<PlannedItem> PlannedItems { get; set; }
        public DbSet<UnplannedItem> UnplannedItems { get; set; }

    }
}