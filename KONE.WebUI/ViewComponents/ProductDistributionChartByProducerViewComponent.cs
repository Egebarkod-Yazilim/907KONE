using Microsoft.AspNetCore.Mvc;

namespace KONE.WebUI.ViewComponents
{
    [ViewComponent(Name = "ProductDistributionChartByProducerViewComponent")]

    public class ProductDistributionChartByProducerViewComponent : ViewComponent
    {
        #region Fields
        #endregion

        #region Ctor
        public ProductDistributionChartByProducerViewComponent()
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
