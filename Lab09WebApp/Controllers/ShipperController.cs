using Lab09Lib;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Lab09WebApp.Controllers
{
    public class ShipperController : Controller
    {
        private string url = "https://localhost:7045/api/Shippers/";
        private HttpClient httpClient = new HttpClient();
        public IActionResult Index()
        {
            var model = JsonConvert.DeserializeObject<IEnumerable<Shipper>>(
                                        httpClient.GetStringAsync(url).Result);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Shipper shipper, IFormFile file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (file != null)
                    {
                        string path = Path.Combine("wwwroot/images", file.FileName);
                        var stream = new FileStream(path, FileMode.Create);
                        file.CopyToAsync(stream);
                        shipper.photo = "/images/" + file.FileName;

                        var model = httpClient.PostAsJsonAsync(url, shipper).Result;
                        if (model.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index", "Shipper");
                        }
                        else
                        {
                            ViewBag.msg = "Fail...";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.msg = ex.Message;
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var model = httpClient.DeleteAsync(url + id).Result;
                if (model.IsSuccessStatusCode)
                {
                    ViewBag.msg = "Delete shipper completed...";
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
