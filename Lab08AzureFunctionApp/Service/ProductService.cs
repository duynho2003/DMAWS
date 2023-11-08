using Lab08AzureFunctionApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab08AzureFunctionApp.Service
{
    public class ProductService
    {
        private readonly DatabaseContext _db=new DatabaseContext();
        public async Task<List<Products>> GetProducts()
        {
            return await _db.Products.ToListAsync();
        }
    }
}
