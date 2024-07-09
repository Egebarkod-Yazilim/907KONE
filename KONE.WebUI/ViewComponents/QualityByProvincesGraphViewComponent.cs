using Microsoft.AspNetCore.Mvc;

namespace KONE.WebUI.ViewComponents
{
    [ViewComponent(Name = "QualityByProvincesGraphViewComponent")]

    public class QualityByProvincesGraphViewComponent : ViewComponent
    {
        #region Fields
        #endregion

        #region Ctor
        public QualityByProvincesGraphViewComponent()
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
