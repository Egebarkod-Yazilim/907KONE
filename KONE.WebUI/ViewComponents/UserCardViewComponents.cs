using KONE.Entities.Concrete;
using KONE.Entities.Dtos.ApplicationRole;
using KONE.Entities.Dtos.ApplicationUser;
using KONE.Shared.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KONE.WebUI.ViewComponents
{
    [ViewComponent(Name = nameof(UserCardViewComponents))]
    public class UserCardViewComponents : ViewComponent
    {
        #region Fields

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        #endregion


        #region Ctor

        public UserCardViewComponents(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        #endregion


        #region Methods

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            var model = new AddOrUpdateUser
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IdentifierNumber = user.IdentifierNumber,
                KGKRegistrationNumber = user.KGKRegistrationNumber,
                SerialNumber = user.SerialNumber,
                Email = user.Email,
                BirthDate = user.BirthDate,
                PhoneNumber = user.PhoneNumber,
            };

            var userInRoles = await _userManager.GetRolesAsync(user);
            foreach (var userRole in userInRoles)
            {
                var role = await _roleManager.FindByNameAsync(userRole);
                model.SelectedRoleIds.Add(role.Id);
                model.Roles.Add(new RoleDetail
                {
                    Id = role.Id,
                    Name = role.Name
                });
            }

            return View(model);
        }

        #endregion
    }
}
