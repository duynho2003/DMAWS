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

        public IActionResult Index(string fid)
        {
            var json = httpClient.GetStringAsync(url).Result;
            var model = JsonConvert.DeserializeObject<IEnumerable<TblEmp>>(json);

            if (fid != null)
            {
                var emp = model!.SingleOrDefault(e => e.EmpId == fid);
                if (emp != null)
                {
                    model = new List<TblEmp> { emp };
                    return View(model);
                }
                else
                {
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Update(string id)
        {
            var employees = JsonConvert.DeserializeObject<IEnumerable<TblEmp>>(httpClient.GetStringAsync(url).Result);
            if (employees != null)
            {
                var model = employees.FirstOrDefault(m => m.EmpId == id);
                return View(model);

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(string id, float salary)
        {
            try
            {
                var employees = JsonConvert.DeserializeObject<IEnumerable<TblEmp>>(httpClient.GetStringAsync(url).Result);
                var model = employees!.SingleOrDefault(e => e.EmpId == id);
                if (model != null)
                {
                    model.Salary = salary;
                    await httpClient.PutAsJsonAsync(url, model);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TblEmp emp)
        {
            try
            {
                var model = httpClient.PostAsJsonAsync<TblEmp>(url, emp).Result;
                if (ModelState.IsValid)
                {
                    if (model.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ViewBag.msg = "Fail...";
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            var employees = JsonConvert.DeserializeObject<IEnumerable<TblEmp>>(httpClient.GetStringAsync(url).Result);
            var model = employees!.SingleOrDefault(e => e.EmpId == id);

            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var employees = JsonConvert.DeserializeObject<IEnumerable<TblEmp>>(httpClient.GetStringAsync(url).Result);
            var model = employees!.SingleOrDefault(e => e.EmpId == id);
            var status = httpClient.DeleteAsync(url + id).Result;
            if (status.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
