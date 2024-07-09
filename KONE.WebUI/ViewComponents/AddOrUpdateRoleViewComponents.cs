using KONE.DataAccess.KONE.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace KONE.WebUI.ViewComponents
{
    [ViewComponent(Name = nameof(AddOrUpdateRoleViewComponents))]
    public class AddOrUpdateRoleViewComponents : ViewComponent
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;

        #endregion


        #region Ctor

        public AddOrUpdateRoleViewComponents(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
