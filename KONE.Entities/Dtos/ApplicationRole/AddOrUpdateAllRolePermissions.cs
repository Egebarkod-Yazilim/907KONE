using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KONE.Entities.Dtos.ApplicationRole
{
    public class AddOrUpdateAllRolePermissions
    {
        public int PermissionId { get; set; }
        public string PermissionName { get; set; }
        public string PermissionNote { get; set; }

        public List<PermissionRoleClaims> PermissionRoleClaims { get; set; }
    }


    public class PermissionRoleClaims
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsSelected { get; set; }
    }
}
