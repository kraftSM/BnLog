using AutoMapper;

using BnLog.DAL.IRepository;
using BnLog.DAL.Repository.Entity;
using BnLog.DAL.Repository;
using BnLog.DAL.Repository.Items;

using BnLog.VAL.Services.IService;
using BnLog.VAL.Services;
using BnLog.VAL.Validators;
//using BnLog.VAL.Exceptions;
using BnLog.VAL.Request.Entity;
using BnLog.VAL.Request.Security;
using FluentValidation;

namespace BnLog.VAL.Extentions
{
    // <summary>
    /// Методы расширения сервисов
    /// </summary>
    public static class ServiceExtentions
    {
        public static IServiceCollection AddApplConfiguration(this IServiceCollection services)
        {
            //services.AddScoped<IApplConfigurationService, ApplConfigurationService>();

            return services;
        }

        #region For UnitOfWork Pattern
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

        #region ServiceExtentions-> BLL services
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
            services.AddScoped<IItemService, ItemService>();

            //services.AddScoped<ItemInfo, ItemService>();

            //.AddTransient<ITagRepository, TagRepository>()
            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IDataDefaultService, DataDefaultService>();

            //Add Validators
            //security Validators
            services.AddTransient<IValidator<RoleEditRequest>, RoleRequestValidator>();
            services.AddTransient<IValidator<UserEditRequest>, UserRequestValidator>();
            //Entity Validators
            services.AddTransient<IValidator<TagSelectInfo>, TagRequestValidator>();
            services.AddTransient<IValidator<PostEditRequest>, PostRequestValidator>();
            services.AddTransient<IValidator<CommentRequest>, CommentRequestValidator>();

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
            services.AddTransient<IItemsRepository0, ItemsRepository0>();

            services.AddScoped<IItemsRepository, ItemsRepository>();
            services.AddScoped<IItemResurceRepository, ItemResurceRepository>();
            services.AddScoped<IItemOptionRepository, ItemOptionRepository>();
            //services.AddTransient<IItemsRepository, ItemsRepository>();
            //services.AddTransient<IItemResurceRepository, ItemResurceRepository>();
            //services.AddTransient<IItemOptionRepository, ItemOptionRepository>();

            //services.AddScoped<IPostRepository, PostRepository>();
            //services.AddScoped<ICommentRepository, CommentRepository>();
            //services.AddScoped<ITagRepository, TagRepository>();
            //services.AddScoped<IItemsRepository, ItemsRepository>();

            return services;
        }
        #endregion
        #region ServiceExtentions-> DAL UoW Repositories
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            //Items Repository            
            //services.AddTransient<IRepository<ItemOptionRepository>(new ItemOptionRepository ()); //Try rester ItemOptionRepository for avoid exception Not Help
            //services.AddTransient<IRepository<ItemOption>, ItemOptionRepository>();
            //services.AddTransient<IRepository<ItemResurce>, ItemResurceRepository>();

            //services.AddCustomRepository<ItemOption, ItemOptionRepository>();
            //services.AddCustomRepository<ItemResurce, ItemResurceRepository>();

            //services.AddScoped<IRepository <ItemOption>, ItemOptionRepository>();
            //services.AddScoped<IRepository<ItemResurce>, ItemResurceRepository>();

            return services;
        }
        #endregion

        #region Mapper Configuration for automapper
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
