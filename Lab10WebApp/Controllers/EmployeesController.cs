using Lab10WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Lab10WebApp.Controllers
{
    public class EmployeesController : Controller
    {
        private string url = "https://localhost:7285/api/Employees/";
        private HttpClient httpClient = new HttpClient();

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("code");
            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult Login(string code, string pass)
        {
            try
            {
                var user = JsonConvert.DeserializeObject<Employee>(
                                        httpClient.GetStringAsync(url + code + "/" + pass).Result);
                if (user != null)
                {
                    //session
                    HttpContext.Session.SetString("code", code);
                    if (user.Roles!.Equals("Admins"))
                    {
                        return RedirectToAction("Delete");
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Login fail...");
                }
                return View();
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Login fail...");
            }
            return View();
        }

        public IActionResult Index()
        {
            var model = JsonConvert.DeserializeObject<IEnumerable<Employee>>(
                                        httpClient.GetStringAsync(url).Result);
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(string code)
        {
            try
            {
                var model = httpClient.DeleteAsync(url + code).Result;
                if (model.IsSuccessStatusCode)
                {
                    ViewBag.msg = "Delete employee completed...";
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
