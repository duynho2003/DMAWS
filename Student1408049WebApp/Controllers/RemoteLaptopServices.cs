using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Student1408049WebApp.Models;

namespace Student1408049WebApp.Controllers
{
    public class RemoteLaptopServices : Controller
    {
        private string url = "https://localhost:7190/api/RemoteLaptopServices/";
        private HttpClient httpClient = new HttpClient();
        public IActionResult Index()
        {
            var model = JsonConvert.DeserializeObject<IEnumerable<Laptop>>(
                                        httpClient.GetStringAsync(url).Result);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Laptop laptop)
        {
            try
            {
                var model = httpClient.PostAsJsonAsync<Laptop>(url, laptop).Result;
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
        public IActionResult Delete(int code)
        {
            var laptop = JsonConvert.DeserializeObject<IEnumerable<Laptop>>(httpClient.GetStringAsync(url).Result);
            var model = laptop!.SingleOrDefault(e => e.LaptopId == code);
            var status = httpClient.DeleteAsync(url + code).Result;
            if (status.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
