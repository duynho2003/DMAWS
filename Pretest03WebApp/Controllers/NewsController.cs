using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pretest03WebApp.Models;

namespace Pretest03WebApp.Controllers
{
    public class NewsController : Controller
    {
        private string url = "https://localhost:7138/api/News/";
        private HttpClient httpClient = new HttpClient();
        public IActionResult Index()
        {
            var model = JsonConvert.DeserializeObject<IEnumerable<TbNews>>(
                                        httpClient.GetStringAsync(url).Result);
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TbNews news)
        {
            try
            {
                var model = httpClient.PostAsJsonAsync<TbNews>(url, news).Result;
                if (ModelState.IsValid)
                {
                    if (model.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ViewBag.msg = "Create failed!";
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(string NewsId)
        {
            try
            {
                var model = httpClient.DeleteAsync(url + NewsId).Result;
                if (model.IsSuccessStatusCode)
                {
                    ViewBag.msg = "Delete news completed...";
                }
                else
                {
                    ViewBag.msg = "Delete failed!";
                }
            }
            catch (Exception ex)
            {
                ViewBag.msg = ex.Message;
            }
            return View();
        }
    }
}
