using Microsoft.AspNetCore.Mvc;

namespace KONE.WebUI.ViewComponents
{
    [ViewComponent(Name = "ProductTimeLineReportViewComponent")]

    public class ProductTimeLineReportViewComponent : ViewComponent
    {
        #region Fields
        #endregion

        #region Ctor
        public ProductTimeLineReportViewComponent()
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
