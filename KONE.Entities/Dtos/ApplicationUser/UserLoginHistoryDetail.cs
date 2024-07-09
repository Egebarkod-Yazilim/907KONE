using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KONE.Entities.Dtos.ApplicationUser
{
    public class UserLoginHistoryDetail
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Process { get; set; }
        public DateTime LoginDate { get; set; }
        public string IpAddress { get; set; }
    }
}
