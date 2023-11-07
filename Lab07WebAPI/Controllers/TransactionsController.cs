using Lab07WebAPI.Models;
using Lab07WebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab07WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    { 
        private readonly ITrans trans;
        public TransactionsController(ITrans trans)
        {
            this.trans = trans;
        }

        [HttpGet]
        [ActionName("GetTransaction")]
        public async Task<IEnumerable<TbTransaction>> GetTransaction()
        {
            return await trans.GetTbTransactions();
        }

        [HttpPost]
        public async Task<TbTransaction> PostTransactions(TbTransaction transaction)
        {
            return await trans.PostTransaction(transaction);
        }
    }
}
