using KONE.DataAccess.KONE.Abstract;
using KONE.Entities.Dtos.ApplicationUser;
using KONE.WebUI.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace KONE.WebUI.ViewComponents
{
    [ViewComponent(Name = nameof(UserActivityViewComponents))]
    public class UserActivityViewComponents : ViewComponent
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;

        #endregion


        #region Ctor

        public UserActivityViewComponents(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion


        #region Methods

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var userActvities = await _unitOfWork.ActivityLog.GetAllAsync(al => al.UserId == id);
            var userActivityDetails = userActvities.Select(al => new ActivityLogDetail
            {
                Id = al.Id,
                UserId = al.UserId,
                Activity = al.Activity,
                IpAddress = al.IpAddress,
                CreatedDate = al.CreatedDate
            }).ToList();


            return View(new UserActivityModel
            {
                UserActivities = userActivityDetails
            });
        }
        #endregion
    }
}
