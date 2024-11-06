using Jade.Barnacle.Domain.Catalog;
using Microsoft.EntityFrameworkCore;

namespace Jade.Barnacle.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
        :base(options)
    { }
    public DbSet<Item> Items {get; set; }
}

}
