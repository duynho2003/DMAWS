using Lab04;
using Microsoft.EntityFrameworkCore;

namespace Lab04WebAPI.DB_Helper
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options):base(options) { }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }
    }
}
