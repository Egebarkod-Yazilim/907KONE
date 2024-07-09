using Microsoft.AspNetCore.Mvc;

namespace KONE.WebUI.ViewComponents
{
    [ViewComponent(Name = "ManufacturersByProductGraphViewComponent")]

    public class ManufacturersByProductGraphViewComponent : ViewComponent
    {
        #region Fields
        #endregion

        #region Ctor
        public ManufacturersByProductGraphViewComponent()
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
