using Microsoft.AspNetCore.Mvc;

namespace KONE.WebUI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductDetail()
        {
            return View();
        }
        public IActionResult ProductUpdate()
        {
            return View();
        }
    }
}
