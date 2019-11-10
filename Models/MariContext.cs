using Microsoft.EntityFrameworkCore;

namespace Mari7.Models
{
    public class MariContext : DbContext
    {
        public MariContext(DbContextOptions<MariContext> options) : base(options)
        {
            
        }
        public DbSet<Currency> Currencies { get; set; }
         public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<MariUser> MariUsers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }        
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<OrderStep> OrderSteps { get; set; }
        public DbSet<StepRole> StepRoles { get; set; }
        public DbSet<MariRole> MariRoles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        
        

    }
}