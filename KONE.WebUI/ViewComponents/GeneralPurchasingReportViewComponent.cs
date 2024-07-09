using Microsoft.AspNetCore.Mvc;

namespace KONE.WebUI.ViewComponents
{

    [ViewComponent(Name = "GeneralPurchasingReportViewComponent")]

    public class GeneralPurchasingReportViewComponent : ViewComponent
    {
        #region Fields
        #endregion

        #region Ctor
        public GeneralPurchasingReportViewComponent()
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
