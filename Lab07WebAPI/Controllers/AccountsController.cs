using Lab07WebAPI.Models;
using Lab07WebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab07WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ITrans trans;
        public AccountsController(ITrans trans)
        {
            this.trans = trans;
        }

        [HttpGet]
        [ActionName("GetAccounts")]
        public async Task<IEnumerable<TbAccount>> GetAccounts() 
        {
            return await trans.GetAccounts();
        }
    }
}
