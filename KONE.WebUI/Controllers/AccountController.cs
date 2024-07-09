using Azure.Core;
using KONE.DataAccess.KONE.Abstract;
using KONE.Entities.Concrete;
using KONE.Entities.Dtos.ApplicationRole;
using KONE.Entities.Dtos.ApplicationUser;
using KONE.Entities.Dtos.Firm;
using KONE.WebUI.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KONE.WebUI.Controllers
{
    public class AccountController : Controller
    {
        #region Fields

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public AccountController(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
            IHttpContextAccessor httpContextAccessor,
            IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _contextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
        }

        #endregion

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
                return View(loginModel);

            var user = await _userManager.FindByEmailAsync(loginModel.Email);
            if (user == null)
                return View(loginModel);

            var checkPassword = await _userManager.CheckPasswordAsync(user, loginModel.Password);
            if (!checkPassword)
                return View(loginModel);

            var remoteIpAddress = _contextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

            var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);

            return RedirectToAction("FirmGuidance");
        }

        [HttpGet]
        public async Task<IActionResult> FirmGuidance()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FirmGuidance(GuidanceModel model)
        {
            return Redirect("/Home/Index");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Login", "Account");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Profile(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var roles = _roleManager.Roles.Where(r => r.IsActive).ToList();
            var firms = _unitOfWork.Firm.GetAllAsync(f => f.IsActive).GetAwaiter().GetResult();

            var model = new AddOrUpdateUser
            {
                BirthDate = DateTime.Now,
                Roles = roles.Select(r => new RoleDetail
                {
                    Id = r.Id,
                    Name = r.Name
                }).ToList(),
                Firms = firms.Select(f => new FirmDetail
                {
                    Id = f.Id,
                    Name = f.Name,
                    CreatedDate = f.CreatedDate,
                    CreatedUser = f.CreatedByName,
                    IsActive = f.IsActive
                }).ToList()

            };
            if (user != null)
            {
                model.Id = user.Id;
                model.FirstName = user.FirstName;
                model.LastName = user.LastName;
                model.IdentifierNumber = user.IdentifierNumber;
                model.KGKRegistrationNumber = user.KGKRegistrationNumber;
                model.SerialNumber = user.SerialNumber;
                model.Email = user.Email;
                model.BirthDate = user.BirthDate;
                model.PhoneNumber = user.PhoneNumber;
                model.UserImage = user.UserImage;


                var userInRoles = await _userManager.GetRolesAsync(user);
                foreach (var userRole in userInRoles)
                {
                    var role = await _roleManager.FindByNameAsync(userRole);
                    model.SelectedRoleIds.Add(role.Id);
                }

                var userFirms = await _unitOfWork.UserFirmMapping.GetAllAsync(uf => uf.UserId == user.Id);
                foreach (var userFirm in userFirms)
                {
                    var firm = await _unitOfWork.Firm.GetAsync(f => f.Id == userFirm.FirmId);
                    model.SelectedFirmIds.Add(firm.Id);
                }
            }

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Support()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Support(int id)
        {
            return View();
        }
    }


}

