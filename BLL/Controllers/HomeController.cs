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
using BnLog.VAL.Services.IService;
using BnLog.VAL.Response.Items;

namespace BnLog.BLL.Controllers
    {
    public class HomeController : Controller
        {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IHomeService _homeService;
        private readonly IItemService _itemService;
        private readonly ILogger<HomeController> _logger;
        private readonly IItemsRepository _itemRepo;
        private IMapper _mapper;

        public HomeController ( RoleManager<Role> roleManager, UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, IHomeService homeService, IItemService itemService, ILogger<HomeController> logger, IItemsRepository itemRepo )
            {
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
            await _homeService.GenerateData();
            return View(new MainRequest());
            // return View();
            }

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("Home/Error")]
        public IActionResult Error ( int? statusCode = null )
            {
            const string viewBaseDir = "Error/";
            var ErrorInfo = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
            if (statusCode.HasValue)
                {
                if (statusCode == 401|| statusCode == 403 || statusCode == 404) //
                    {
                    var stCode = statusCode.ToString();
                    var viewName = viewBaseDir + stCode;
                    //var viewName =  statusCode.ToString();

                    _logger.LogWarning($"Произошла ошибка - {stCode}\t{viewName}");
                    return View(viewName);
                    }
                else
                    {
                    _logger.LogWarning($"Произошла ошибка - {500}"); 
                    return View(viewBaseDir + "500", ErrorInfo); //имеет ли смысл отдавать дот инф. наружу???
                        //return View(viewBaseDir+"500");
                    }
                }
            //Return message by default
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }