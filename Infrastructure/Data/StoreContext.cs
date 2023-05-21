using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
        }

        //Whatever name we give the db set is what will be used to create the table
        public DbSet<Product> Products{ get; set; }
    }
}