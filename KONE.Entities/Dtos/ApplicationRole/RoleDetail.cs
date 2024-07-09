using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KONE.Entities.Dtos.ApplicationRole
{
    public class RoleDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByName { get; set; }
        public bool IsActive { get; set; }
    }
}
