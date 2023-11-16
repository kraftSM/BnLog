using AutoMapper;
using BnLog.BLL.Services;
using BnLog.BLL.Services.IService;
using BnLog.DAL.Models.Security;
using BnLog.DAL.Develop;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Text.Encodings.Web;
using System.Xml.Linq;
using BnLog.VAL.Services.IService;
using BnLog.VAL.Services;

namespace BnLog.BLL.Controllers
{
    public class ItemsController : Controller
    {
        //Сейчас сделано для просмотра отладки Items(Info) 
        //Может стоит отказаться от этого ВООБЩЕ 

        //Добавочные опции для Разработчика.
        //Минимум данных для теста Users+Roles генерятся в HomeService
        //Здесь планируется расположить генераторы тестовых Post&Comment etc
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ISecurityService _securityService;
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;
        private readonly ILogger<ItemsController> _logger;
        public ItemsController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, RoleManager<Role> roleManager, ISecurityService securityService, IItemService itemService, ILogger<ItemsController> logger)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _securityService = securityService;
            _itemService =  itemService;
        _logger = logger;

        }

        [Authorize(Roles = "Разработчик, Администратор")]
    
        [HttpGet]
        // GET: 
        //[AuthorizeForScopes(ScopeKeySection = "TodoList:TodoListScope")]
        public async Task<ActionResult> Index()
        {
            //return View(await _itemService.GetAsync());
            var allItems  = await _itemService.GetAsync();
            
            if (allItems != null)
            {
                return View("ItemsAll",allItems);
                //return StatusCode(200, allItems);//for API
            }
            else
                return NoContent();
        }
        #region ItemsListAll
        [Authorize(Roles = "Разработчик, Администратор")]
    [Route("Items/ListAll")]
    [HttpGet]
    public async Task<IActionResult> ListAll()
    {
            //DBItems generations
            //var DbItems = new DbGenerate();

            //var userlist = DbItems.GenerateSetOfUser(3);
            //foreach (var user in userlist)
            //{
            //    var result = await _userManager.CreateAsync(user, "123456");

            //    if (!result.Succeeded)
            //        continue;
            //}

            //return RedirectToAction("Index", "Home");
            return View("ItemsAll");
            //return ( HtmlEncoder.Default.Encode($"Hello Man, NumTimes is: 23"));

        }
    #endregion
    #region DevelopGenerate
    [Authorize(Roles = "Разработчик")]
        [Route("tems/DevelopGenerate")]
        [HttpGet]
        public async Task<IActionResult> Generate()
        {
            //DBItems generations
            //var DbItems = new DbGenerate();

            //var userlist = DbItems.GenerateSetOfUser(3);
            //foreach (var user in userlist)
            //{
            //    var result = await _userManager.CreateAsync(user, "123456");

            //    if (!result.Succeeded)
            //        continue;
            //}

            return RedirectToAction("Index", "Home");
        }
        #endregion

    }
}
