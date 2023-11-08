using Microsoft.AspNetCore.Mvc;
using Lab08WebApp.Models;
using Newtonsoft.Json;
using System.Net.Http;
namespace Lab08WebApp.Controllers
{
    public class ProductController : Controller
    {
        private HttpClient _httpClient=new HttpClient();
        private string urlc = "https://localhost:7102/api/Categories/";
        private string urlp = "https://localhost:7102/api/Products/";
        public IActionResult Index(int? cateId)
        {
            var model = JsonConvert.DeserializeObject<IEnumerable<Product>>(
                                    _httpClient.GetStringAsync(urlp).Result);
            if (cateId == null)
            {
                return View(model);
            }
            else 
            {
                model = model!.Where(p=>p.CategoryId.Equals(cateId)).ToList();
                return View(model);
            }
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
