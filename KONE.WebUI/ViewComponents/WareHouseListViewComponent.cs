using Microsoft.AspNetCore.Mvc;

namespace KONE.WebUI.ViewComponents
{
    [ViewComponent(Name = "WareHouseListViewComponent")]

    public class WareHouseListViewComponent : ViewComponent
    {
        #region Fields
        #endregion

        #region Ctor
        public WareHouseListViewComponent()
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
