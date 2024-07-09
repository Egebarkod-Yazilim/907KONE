using KONE.DataAccess.KONE.Abstract;
using KONE.Entities.Concrete;
using KONE.Entities.Dtos.ApplicationUser;
using KONE.WebUI.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KONE.WebUI.ViewComponents
{
    [ViewComponent(Name = nameof(UserLoginHistoryViewComponents))]
    public class UserLoginHistoryViewComponents : ViewComponent
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        #endregion


        #region Ctor

        public UserLoginHistoryViewComponents(IUnitOfWork unitOfWork,
            UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        #endregion

        #region Methods

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            var userLoginHistoryList = await _unitOfWork.UserLoginHistory.GetAllAsync(ulh => ulh.UserId == id);
            var userLoginHistoriyDetails = userLoginHistoryList.Select(ulh => new UserLoginHistoryDetail
            {
                Id = ulh.Id,
                UserId = ulh.UserId,
                Process = "Giriş",
                IpAddress = ulh.IpAddress,
                LoginDate = ulh.LoginDate,
            });

            var model = new UserLoginHistoryModel
            {
                UserLoginHistoryDetails = userLoginHistoriyDetails.ToList()
            };

            await PrepareUserLoginHistoryForCalender(userLoginHistoryList.ToList(), model);


            return View(model);
        }

        #endregion

        #region Private Videos

        public async Task PrepareUserLoginHistoryForCalender(List<UserLoginHistory> userLoginHistories, UserLoginHistoryModel userLoginHistoryModel)
        {
            var calenderModels = new List<UserLoginHistoryCalenderModel>();


            foreach (var userLoginHistory in userLoginHistories)
            {
                var checkCalenderModel = calenderModels.Any(cm => cm.LoginDate == userLoginHistory.LoginDate.ToShortDateString());
                if (checkCalenderModel)
                {

                    calenderModels.FirstOrDefault(cm => cm.LoginDate == userLoginHistory.LoginDate.Date.ToShortDateString()).UserLoginHistoriesList.Add(new UserLoginHistoryDetail
                    {
                        Id = userLoginHistory.Id,
                        UserId = userLoginHistory.UserId,
                        Process = "Giriş",
                        IpAddress = userLoginHistory.IpAddress,
                        LoginDate = userLoginHistory.LoginDate,
                    });
                }
                else
                {
                    userLoginHistoryModel.LoginDates.Add(userLoginHistory.LoginDate.Date.ToShortDateString());
                    calenderModels.Add(new UserLoginHistoryCalenderModel
                    {
                        LoginDate = userLoginHistory.LoginDate.Date.ToShortDateString(),
                        UserLoginHistoriesList = new List<UserLoginHistoryDetail>(){new UserLoginHistoryDetail
                        {
                            Id = userLoginHistory.Id,
                            UserId = userLoginHistory.UserId,
                            Process = "Giriş",
                            IpAddress = userLoginHistory.IpAddress,
                            LoginDate = userLoginHistory.LoginDate,
                        } }
                    });
                }
            }

            userLoginHistoryModel.UserLoginHistoryCalenders = calenderModels;
        }
    }

    #endregion
}
