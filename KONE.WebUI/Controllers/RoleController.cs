using KONE.DataAccess.KONE.Abstract;
using KONE.Entities.Concrete;
using KONE.Entities.Dtos.ApplicationRole;
using KONE.WebUI.Models.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;

namespace KONE.WebUI.Controllers
{
    public class RoleController : Controller
    {
        #region Fields

        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public RoleController(RoleManager<ApplicationRole> roleManager,
            UserManager<ApplicationUser> userManager,
            IUnitOfWork unitOfWork)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        #endregion

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetRoleList()
        {
            var roles = _roleManager.Roles.ToList();

            var roleModels = roles.Select(r => new RoleDetail
            {
                Id = r.Id,
                Name = r.Name,
                CreatedDate = r.CreatedDate,
                CreatedByName = r.CreatedByName,
                IsActive = r.IsActive
            }).ToList();

            //var jsonRoles = JsonSerializer.Serialize(roleModels);

            return Json(new { data = roleModels, draw = 1, recordsTotal = roleModels.Count(), recordsFiltered = roleModels.Count() });


            //return Json(new { data = jsonRoles, draw = 1, recordsTotal = roleModels.Count(), recordsFiltered = roleModels.Count() });
        }

        public async Task<IActionResult> AddOrUpdateRole(int? id)
        {
            if (id == null)
                return View(new AddOrUpdateRole());


            var role = await _roleManager.FindByIdAsync(id.ToString());

            var roleModel = new AddOrUpdateRole
            {
                Id = role.Id,
                Name = role.Name,
                IsActive = role.IsActive,
            };

            return View(roleModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateRole(AddOrUpdateRole addOrUpdateRole)
        {
            if (addOrUpdateRole.Id == 0)
            {
                var result = await _roleManager.CreateAsync(new ApplicationRole { Name = addOrUpdateRole.Name, IsActive = true });
                return View(addOrUpdateRole);
            }
            else
            {
                var role = await _roleManager.FindByIdAsync(addOrUpdateRole.Id.ToString());
                if (role != null)
                {
                    role.Name = addOrUpdateRole.Name;
                    role.IsActive = addOrUpdateRole.IsActive;
                    await _roleManager.UpdateAsync(role);
                    return View(addOrUpdateRole);
                }

                return View(addOrUpdateRole);
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateRoleClaim(AddOrUpdateRoleClaim addOrUpdateRoleClaim)
        {
            if (addOrUpdateRoleClaim.RoleId == 0)
            {
                return RedirectToAction(nameof(AddOrUpdateRole), new { id = addOrUpdateRoleClaim.RoleId });
            }
            else
            {
                var role = await _roleManager.FindByIdAsync(addOrUpdateRoleClaim.RoleId.ToString());
                var claims = await _roleManager.GetClaimsAsync(role);

                foreach (var claim in claims)
                {
                    await _roleManager.RemoveClaimAsync(role, claim);
                }

                var selectedClaims = addOrUpdateRoleClaim.RolePermissions.Where(rp => rp.IsSelected).ToList();
                foreach (var claim in selectedClaims)
                {
                    await _roleManager.AddClaimAsync(role, new Claim("Permission", claim.PermissionId.ToString()));
                }

                return RedirectToAction(nameof(AddOrUpdateRole), new { id = addOrUpdateRoleClaim.RoleId });
            }

        }


        [HttpGet]
        public async Task<IActionResult> AllRolePermission()
        {
            var roles = _roleManager.Roles.ToList();
            var roleModels = roles.Select(r => new RoleDetail
            {
                Id = r.Id,
                Name = r.Name
            }).ToList();


            var model = new RolePermissionModel
            {
                Roles = roleModels,
                RolePermissions = new List<AddOrUpdateAllRolePermissions>()
            };

            var permissions = await _unitOfWork.Permission.GetAllAsync();
            foreach (var permission in permissions)
            {
                var rolePermission = new AddOrUpdateAllRolePermissions
                {
                    PermissionId = permission.Id,
                    PermissionName = permission.Name,
                    PermissionNote = permission.Note,
                    PermissionRoleClaims = new List<PermissionRoleClaims>()
                };


                foreach (var role in roles)
                {
                    var claims = await _roleManager.GetClaimsAsync(role);
                    var permissionRoleClaim = new PermissionRoleClaims
                    {
                        RoleId = role.Id,
                        RoleName = role.Name,
                        IsSelected = false
                    };

                    if (claims.Any(c => c.Value == permission.Id.ToString()))
                    {
                        permissionRoleClaim.IsSelected = true;
                    }

                    rolePermission.PermissionRoleClaims.Add(permissionRoleClaim);
                }

                model.RolePermissions.Add(rolePermission);
            }


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AllRolePermission(RolePermissionModel permissionModel)
        {

            foreach (var rolePermission in permissionModel.RolePermissions)
            {
                var checkPermisison = await _unitOfWork.Permission.AnyAsync(p => p.Id == rolePermission.PermissionId);
                if (checkPermisison)
                {
                    foreach (var permissionRoleClaim in rolePermission.PermissionRoleClaims)
                    {
                        var role = await _roleManager.FindByIdAsync(permissionRoleClaim.RoleId.ToString());
                        if (role == null)
                            continue;

                        var claims = await _roleManager.GetClaimsAsync(role);
                        var roleClaim = claims.Where(c => c.Value == rolePermission.PermissionId.ToString()).ToList();

                        if (permissionRoleClaim.IsSelected && roleClaim.Count() <= 0)
                            await _roleManager.AddClaimAsync(role, new Claim("Permission", rolePermission.PermissionId.ToString()));
                        if (!permissionRoleClaim.IsSelected && roleClaim.Count() > 0)
                            await _roleManager.RemoveClaimAsync(role, roleClaim.First());

                    }
                }

            }
            return View(permissionModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            if (role == null)
                return RedirectToAction(nameof(Index));

            var usersInRole = await _userManager.GetUsersInRoleAsync(role.Name);
            if (usersInRole.Count() > 0)
                return RedirectToAction(nameof(AddOrUpdateRole), new { id = role.Id });

            var result = await _roleManager.DeleteAsync(role);

            return RedirectToAction(nameof(AddOrUpdateRole), new { id = role.Id });
        }
    }
}
