using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BnLog.VAL.Services.IService;
using AutoMapper;

using BnLog.VAL.Response.User;
using BnLog.DAL.Models.Security;

namespace BnLog.API.Controllers
    {
    [ApiController]
    [Route("API/[controller]")]
    public class RoleController : Controller
        {

        private readonly IRoleService _roleService;
        private readonly ILogger<RoleController> _logger;
        private IMapper _mapper;
        public RoleController ( IMapper mapper, IRoleService roleService, ILogger<RoleController> logger )
            {
            _mapper = mapper;
            _roleService = roleService;
            _logger = logger;
            }
        //public IActionResult Index ( )
        //    {
        //    return View();
        //    }
        
    /// <summary>
    /// [Get] Метод, получения всех тегов
    /// </summary>
    
    [Route("Role/GetRoles")]
    [HttpGet]
    //[Authorize(Roles = "Администратор, Модератор")]
    public async Task<List<Role>> GetRoles ( )
        {
        var roles = await _roleService.GetRoles();
        return roles;
        }
    }
}