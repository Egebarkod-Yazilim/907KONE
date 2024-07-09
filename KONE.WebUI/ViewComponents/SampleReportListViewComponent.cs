using Microsoft.AspNetCore.Mvc;

namespace KONE.WebUI.ViewComponents
{
    [ViewComponent(Name = "SampleReportListViewComponent")]

    public class SampleReportListViewComponent : ViewComponent
    {
        #region Fields
        #endregion

        #region Ctor
        public SampleReportListViewComponent()
        {

        }
        #endregion

        #region Methods
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
        #endregion
    }
}
