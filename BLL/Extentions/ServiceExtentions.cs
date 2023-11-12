﻿using AutoMapper;
using BnLog.BLL.Services.IService;
using BnLog.BLL.Services;
using BnLog.DAL.IRepository;
using BnLog.DAL.Models.Entity;
using BnLog.DAL.Repository.Entity;
using BnLog.DAL.Repository;
using BnLog.VAL;
using Microsoft.Extensions.DependencyInjection;
using BnLog.DAL.Models.Items;
using BnLog.DAL.Repository.Items;

namespace BnLog.BLL.Extentions
{
    // <summary>
    /// Методы расширения сервисов
    /// </summary>
    public static class ServiceExtentions
    {
        #region Реализация паттерна UnitOfWork
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddCustomRepository<TEntity, IRepository>(this IServiceCollection services)
                 where TEntity : class
                 where IRepository : class, IRepository<TEntity>
        {
            services.AddScoped<IRepository<TEntity>, IRepository>();

            return services;
        }
        #endregion

        #region ServiceExtentions-> BAL services
        public static IServiceCollection AddServicesBL(this IServiceCollection services)
        {
            
            //Entity services
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ITagService, TagService>();
            //security services
            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<IRoleService, RoleService>();
            //Other services
            services.AddScoped<IHomeService, HomeService>();

            //.AddTransient<ITagRepository, TagRepository>()
            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IDataDefaultService, DataDefaultService>();       
            
            return services;
        }
        #endregion

        #region ServiceExtentions-> DAL Direct Repositories
        public static IServiceCollection AddDirectRepositories(this IServiceCollection services)
        {
            //Entity services
            services.AddTransient<ITagRepository, TagRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IPostRepository, PostRepository>();
            //services.AddScoped<IPostRepository, PostRepository>();
            //services.AddTransient<ICommentRepository, CommentRepository>();
            //services.AddScoped<ITagRepository, TagRepository>();

            return services;
        }
        #endregion
        #region ServiceExtentions-> DAL UoW Repositories
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            //Items Repository
            services.AddTransient<IRepository<ItemOption>, ItemOptionRepository>();
            ////services.AddScoped<IRepository<Article>, ArticleRepository>();
            //services.AddScoped<IRepository<Comment>, CommentRepository>();
            //services.AddScoped<IRepository<Tag>, TagRepository>();

            return services;
        }
        #endregion


        #region Конфигурация automapper'a
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration((v) =>
            {
                v.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
        #endregion
    }
}