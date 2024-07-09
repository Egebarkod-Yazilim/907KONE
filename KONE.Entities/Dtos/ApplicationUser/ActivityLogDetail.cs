using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KONE.Entities.Dtos.ApplicationUser
{
    public class ActivityLogDetail
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Activity { get; set; }
        public string IpAddress { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
