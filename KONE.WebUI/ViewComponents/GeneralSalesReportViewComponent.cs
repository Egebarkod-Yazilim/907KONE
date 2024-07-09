using Microsoft.AspNetCore.Mvc;

namespace KONE.WebUI.ViewComponents
{
    [ViewComponent(Name = "GeneralSalesReportViewComponent")]

    public class GeneralSalesReportViewComponent : ViewComponent
    {
        #region Fields
        #endregion

        #region Ctor
        public GeneralSalesReportViewComponent()
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
