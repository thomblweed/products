using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataStoreContext : DbContext
    {
        public DataStoreContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}