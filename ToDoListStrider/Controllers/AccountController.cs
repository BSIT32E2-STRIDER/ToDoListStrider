using Microsoft.AspNetCore.Mvc;

namespace ToDoListStrider.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
