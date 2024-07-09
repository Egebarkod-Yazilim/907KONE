using KONE.Entities.Dtos.ApplicationRole;

namespace KONE.WebUI.Models.Role
{
    public class RolePermissionModel
    {
        public List<RoleDetail> Roles { get; set; }
        public List<AddOrUpdateAllRolePermissions> RolePermissions { get; set; }
    }
}
