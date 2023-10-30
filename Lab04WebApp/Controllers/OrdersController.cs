using Lab04;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Lab04WebApp.Controllers
{
    public class OrdersController : Controller
    {

        private readonly string url = "https://localhost:7024/api/Orders";
        private readonly HttpClient httpClient=new HttpClient();
        public IActionResult Index(int? CustomerId)
        {
            var model = JsonConvert.DeserializeObject<IEnumerable<Orders>>(
                                    httpClient.GetStringAsync(url).Result);
            if (CustomerId == null)
            {
                return View(model);
            }
            else 
            {
                var model1 = model!.Where(c=>c.CustomerId.Equals(CustomerId)).ToList();
                return View(model1);
            }
        }
    }
}
