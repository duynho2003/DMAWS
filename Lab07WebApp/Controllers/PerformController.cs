using Lab07WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Lab07WebApp.Controllers
{
    public class PerformController : Controller
    {
        private readonly string urla = "https://localhost:7066/api/Accounts/";
        private readonly string urlt = "https://localhost:7066/api/Transactions/";
        private readonly HttpClient httpClient = new HttpClient();
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string no, int pin)
        {
            var model = JsonConvert.DeserializeObject<IEnumerable<TbAccount>>(httpClient.GetStringAsync(urla).Result);
            var account = model!.SingleOrDefault(m => m.No == no);
            if (account != null)
            {
                HttpContext.Session.SetString("accNo", account.No);
                if (account.Pincode == pin)
                {
                    return RedirectToAction("DisplayTran");
                }
                else
                {
                    ViewBag.msg = "invalid pin...";
                }
            }
            else
            {
                ViewBag.msg = "Account not found...";
            }
            return View();
        }

        public IActionResult DisplayTran()
        {
            var accountNo = HttpContext.Session.GetString("accNo");
            var model = JsonConvert.DeserializeObject<IEnumerable<TbTransaction>>(httpClient.GetStringAsync(urlt).Result);
            IEnumerable<TbTransaction> transactions = model!.Where(a => a.No!.Equals(accountNo)); //No == accountNo);
            if (transactions != null)
            {
                return View(transactions);
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult NewTransaction()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewTransaction(TbTransaction transaction, decimal balance, string TransactionType, decimal amount)
        {
            TbTransaction tran = new TbTransaction();

            if (TransactionType == "deposit")
            {
                tran.Trandate = transaction.Trandate;
                tran.Balance = balance + amount;
                tran.Deposit = amount;
                tran.Withdraw = 0;
                tran.No = transaction.No;
            }
            else if (TransactionType == "withdraw")
            {
                tran.Trandate = transaction.Trandate;
                tran.Balance = balance - amount;
                tran.Deposit = 0;
                tran.Withdraw = amount;
                tran.No = transaction.No;
            }
            var model = httpClient.PostAsJsonAsync(urlt, tran).Result;
            if (model.IsSuccessStatusCode)
            {
                return RedirectToAction("DisplayTran");
            }
            else
            {
                return NoContent();
            }
        }
    }
}
