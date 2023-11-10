using Lab09Lib;
using Microsoft.EntityFrameworkCore;

namespace Lab09WebAPI.Db_Helper
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(): base(){ }
        public DbSet<Users> Users { get; set; }
        public DbSet<Shipper> Shipper { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string str = "server=LAPTOP-PH1AFEK8\\SQLEXPRESS;database=Lab09DB;uid=sa;pwd=123;TrustServerCertificate=true";
            optionsBuilder.UseSqlServer(str);
        }
    }
}
