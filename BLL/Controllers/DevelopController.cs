﻿using AutoMapper;
using BnLog.BLL.Services;
using BnLog.BLL.Services.IService;
using BnLog.DLL.Develop;
using BnLog.DLL.Models.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data;

namespace BnLog.BLL.Controllers
{
    public class DevelopController : Controller
    {
        //Добавочные опции для Разработчика.
        //Минимум Users+Roles генерятся в HomeService
        //Здесь планируется расположить генераторы тестовых Post;sbyte etc
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ISecurityService _securityService;
        private readonly IMapper _mapper;
        private readonly ILogger<DevelopController> _logger;
        public DevelopController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, RoleManager<Role> roleManager, ISecurityService securityService, ILogger<DevelopController> logger)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _securityService = securityService;
            _logger = logger;

        }
        #region DevelopGenerate
        [Authorize(Roles = "Разработчик")]
        [Route("Develop/Generate")]
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
