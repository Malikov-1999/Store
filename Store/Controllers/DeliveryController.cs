using Microsoft.AspNetCore.Mvc;

namespace Store.Controllers
{
    public class DeliveryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
