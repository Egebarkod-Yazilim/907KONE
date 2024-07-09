using KONE.Entities.Dtos.ApplicationUser;

namespace KONE.WebUI.Models.User
{
    public class UserLoginHistoryModel
    {
        public List<UserLoginHistoryDetail> UserLoginHistoryDetails { get; set; }

        public List<string> LoginDates { get; set; }
        public List<UserLoginHistoryCalenderModel> UserLoginHistoryCalenders { get; set; }


        public UserLoginHistoryModel()
        {
            UserLoginHistoryDetails = new List<UserLoginHistoryDetail>();
            LoginDates = new List<string>();
            UserLoginHistoryCalenders = new List<UserLoginHistoryCalenderModel>();
        }
    }


    public class UserLoginHistoryCalenderModel
    {
        public string LoginDate { get; set; }

        public List<UserLoginHistoryDetail> UserLoginHistoriesList { get; set; }
    }
}
