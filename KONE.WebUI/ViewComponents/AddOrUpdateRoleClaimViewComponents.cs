using KONE.DataAccess.KONE.Abstract;
using KONE.Entities.Concrete;
using KONE.Entities.Dtos.ApplicationRole;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KONE.WebUI.ViewComponents
{
    [ViewComponent(Name = nameof(AddOrUpdateRoleClaimViewComponents))]
    public class AddOrUpdateRoleClaimViewComponents : ViewComponent
    {
        #region Fields

        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;

        #endregion


        #region Ctor

        public AddOrUpdateRoleClaimViewComponents(RoleManager<ApplicationRole> roleManager,
            IUnitOfWork unitOfWork)
        {
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
        }

        #endregion


        #region Methods

        public async Task<IViewComponentResult> InvokeAsync(int roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            if (role == null)
                return View(new AddOrUpdateRolePermission());

            var model = new AddOrUpdateRoleClaim
            {
                RoleId = role.Id,
            };

            var allPermissions = await _unitOfWork.Permission.GetAllAsync();
            model.RolePermissions = allPermissions.Select(rp => new AddOrUpdateRolePermission
            {
                PermissionId = rp.Id,
                PermissionName = rp.Name,
                PermissionNote = rp.Note,
                IsSelected = false,
            }).ToList();

            var claims = await _roleManager.GetClaimsAsync(role);
            var allClaimValues = allPermissions.Select(p => p.Id.ToString()).ToList();

            var roleClaimValues = claims.Select(c => c.Value).ToList();
            var authorizedClaims = allClaimValues.Intersect(roleClaimValues).ToList();

            foreach (var permission in model.RolePermissions)
            {
                if (authorizedClaims.Any(a => a == permission.PermissionId.ToString()))
                    permission.IsSelected = true;
            }

            return View(model);
        }

        #endregion
    }
}
