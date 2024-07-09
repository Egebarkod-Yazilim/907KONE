using Microsoft.AspNetCore.Mvc;

namespace KONE.WebUI.Controllers
{
    public class ContractController : Controller
    {
        public IActionResult Contracts()
        {
            return View();
        }
    }
}
