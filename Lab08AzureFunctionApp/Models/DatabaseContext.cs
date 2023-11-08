using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lab08AzureFunctionApp.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base() { }
        public DbSet<Products> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            string str = "server=LAPTOP-PH1AFEK8\\SQLEXPRESS;database=DMAWSDB;uid=sa;pwd=123";
            optionsBuilder.UseSqlServer(str);
        }
    }
}
