using Microsoft.AspNetCore.Mvc;

namespace KONE.WebUI.Controllers
{
    public class QualityControl : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GardenControlList()
        {
            return View();
        }

        public async Task<IActionResult> RawMaterialInputControlInput()
        {
            return View();
        }
        public async Task<IActionResult> RawMaterialInputControlInputList()
        {
            return View();
        }        
        public async Task<IActionResult> PackagingControl()
        {
            return View();
        }       
        public async Task<IActionResult> PackagingControlList()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> RawMaterialInputControlInputPrintBarcode(int id)
        {
            return View();
        }
    }
}
