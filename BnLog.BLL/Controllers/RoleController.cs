using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BnLog.BLL.Services.IService;
using BnLog.BLL.Services;
using BnLog.VAL.Request.Security;
using BnLog.VAL.Validators;
using BnLog.DAL.Models.Security;


namespace BnLog.BLL.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<RoleController> _logger;
        private IMapper _mapper;
        public RoleController(IMapper mapper, IRoleService roleService, ILogger<RoleController> logger)
        {
            _mapper = mapper;
            _roleService = roleService;
            _logger = logger;
        }

        /// <summary>
        /// [Get] Метод, создания тега
        /// </summary>
        [NonAction]
        [Route("Role/Create")]
        //[Authorize(Roles = "Администратор, Модератор")]
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        /// <summary>
        /// [Post] Метод, создания тега
        /// </summary>
        [NonAction]
        [Route("Role/Create")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpPost]
        public async Task<IActionResult> CreateRole( RoleEditRequest model )
        {
            if (ModelState.IsValid)
            {
                var roleId = await _roleService.CreateRole(model);
                _logger.LogInformation($"Созданна роль - {model.Name}");
                //return RedirectToAction("Index", "Home");
                return RedirectToAction("GetRoles", "Role");
            }
            else
            {
                ModelState.AddModelError("", "Некорректные данные");
                return View(model);
            }
        }

        /// <summary>
        /// [Get] Метод, редактирования тега
        /// </summary>
        [NonAction]
        [Route("Role/Edit")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpGet]
        public async Task<IActionResult> EditRole(Guid id)
        {
            if (id == null)
                return NotFound();
            var iRole = await _roleService.GetRole(id);
            if (iRole == null)
                return NotFound();

            //var reqModel = _mapper.Map<RoleEditRequest>(iRole);            
            var reqModel = new RoleEditRequest()
                { 
                    Name = iRole.Name,
                    SecurityLvl = iRole.SecurityLvl,
                    Id = id
                };

            return View(reqModel);
            //var view = new RoleEditRequest { Id = id };
            //return View(view);
        }

        /// <summary>
        /// [Post] Метод, редактирования тега
        /// </summary>
        [NonAction]
        [Route("Role/Edit")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpPost]
        public async Task<IActionResult> EditRole(RoleEditRequest model)
        {
            ////Check Map Model
            if (!ModelState.IsValid)
                {
                ModelState.AddModelError("", "Некорректные данные");
                return View(model);
                }
            ////Check Validator Model
            /// Как и требовалось доказать - при правильных ограничениях на модели Fluen Validation не требуется)
            //RoleRequestValidator curValidator = new();
            //var validateResult = curValidator.Validate(model);
            //if (!validateResult.IsValid)
            //    {
            //    ModelState.AddModelError("", "Некорректные данные Валидация");
            //    return View(model);
            //    }


            ////Check Map Model
            //if (!ModelState.IsValid) 
            //    {
            //    ModelState.AddModelError("", "Некорректные данные");
            //    return View(model);
            //    }
            //else {
            //    //Check Validator Model
            //    RoleRequestValidator curValidator = new();
            //    var validateResult = curValidator.Validate(model);
            //    if (!validateResult.IsValid)
            //        {
            //        ModelState.AddModelError("", "Некорректные Валидация");
            //        return View(model);
            //        }
            //    }
            


            //All OK/ Working
            await _roleService.EditRole(model);
            _logger.LogDebug($"Измененна роль - {model.Name}");
            return RedirectToAction("GetRoles", "Role");           

        }

        /// <summary>
        /// [Get] Метод, удаления тега
        /// </summary>
        [NonAction]
        [Route("Role/Remove")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpGet]
        public async Task<IActionResult> RemoveRole(Guid id, bool isConfirm = true)
        {
            if (isConfirm)
                await RemoveRole(id);
            //return RedirectToAction("Index", "Home");
            return RedirectToAction("GetRoles", "Role");
        }

        /// <summary>
        /// [Post] Метод, удаления тега
        /// </summary>
        [NonAction]
        [Route("Role/Remove")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpPost]
        public async Task<IActionResult> RemoveRole(Guid id)
        {
            await _roleService.RemoveRole(id);
            _logger.LogDebug($"Удаленна роль - {id}");
            //return RedirectToAction("Index", "Home");
            return RedirectToAction("GetRoles", "Role");
        }

        /// <summary>
        /// [Get] Метод, получения всех тегов
        /// </summary>
        [NonAction]
        [Route("Role/GetRoles")]
        [HttpGet]
        [Authorize(Roles = "Администратор, Модератор")]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _roleService.GetRoles();
            return View( roles);
        }
    }
}
