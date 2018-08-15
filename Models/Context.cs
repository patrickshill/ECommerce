using Microsoft.EntityFrameworkCore;
 
namespace ECommerce.Models
{
    public class ModelsContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public ModelsContext(DbContextOptions<ModelsContext> options) : base(options) { }

            public DbSet<Product> products {get;set;}
            public DbSet<Customer> customers {get;set;}
            public DbSet<Order> orders {get;set;}
        // public DbSet<Product> products {get;set;}
        // public DbSet<Category> categories {get;set;}
        // public DbSet<Relation> relations {get;set;}
    }
}