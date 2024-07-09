using KONE.DataAccess.KONE.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace KONE.WebUI.Controllers
{
    public class StatisticsVisualizationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public StatisticsVisualizationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Graphs()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ProvinceList()
        {
            var provinces = await _unitOfWork.Province.GetAllAsync();
            return Json(provinces);
        }

        [HttpGet]
        public async Task<IActionResult> Reports()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SaleReports()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> PurchaseReports()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SampleReports()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SampleReportDetail()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> WareHouseReports()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> WareHouseReportsDetail()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> OrderTrack()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> OrderTrackDetail()
        {
            return View();
        }
    }
}
