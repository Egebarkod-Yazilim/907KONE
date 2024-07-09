using Microsoft.AspNetCore.Mvc;

namespace KONE.WebUI.ViewComponents
{
    [ViewComponent(Name = nameof(AddOrUpdateUserViewComponents))]
    public class AddOrUpdateUserViewComponents : ViewComponent
    {
        #region Fields


        #endregion


        #region Ctor
        public AddOrUpdateUserViewComponents()
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
