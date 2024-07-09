using Microsoft.AspNetCore.Mvc;

namespace KONE.WebUI.Controllers
{
    public class ShipmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
