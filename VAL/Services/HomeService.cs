﻿using AutoMapper;
using BnLog.DAL.IRepository;
using BnLog.DAL.Models.Security;
using BnLog.DAL.Repository.Item;
using BnLog.VAL.Request.Security;
using BnLog.VAL.Services.IService;
using BnLog.DAL.Models.Info;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace BnLog.VAL.Services
{
    public class HomeService : IHomeService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        //private readonly ItemInfoRepository _itemRepo;
        //private readonly IItemInfoService _itemManager;
        public IMapper _mapper;

        public HomeService(IMapper mapper, UserManager<User> userManager, RoleManager<Role> roleManager)//,ItemInfoService itemManager
        {
            //_itemRepo = itemRepo;
            //_itemManager = itemManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;

        }

        public async Task GenerateData()
        {
            var testUser0 = new UserRegisterRequest { UserName = "Test0", Email = "Test0@gmail.com", Password = "01234aB", FirstName = "Test0", LastName = "TesTov0" };
            var testUser1 = new UserRegisterRequest { UserName = "Test1", Email = "Test1@gmail.com", Password = "12340aB", FirstName = "Test1", LastName = "TesTov1" };
            var testUser2 = new UserRegisterRequest { UserName = "Test2", Email = "Test2@gmail.com", Password = "23401aB", FirstName = "Test2", LastName = "Testov2" };
            var testUser3 = new UserRegisterRequest { UserName = "Test3", Email = "Test3@gmail.com", Password = "34312aB", FirstName = "Test3", LastName = "Testov3" };

            var user0 = _mapper.Map<User>(testUser0);
            var user1 = _mapper.Map<User>(testUser1);
            var user2 = _mapper.Map<User>(testUser2);
            var user3 = _mapper.Map<User>(testUser3);

            var roleUser = new Role() { Name = "Пользователь", SecurityLvl = 0 };
            var roleModer = new Role() { Name = "Модератор", SecurityLvl = 1 };
            var roleAdmin = new Role() { Name = "Администратор", SecurityLvl = 3 };
            var roleDesign = new Role() { Name = "Разработчик", SecurityLvl = 3 };

            await _userManager.CreateAsync(user0, testUser0.Password);
            await _userManager.CreateAsync(user1, testUser1.Password);
            await _userManager.CreateAsync(user2, testUser2.Password);
            await _userManager.CreateAsync(user3, testUser3.Password);

            await _roleManager.CreateAsync(roleUser);
            await _roleManager.CreateAsync(roleModer);
            await _roleManager.CreateAsync(roleAdmin);
            await _roleManager.CreateAsync(roleDesign);

            await _userManager.AddToRoleAsync(user0, roleUser.Name);
            await _userManager.AddToRoleAsync(user1, roleModer.Name);
            await _userManager.AddToRoleAsync(user2, roleAdmin.Name);
            await _userManager.AddToRoleAsync(user3, roleDesign.Name);

            //var testItem0 = new ItemInfo() { ItemType = 0 };
            //var testItem1 = new ItemInfo() { ItemType = 1 };
            //var testItem2 = new ItemInfo() { ItemType = 2 };
            //await _itemManager.CreateItemInfo(testItem0);
            //await _itemRepo.AddItem (testItem1);
            //await _itemRepo.CreateAsync(testItem2);
        }
    }
}
