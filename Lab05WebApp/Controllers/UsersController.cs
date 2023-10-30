using Microsoft.AspNetCore.Mvc;

namespace Lab05WebApp.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
