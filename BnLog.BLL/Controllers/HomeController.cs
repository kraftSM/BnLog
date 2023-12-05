using AutoMapper;
using BnLog.BLL.Services.IService;
using BnLog.DAL.Models;
using BnLog.BLL.Services.IService;
using BnLog.VAL.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using AutoMapper.Internal;
using BnLog.DAL.Models.Security;
using BnLog.VAL.Request.Security;
using Microsoft.EntityFrameworkCore;
using BnLog.BLL.Services;
using System.Xml.Linq;
using System.Threading.Tasks;
using BnLog.DAL.IRepository;
using BnLog.VAL.Services.IService;
using BnLog.VAL.Response.Items;
using BnLog.VAL.Models;
using Microsoft.Extensions.Options;

namespace BnLog.BLL.Controllers
    {
    public class HomeController : Controller
        {
        private IOptions<ApplConfiguration> _settings; 
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IHomeService _homeService;
        private readonly IItemService _itemService;
        private readonly ILogger<HomeController> _logger;
        private readonly IItemsRepository _itemRepo;
        private IMapper _mapper;

        public HomeController ( IOptions<ApplConfiguration> settings, RoleManager<Role> roleManager, UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, IHomeService homeService, IItemService itemService, ILogger<HomeController> logger, IItemsRepository itemRepo )
            {
            _settings = settings; 
            _itemRepo = itemRepo;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _homeService = homeService;
            _itemService = itemService;

            _mapper = mapper;
            _logger = logger;
            }
        public async Task<IActionResult> Index ( )
            {
            if (!_settings.Value.dbIsPreloaded) 
                await _homeService.GenerateData();
            return View(new MainRequest());
            // return View();
            }
        [NonAction]
        [HttpGet]
        [Authorize]
        [Route("Home/UserPage")]
        //public IActionResult UserPage(UserLoginRequest model)
        public async Task<IActionResult> UserPage ( string? UserName = null )
            {
            var user = await _userManager.FindByNameAsync(UserName);

            //var itemInfo =  new ItemInfo();
            //var itemInfo = _itemService.GetItemInfo(user.Id);
            //_userManager.GetUserName;
            return View("UserPage", user);
            }

        public IActionResult Privacy ( )
            {
            return View();
            }

    }
        
}