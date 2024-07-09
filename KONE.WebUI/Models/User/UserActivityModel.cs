using KONE.Entities.Concrete;
using KONE.Entities.Dtos.ApplicationUser;

namespace KONE.WebUI.Models.User
{
    public class UserActivityModel
    {
        public List<ActivityLogDetail> UserActivities { get; set; }

        public UserActivityModel()
        {
            UserActivities = new List<ActivityLogDetail>();
        }
    }
}
