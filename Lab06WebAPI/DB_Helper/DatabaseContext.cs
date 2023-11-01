using Lab06Lib;
using Microsoft.EntityFrameworkCore;

namespace Lab06WebAPI.DB_Helper
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base(){ }
        public DbSet<Movie> Movie { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connect = "server=LAPTOP-PH1AFEK8\\SQLEXPRESS;database=DMAWSDB;uid=sa;pwd=123;TrustServerCertificate=true";
            optionsBuilder.UseSqlServer(connect);
        }
    }
}
