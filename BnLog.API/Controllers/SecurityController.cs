using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

using BnLog.DAL.Models.Security;
using BnLog.VAL.Request.Security;
using BnLog.VAL.Services.IService;
using BnLog.VAL.Response.User;
using BnLog.VAL.Response.Account;
using System.Security.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Text;
using System.Net;


namespace BnLog.API.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class SecurityController : Controller     
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ISecurityService _securityService;
        private readonly IMapper _mapper;
        private readonly ILogger<SecurityController> _logger;

        public SecurityController(RoleManager<Role> roleManager, IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, ISecurityService securityService, ILogger<SecurityController> logger)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _securityService = securityService;
            _logger = logger;
        }

        /// <summary>
        /// [Post] Метод, login
        /// </summary>
        [Route("Login")]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login( [FromBody] UserLoginRequest model)
        {
            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
                throw new ArgumentNullException("User Login Requestis not filling");

            var result = await _securityService.Login(model);
            if (!result.Succeeded)
                throw new AuthenticationException("User Login or Password not not correct");

            //define  Account data 
            var user = await _userManager.FindByEmailAsync(model.Email);
            //claims creation for UserName, user.Id
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimsIdentity.DefaultNameClaimType, model.Email) // Claim for user Name
            };
            //claims creation for User roles
            var roles = await _userManager.GetRolesAsync(user);
            if ((roles.Contains( "Admin" )) || (roles.Contains("Администратор")))
            {
                claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, "Администратор"));
            }
            else
            {
                claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, roles.First ()));
            }

            //var claimsIdentity = new ClaimsIdentity(
            //    claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(15)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                claims,
                "AppCookie",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
            return StatusCode(result.Succeeded ? 201 : 204);
        }
        /// <summary>
        /// [Post] Метод, выхода из аккаунта
        /// </summary>
        [Route("Logout")]
        [HttpPost]
        public async Task<IActionResult> LogoutAccount ( )
        {
            await _securityService.LogoutAccount();
            return StatusCode(201);
        }
        /// <summary>
        /// [Get] Метод, получения всех пользователей
        /// </summary>
        [Route("GetAccounts")]
        //[Authorize(Roles = "Администратор, Модератор")]
        [Authorize]
        [HttpGet]
        //public async Task<List<UserInfo>> GetAccounts ()
        public async Task<List<UserInfo>> GetAccounts ( )
            {

            var users = await _securityService.GetAccounts();
            var userResponse = users.Select(u => new UserInfo
                {
                //Roles = u.Roles,
                //Posts = u.Posts,
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                UserName = u.UserName
                }).ToList();
            return userResponse;
            }

        /// <summary>
        /// [Get] Метод, регистрации
        /// </summary>
        [Route("Security/Register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// [Post] Метод, регистрации
        /// </summary>
        [Route("Security/Register")]
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequest model)
        {
            if (ModelState.IsValid)
            {
                var result = await _securityService.Register(model);

                if (result.Succeeded)
                {
                    _logger.LogInformation($"Создан аккаунт - {model.Email}");
                    //return RedirectToAction("Index", "Home");
                    return RedirectToAction("GetAccounts", "Security");

                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        /// <summary>
        /// [Get] Метод, редактирования
        /// </summary>
        [Route("Security/Edit")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpGet]
        public async Task<IActionResult> EditAccount(Guid id)
        {
            var model = await _securityService.EditAccount(id);
            return View(model);
        }

        /// <summary>
        /// [Post] Метод, редактирования
        /// </summary>
        [Route("Security/Edit")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpPost]
        public async Task<IActionResult> EditAccount(UserEditRequest model)
        {
            var result = await _securityService.EditAccount(model);

            if (result.Succeeded)
            {
                _logger.LogInformation($"Аккаунт - {model.UserName} был изменен");
				//_logger.LogDebug($"Аккаунт - {model.UserName} был изменен");

				//return RedirectToAction("Index", "Home");
				return RedirectToAction("GetAccounts", "Security");
            }
            else
            {
                ModelState.AddModelError("", $"{result.Errors.First().Description}");                
                return View(model);
            }
        }

        /// <summary>
        /// [Get] Метод, удаление аккаунта
        /// </summary>
        [Route("Security/Remove")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpGet]
        public async Task<IActionResult> RemoveAccount(Guid id, bool confirm = true)
        {
            if (confirm)
                await RemoveAccount(id);
            //return RedirectToAction("Index", "Home");
            return RedirectToAction("GetAccounts", "Security");
        }

        /// <summary>
        /// [Post] Метод, удаление аккаунта
        /// </summary>
        [Route("Security/Remove")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpPost]
        public async Task<IActionResult> RemoveAccount(Guid id)
        {
            await _securityService.RemoveAccount(id);
            _logger.LogDebug($"Remove account {id}");

            //return RedirectToAction("Index", "Home");
            return RedirectToAction("GetAccounts", "Security");
        }

 

    
    }
}
