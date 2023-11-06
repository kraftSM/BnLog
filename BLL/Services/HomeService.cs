﻿using AutoMapper;
using BnLog.BLL.Services.IService;
using BnLog.DAL.IRepository;
using BnLog.DAL.Models.Security;
using BnLog.VAL.Request.Security;
using Microsoft.AspNetCore.Identity;

namespace BnLog.BLL.Services
{
    public class HomeService : IHomeService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly ITagRepository _tagRepo;
        public IMapper _mapper;

        public HomeService(ITagRepository tagRepo, RoleManager<Role> roleManager, IMapper mapper, UserManager<User> userManager)
        {
            _tagRepo = tagRepo;
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
            var roleDesign= new Role() { Name = "Разработчик", SecurityLvl = 3 };

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

            //await _tagRepo.AddTag("Test");
        }
    }
}