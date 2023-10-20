using Microsoft.AspNetCore.Mvc;
using Lab01Lib;
using System.Net.Http;
using Newtonsoft.Json;

namespace Lab01WebApp.Controllers
{
    public class SubjectController : Controller
    {
        private HttpClient _httpClient = new HttpClient();
        private string url = "https://localhost:7164/api/Subject";
        public IActionResult Index()
        {
            var model=JsonConvert.DeserializeObject<IEnumerable<Subject>>(
                                    _httpClient.GetStringAsync(url).Result);
            return View(model);
        }
    }
}
