using Microsoft.AspNetCore.Mvc;

namespace KONE.WebUI.ViewComponents
{
    [ViewComponent(Name = "ProducerProductQualityAndAmountGraphViewComponent")]

    public class ProducerProductQualityAndAmountGraphViewComponent : ViewComponent
    {
        #region Fields
        #endregion

        #region Ctor
        public ProducerProductQualityAndAmountGraphViewComponent()
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
