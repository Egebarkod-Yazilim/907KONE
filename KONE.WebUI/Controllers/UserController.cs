using KONE.DataAccess.KONE.Abstract;
using KONE.Entities.Concrete;
using KONE.Entities.Dtos.ApplicationRole;
using KONE.Entities.Dtos.ApplicationUser;
using KONE.Entities.Dtos.Firm;
using KONE.Shared.Utilities.Results.ComplexTypes;
using KONE.WebUI.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace KONE.WebUI.Controllers
{
    public class UserController : Controller
    {

        #region Fields

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        #endregion

        #region Ctor

        public UserController(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IUnitOfWork unitOfWork,
            IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        #endregion

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetUserList()
        {
            var users = _userManager.Users.ToList();

            List<UserDetail> userModels = new List<UserDetail>();

            foreach (var user in users)
            {
                var userDetail = new UserDetail
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    IdentifierNumber = user.IdentifierNumber,
                    KGKRegistrationNumber = user.KGKRegistrationNumber,
                    SerialNumber = user.SerialNumber,
                    Email = user.Email,
                    BirthDate = user.BirthDate,
                    PhoneNumber = user.PhoneNumber
                };


                var userRoles = await _userManager.GetRolesAsync(user);
                foreach (var userRole in userRoles)
                {
                    var role = await _roleManager.FindByNameAsync(userRole);
                    userDetail.Roles.Add(new RoleDetail
                    {
                        Id = role.Id,
                        Name = role.Name,
                    });
                }

                var userFirms = await _unitOfWork.UserFirmMapping.GetAllAsync(uf => uf.UserId == user.Id);
                foreach(var userFirm in userFirms)
                {
                    var firm = await _unitOfWork.Firm.GetAsync(f => f.Id == userFirm.FirmId);
                    userDetail.Firms.Add(new FirmDetail
                    {
                        Id = firm.Id,
                        Name = firm.Name,
                    });
                }

                userModels.Add(userDetail);
            }

            return Json(new { data = userModels, draw = 1, recordsTotal = userModels.Count(), recordsFiltered = userModels.Count() });
        }

        [HttpGet]
        public async Task<IActionResult> AddOrUpdateUser(int? id)
        {
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

            if (id == null)
            {
                return View(model);
            }
            else
            {
                var user = await _userManager.FindByIdAsync(id.ToString());
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
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateUser(AddOrUpdateUser addOrUpdateUser)
        {
            var roles = _roleManager.Roles.ToList();
            addOrUpdateUser.Roles = roles.Select(r => new RoleDetail
            {
                Id = r.Id,
                Name = r.Name
            }).ToList();

            var firms = await _unitOfWork.Firm.GetAllAsync(f => f.IsActive);
            addOrUpdateUser.Firms = firms.Select(r => new FirmDetail
            {
                Id = r.Id,
                Name = r.Name
            }).ToList();

            string imageUrl = addOrUpdateUser.UserImage;

            if (addOrUpdateUser.Image != null)
            {
                var basePath = Path.Combine(_webHostEnvironment.WebRootPath + "\\Uploads\\UserFiles\\");
                bool basePathExist = System.IO.Directory.Exists(basePath);
                if (!basePathExist) Directory.CreateDirectory(basePath);

                var fileName = Guid.NewGuid();
                var filePath = Path.Combine(basePath + fileName);
                var extension = Path.GetExtension(addOrUpdateUser.Image.FileName);

                imageUrl = new UriBuilder
                {
                    Scheme = Request.Scheme,
                    Host = Request.Host.Host,
                    Port = Request.Host.Port ?? -1,
                    Path = "\\Uploads\\UserFiles\\" + fileName + extension
                }.ToString();

                if (!System.IO.File.Exists(filePath))
                {
                    using (var fileStream = new FileStream(filePath + extension, FileMode.Create))
                    {
                        await addOrUpdateUser.Image.CopyToAsync(fileStream);
                    }
                }
            }
           

            if (addOrUpdateUser.Id == 0)
            {
                var user = new ApplicationUser
                {
                    FirstName = addOrUpdateUser.FirstName,
                    LastName = addOrUpdateUser.LastName,
                    UserName = addOrUpdateUser.Email,
                    IdentifierNumber = addOrUpdateUser.IdentifierNumber,
                    KGKRegistrationNumber = addOrUpdateUser.KGKRegistrationNumber,
                    SerialNumber = addOrUpdateUser.SerialNumber,
                    Email = addOrUpdateUser.Email,
                    BirthDate = addOrUpdateUser.BirthDate,
                    PhoneNumber = addOrUpdateUser.PhoneNumber,
                    UserImage = imageUrl
                };

                var userResult = await _userManager.CreateAsync(user, addOrUpdateUser.Password);
                if (userResult.Succeeded)
                {
                    foreach (var selectedRole in addOrUpdateUser.SelectedRoleIds)
                    {
                        var role = await _roleManager.FindByIdAsync(selectedRole.ToString());
                        if (role != null)
                            await _userManager.AddToRoleAsync(user, role.Name);
                    }

                    foreach (var selectedFirmId in addOrUpdateUser.SelectedFirmIds)
                    {
                        var firm = await _unitOfWork.Firm.GetAsync(f => f.Id == selectedFirmId);
                        if (firm != null)
                        {
                            await _unitOfWork.UserFirmMapping.AddAsync(new UserFirmMapping
                            {
                                UserId = user.Id,
                                FirmId = firm.Id,
                                CreatedDate = DateTime.Now,
                                CreatedByName = "Admin",
                                ModifiedDate = DateTime.Now,
                                ModifiedByName = "Admin",
                                IsActive = true,
                                IsDeleted = false
                            });
                            await _unitOfWork.SaveAsync();
                        }
                          
                    }
                }

                return View(addOrUpdateUser);
            }
            else
            {
                var checkUser = await _userManager.FindByIdAsync(addOrUpdateUser.Id.ToString());
                if (checkUser != null)
                {
                    checkUser.Id = addOrUpdateUser.Id;
                    checkUser.FirstName = addOrUpdateUser.FirstName;
                    checkUser.LastName = addOrUpdateUser.LastName;
                    checkUser.UserName = addOrUpdateUser.Email;
                    checkUser.IdentifierNumber = addOrUpdateUser.IdentifierNumber;
                    checkUser.KGKRegistrationNumber = addOrUpdateUser.KGKRegistrationNumber;
                    checkUser.SerialNumber = addOrUpdateUser.SerialNumber;
                    checkUser.Email = addOrUpdateUser.Email;
                    checkUser.BirthDate = addOrUpdateUser.BirthDate;
                    checkUser.PhoneNumber = addOrUpdateUser.PhoneNumber;
                    checkUser.UserImage = imageUrl;

                    var userResult = await _userManager.UpdateAsync(checkUser);
                    if (userResult.Succeeded)
                    {
                        var userRoles = await _userManager.GetRolesAsync(checkUser);
                        foreach (var userRole in userRoles)
                        {
                            var checkRole = await _userManager.RemoveFromRoleAsync(checkUser, userRole);
                        }

                        foreach (var selectedRoleId in addOrUpdateUser.SelectedRoleIds)
                        {
                            var selectedRole = await _roleManager.FindByIdAsync(selectedRoleId.ToString());
                            await _userManager.AddToRoleAsync(checkUser, selectedRole.Name);
                        }

                        var userFirms = await _unitOfWork.UserFirmMapping.GetAllAsync(uf => uf.UserId == addOrUpdateUser.Id);
                        await _unitOfWork.UserFirmMapping.DeleteAllAsync(userFirms.ToList());

                        foreach(var selectedFirmId in addOrUpdateUser.SelectedFirmIds)
                        {
                            var firm = await _unitOfWork.Firm.GetAsync(f => f.Id == selectedFirmId);
                            if (firm != null)
                            {
                                await _unitOfWork.UserFirmMapping.AddAsync(new UserFirmMapping
                                {
                                    UserId = addOrUpdateUser.Id,
                                    FirmId = firm.Id,
                                    CreatedDate = DateTime.Now,
                                    CreatedByName = "Admin",
                                    ModifiedDate = DateTime.Now,
                                    ModifiedByName = "Admin",
                                    IsActive = true,
                                    IsDeleted = false
                                });
                                await _unitOfWork.SaveAsync();
                            }
                                
                        }


                    }

                }

                return View(addOrUpdateUser);
            }

        }

        [HttpGet]
        public async Task<IActionResult> UserDetail(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user != null)
                return View(new UserDetailModel
                {
                    UserId = id,
                });

            return RedirectToAction(nameof(Index));
        }



    }
}
