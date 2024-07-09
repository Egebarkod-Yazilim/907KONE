using Microsoft.AspNetCore.Mvc;

namespace KONE.WebUI.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> OrderList()
        {
            return View();
        }

        public async Task<IActionResult> OrderShipment()
        {
            return View();
        }
    }
}
