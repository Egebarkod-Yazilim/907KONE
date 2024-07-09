using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KONE.Entities.Dtos.ApplicationRole
{
    public class AddOrUpdateRoleClaim
    {
        public int RoleId { get; set; }
        public IList<AddOrUpdateRolePermission> RolePermissions { get; set; }
    }
}
