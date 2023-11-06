using Lab07WebAPI.Models;

namespace Lab07WebAPI.Repository
{
    public interface ITrans
    {
        Task<List<TbAccount>> GetAccounts();
        Task<List<TbTransaction>> GetTransactions();
        Task<TbTransaction> PostTransaction(TbTransaction transaction);
    }
}
