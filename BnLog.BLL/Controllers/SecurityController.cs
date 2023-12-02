using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

using BnLog.DAL.Models.Security;
using BnLog.VAL.Request.Security;
using BnLog.VAL.Services.IService;
using System.Security.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Text;


namespace BnLog.BLL.Controllers
{
    //public class AccountController : Controller
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
        /// [Get] Метод, login
        /// </summary>
        [Route("Security/Login")]  
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// [Post] Метод, login
        /// </summary>
        [Route("Security/Login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginRequest model)
        {
            //Что-то Claim навертелось...
            StringBuilder ExMsg = new StringBuilder();
            //Check Login/Password format
            if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Неправильный ввод логина и/или пароля");
                    ExMsg.AppendFormat("onEntryLoginErr: UserLoginRequest.inVald : Login:[{0}] Psw[{1}]", model.Email, model.Password);//.ToString()); 
                    throw new AuthenticationException(ExMsg.ToString());
                }
            //Try to entry by Login/Password
            var result = await _securityService.Login(model);
            if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                    ExMsg.AppendFormat("onLoginErr: LoginOrPassword.inVald : Login:[{0}] Psw[{1}]", model.Email, model.Password);
                    throw new AuthenticationException(ExMsg.ToString());
                    return View(model);
                    //return RedirectToAction("Error", "Home");//Можно итак грубо... Но здесь ли??                 
                    //throw new AuthenticationException("User password incorrect");//здесь ли??
                  }
            //ALL is OK 
            //Add claims etc..
            //Возможно и не стоит так извращаться, в сервисе и так установлен флаг на хранение Cookieы ??? Think it Man...
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, model.Email) // Claim for user Name
                //new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name) // Claim for user Role
            };
            
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                claims,
                "AppCookie",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            //Go to work   
            return RedirectToAction("Index", "Home");
            //return RedirectToAction("UserPage","Home", model);
            //return _mapper.Map<UserViewModel>(user);        
            
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

        /// <summary>
        /// [Post] Метод, выхода из аккаунта
        /// </summary>
        [Route("Security/Logout")]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> LogoutAccount(Guid id)
        {
            await _securityService.LogoutAccount();
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// [Get] Метод, получения всех пользователей
        /// </summary>
        [Route("Security/GetAccounts")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            ViewBag.CardView = 1;
            ViewBag.TableView = 1;
            var users = await _securityService.GetAccounts();

            return View(users);
        }
    }
}
