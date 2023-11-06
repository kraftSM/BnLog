using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

using BnLog.BLL.Services;
using BnLog.BLL.Services.IService;

using BnLog.DLL.Models.Security;
using BnLog.DLL.Request.Security;
//using BnLog.
//using BnLog.Views.Security;

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

        //public AccountController(RoleManager<Role> roleManager, IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, IAccountService accountService, ILogger<AccountController> logger)
        public SecurityController(RoleManager<Role> roleManager, IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, ISecurityService securityService, ILogger<SecurityController> logger)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _securityService = securityService;
            _logger = logger;
        }
        //public SecurityController(RoleManager<Role> roleManager, IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, IAccountService accountService, ILogger<AccountController> logger)
        //{
        //    _roleManager = roleManager;
        //    _mapper = mapper;
        //    _userManager = userManager;
        //    _signInManager = signInManager;
        //    _accountService = accountService;
        //    _logger = logger;
        //}

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
            if (ModelState.IsValid)
            {
                var result = await _securityService.Login(model);

                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(model);
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
                    return RedirectToAction("Index", "Home");
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
        //[Authorize(Roles = "Администратор, Модератор")]
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
        //[Authorize(Roles = "Администратор, Модератор")]
        [HttpPost]
        public async Task<IActionResult> EditAccount(UserEditRequest model)
        {
            var result = await _securityService.EditAccount(model);

            if (result.Succeeded)
            {
                _logger.LogDebug($"Аккаунт - {model.UserName} был изменен");
                return RedirectToAction("Index", "Home");
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
            return RedirectToAction("Index", "Home");
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

            return RedirectToAction("Index", "Home");
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
        [Route("Security/Get")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            var users = await _securityService.GetAccounts();

            return View(users);
        }
    }
}
