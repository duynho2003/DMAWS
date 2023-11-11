using Lab09Lib;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Lab09WebApp.Controllers
{
    public class UserController : Controller
    {
        private string url = "https://localhost:7045/api/Users/";
        private HttpClient httpClient = new HttpClient();

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("uname");
            return RedirectToAction("Login");
        }
        [HttpPost]
        public IActionResult Login(string uname, string upass)
        {
            try
            {
                var user = JsonConvert.DeserializeObject<Users>(
                                        httpClient.GetStringAsync(url+uname+"/"+upass).Result);
                if (user != null)
                {
                    //session
                    HttpContext.Session.SetString("uname", uname);
                    if (user.role!.Equals("Admin"))
                    {
                        return RedirectToAction("Delete", "Shipper");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Shipper");
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
    }
}
