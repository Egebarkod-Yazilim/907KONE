using KONE.Entities.Dtos.ApplicationRole;
using KONE.Entities.Dtos.Firm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KONE.Entities.Dtos.ApplicationUser
{
    public class UserDetail
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? IdentifierNumber { get; set; }
        public string? KGKRegistrationNumber { get; set; }
        public string? SerialNumber { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string? PhoneNumber { get; set; }
        public List<RoleDetail> Roles { get; set; }
        public List<FirmDetail> Firms { get; set; }


        public UserDetail()
        {
            Roles = new List<RoleDetail>();
            Firms = new List<FirmDetail>();
        }
    }
}
