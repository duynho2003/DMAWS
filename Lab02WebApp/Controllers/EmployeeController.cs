using Lab02Lib;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace Lab02WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private string url = "https://localhost:7208/api/Employees/";
        private HttpClient client = new HttpClient();
        public IActionResult Index()
        {
            var model = JsonConvert.DeserializeObject<IEnumerable<Employee>>(
                client.GetStringAsync(url).Result);
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee newEmployee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = client.PostAsJsonAsync<Employee>(url, newEmployee).Result;
                    if (model.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.msg = "Fail.....";
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
        public IActionResult Delete(string id)
        {
            try
            {

                var model = client.DeleteAsync(url + id).Result;
                if (model.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.msg = "delete fail";
                }

            }
            catch (Exception ex)
            {
                ViewBag.msg = ex.Message;
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var model = JsonConvert.DeserializeObject<Employee>(client.GetStringAsync(url + id).Result);

            return View();
        }
        [HttpPost]
        public IActionResult Edit(Employee editEmployee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = client.PutAsJsonAsync<Employee>(url, editEmployee).Result;
                    if (model.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.msg = "Fail.....";
                    }
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