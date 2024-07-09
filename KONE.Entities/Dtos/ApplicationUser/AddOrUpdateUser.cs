using KONE.Entities.Dtos.ApplicationRole;
using KONE.Entities.Dtos.Firm;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KONE.Entities.Dtos.ApplicationUser
{
    public class AddOrUpdateUser
    {
        public AddOrUpdateUser()
        {
            Roles = new List<RoleDetail>();
            Firms = new List<FirmDetail>();
            SelectedRoleIds = new List<int>();
            SelectedFirmIds = new List<int>();
        }

        public int Id { get; set; }
        public IFormFile? Image { get; set; }
        public string UserImage { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? IdentifierNumber { get; set; }
        public string? KGKRegistrationNumber { get; set; }
        public string? SerialNumber { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string? PhoneNumber { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        public List<RoleDetail> Roles { get; set; }
        public List<int> SelectedRoleIds { get; set; }

        public List<FirmDetail> Firms { get; set; }
        public List<int> SelectedFirmIds { get; set; }
    }
}
