using System.Data.Entity;

namespace Pizza.Model
{
    /// <summary>
    /// Class for work with Entity Framework
    /// </summary>
    public class PizzaContext : DbContext
    {
        public DbSet<User> Users { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<Category> Categories { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<Address> Addresses { set; get; }
    }
}