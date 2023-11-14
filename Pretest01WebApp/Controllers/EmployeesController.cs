using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pretest01WebApp.Models;

namespace Pretest01WebApp.Controllers
{
    public class EmployeesController : Controller
    {
        private string url = "https://localhost:7288/api/Employees/";
        private HttpClient httpClient = new HttpClient();
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string EmpId, string pass)
        {
            try
            {
                var user = JsonConvert.DeserializeObject<TblEmp>(
                                        httpClient.GetStringAsync(url + EmpId + "/" + pass).Result);
                if (user != null)
                {
                    //session
                    HttpContext.Session.SetString("EmpId", EmpId);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Login failed. Invalid credentials.");
                }
                return View();
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "An error occurred during login.");
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("EmpId");
            return RedirectToAction("Login");
        }

        public IActionResult Index()
        {
            var model = JsonConvert.DeserializeObject<IEnumerable<TblEmp>>(
                                        httpClient.GetStringAsync(url).Result);
            return View(model);
        }

        [HttpGet]
        public IActionResult Update(string EmpId)
        {
            var model = JsonConvert.DeserializeObject<TblEmp>(
                   httpClient.GetStringAsync(url + EmpId).Result);
            return View();
        }

        [HttpPost]
        public IActionResult Update(TblEmp upEmp)
        {
            try
            {
                var model = httpClient.PostAsJsonAsync<TblEmp>(url, upEmp).Result;
                if (model.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return NoContent();
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
