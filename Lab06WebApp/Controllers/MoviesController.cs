using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Lab06Lib;
using Newtonsoft.Json;
namespace Lab06WebApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly string url = "https://localhost:7014/api/Moives/";
        private readonly HttpClient httpClient = new HttpClient();
        [HttpGet]
        public IActionResult Index(string? mname)
        {
            var model = JsonConvert.DeserializeObject<IEnumerable<Movie>>(
                   httpClient.GetStringAsync(url).Result);
            if (mname == null)
            {
                return View(model);
            }
            else
            {
                var model1 = model!.Where(m => m.title!.Contains(mname!));
                return View(model1);
            }
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            try
            {
                var model = httpClient.PostAsJsonAsync<Movie>(url, movie).Result;
                if(ModelState.IsValid)
                {
                    if(model.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "fail...");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View();
        }
    }
}
