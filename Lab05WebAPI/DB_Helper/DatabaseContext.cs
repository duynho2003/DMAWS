using Lab05Lib;
using Microsoft.EntityFrameworkCore;

namespace Lab05WebAPI.DB_Helper
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(): base() { }
        public virtual DbSet<Users> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            string connect = "server=LAPTOP-PH1AFEK8\\SQLEXPRESS;database=DMAWSDB;uid=sa;pwd=123;TrustServerCertificate=true";
            optionsBuilder.UseSqlServer(connect);
        }
    }
}
