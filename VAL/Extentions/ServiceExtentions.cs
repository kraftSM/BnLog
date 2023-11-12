using AutoMapper;
using BnLog.DAL.IRepository;
using BnLog.DAL.Models.Info;
using BnLog.DAL.Models.Entity;
using BnLog.DAL.Repository.Item;
using BnLog.DAL.Repository;
using BnLog.VAL;
using BnLog.DAL.Repository.Entity;
using BnLog.DAL.Repository;
using BnLog.VAL.Services.IService;
using BnLog.VAL.Services;

namespace BnLog.VAL.Extentions
{
    public static class ServiceExtentions
    {
        #region  UnitOfWork startUp
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddSingleton<IUnitOfWork, UnitOfWork>();
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

        #region Service Adding
        public static IServiceCollection AddServicesBLL(this IServiceCollection services)
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
            //services.AddScoped<IHomeService, HomeService>();
            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IDataDefaultService, DataDefaultService>();       
            return services;
        }
        #endregion

        #region Реализация IoC для репозиториев
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            //services.AddScoped<IRepository<IPostRepository, PostRepository>();
            //services.AddScoped<IRepository<Comment>, CommentRepository>();
            //services.AddScoped<ITagRepository<Tag>, TagRepository>();
            //services.AddScoped<IRepository<Tag>, TagRepository>();
            //.AddTransient<ITagRepository, TagRepository>()

            // For UoW make later
            //services.AddSingleton<IRepository<Item>, ItemRepository>();
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
