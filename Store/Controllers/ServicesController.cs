using Microsoft.AspNetCore.Mvc;

namespace Store.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
