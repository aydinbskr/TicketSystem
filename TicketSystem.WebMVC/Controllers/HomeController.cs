using Microsoft.AspNetCore.Mvc;

namespace TicketSystem.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
