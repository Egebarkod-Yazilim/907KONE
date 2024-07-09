using KONE.DataAccess.KONE.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace KONE.WebUI.ViewComponents
{
    public class RoleListViewComponents : ViewComponent
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public RoleListViewComponents(IUnitOfWork unitOfWork)
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
