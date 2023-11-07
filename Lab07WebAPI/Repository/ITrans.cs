using Lab07WebAPI.Models;

namespace Lab07WebAPI.Repository
{
    public interface ITrans
    {
        Task<List<TbAccount>> GetTbAccounts();
        Task<List<TbTransaction>> GetTbTransactions();
        Task<TbTransaction> PostTransaction(TbTransaction transaction);
    }
}
