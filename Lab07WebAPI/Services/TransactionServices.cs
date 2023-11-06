﻿using Lab07WebAPI.Models;
using Lab07WebAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace Lab07WebAPI.Services
{
    public class TransactionServices : ITrans
    {
        private readonly DmawsdbContext _db;
        public TransactionServices(DmawsdbContext db)
        {
            _db = db;
        }
        public async Task<List<TbAccount>> GetAccounts()
        {
            return await _db.TbAccounts.ToListAsync();
        }

        public async Task<List<TbTransaction>> GetTransactions()
        {
            return await _db.TbTransactions.ToListAsync();
        }

        public async Task<TbTransaction> PostTransaction(TbTransaction transaction)
        {
            await _db.TbTransactions.AddAsync(transaction);
            await _db.SaveChangesAsync();
            return transaction;
        }
    }
}
