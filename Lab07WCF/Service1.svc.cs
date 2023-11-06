using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Lab07WCF
{
    public class Service1 : IService1
    {
        DmawsdbContext db=new DmawsdbContext();
        public async Task<List<TbAccount>> GetTbAccounts()
        {
            return await db.TbAccounts.ToListAsync();
        }

        public async Task<TbAccount> saveAccount(TbAccount account)
        {
            await db.TbAccounts.AddAsync(account);
            await db.SaveChangesAsync();
            return account;
        }
    }
}
