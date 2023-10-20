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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Subject subject) 
        {
            try
            {
                var model=_httpClient.PostAsJsonAsync<Subject>(url, subject).Result;
                if (model.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Subject");
                }
                else 
                {
                    ViewBag.Subject = "Failed to add subject";
                }
            }
            catch (Exception ex) 
            {
                ViewBag.Subject = ex.Message;
            }
            return View();
        }
        public IActionResult Delete(string code)
        {
            try
            {
                var model = _httpClient.DeleteAsync(url + "/" + code).Result;
                if (model.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index", "Subject");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Fail");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);

            }
            return View();
        }
    }
}
