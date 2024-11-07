using Jade.Barnacle.Domain.Catalog;
using Jade.Barnacle.Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace Jade.Barnacle.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
        :base(options)
    { }
    public DbSet<Item> Items { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Rating> Ratings { get; set; }
}

}
