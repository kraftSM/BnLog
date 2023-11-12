using AutoMapper;
using BnLog.BLL.Services.IService;
using BnLog.DAL.Models;
using BnLog.BLL.Services.IService;
using BnLog.VAL.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AutoMapper.Internal;
using BnLog.DAL.Models.Security;
using BnLog.VAL.Request.Security;
using Microsoft.EntityFrameworkCore;
using BnLog.BLL.Services;
using System.Xml.Linq;
using System.Threading.Tasks;
using BnLog.DAL.IRepository;

namespace BnLog.BLL.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IHomeService _homeService;
        private readonly ILogger<HomeController> _logger;
        private readonly IItemsRepository _itemRepo;  
        private IMapper _mapper;

        public HomeController(RoleManager<Role> roleManager, UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, IHomeService homeService, ILogger<HomeController> logger, IItemsRepository itemRepo)
        {
            _itemRepo = itemRepo;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _homeService = homeService;

            _mapper = mapper;
            _logger = logger;
        }
         public async Task<IActionResult> Index()
        {
            await _homeService.GenerateData();
            return View(new MainRequest());
            // return View();
        }

        [Authorize]
        [Route("Home/UserPage")]
        //public IActionResult UserPage(UserLoginRequest model)
        public async Task<IActionResult> UserPage(string? UserName = null)
        {
            var user = await _userManager.FindByNameAsync(UserName);
            
            //_userManager.GetUserName;
            return View("UserPage", user);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("Home/Error")]
        public IActionResult Error(int? statusCode = null)
        {
            if (statusCode.HasValue)
            {
                if (statusCode == 404 || statusCode == 500)
                {
                    var viewName = statusCode.ToString();
                    _logger.LogWarning($"Произошла ошибка - {statusCode}\n{viewName}");
                    return View(viewName);
                }
                else
                    return View("500");
            }
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}