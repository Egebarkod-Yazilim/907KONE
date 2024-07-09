using KONE.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KONE.Entities.Concrete
{
    public class ActivityLog : EntityBase, IEntity
    {
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        public string Activity { get; set; }
        public string IpAddress { get; set; }
    }
}
