using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using BnLog.DAL.IRepository;
using BnLog.DAL.Models.Security;
using BnLog.DAL.Repository;
using BnLog.DAL.Repository.Items;
using BnLog.DAL.Repository.Entity;
using BnLog.VAL;
using BnLog.BLL.Services.IService;
using BnLog.BLL.Services;
using BnLog.BLL.Extentions;



namespace BnLog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // Connect AutoMapper
            //var mapperConfig = new MapperConfiguration((v) =>
            //{
            //    v.AddProfile(new MappingProfile());
            //});
            //IMapper mapper = mapperConfig.CreateMapper();

            // Connect DataBase
            string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
            //builder.Services.AddDbContext<BlogDbContext>(options => options.UseSqlServer(connection));
            builder.Services.AddDbContext<BlogDbContext>(option => option.UseSqlServer(connection), ServiceLifetime.Scoped);

            // Add MS SECURITY
            builder.Services.AddIdentity<User, Role>(opts =>
            {
                opts.Password.RequiredLength = 5;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            })
                .AddEntityFrameworkStores<BlogDbContext>();
 
            builder.Services.AddUnitOfWork()
                .AddDirectRepositories()
                .AddRepositories()
                .AddServicesBL()
                .AddAutoMapper();
           // Не забыть бы потом Services AddSwaggerGen
           //builder.Services.AddSwaggerGen(c =>
           //{
           //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AuthenticationService", Version = "v1" });
           //});

            // subServices mapper & Company...AddSingletons/Transient
           builder.Services
                //.AddSingleton(mapper)
                //.AddTransient<ICommentService, CommentService>()
                //.AddTransient<IHomeService, HomeService>()
                //.AddTransient<IPostService, PostService>()
                //.AddTransient<ITagService, TagService>()

                //.AddTransient<IRoleService, RoleService>()
                //.AddTransient<ISecurityService, SecurityService>()

                //.AddTransient<ICommentRepository, CommentRepository>()
                //.AddTransient<IPostRepository, PostRepository>()
                //.AddTransient<ITagRepository, TagRepository>()

                .AddTransient<IItemsRepository, ItemsRepository>();
                
                
                

            // Connect logger
            builder.Logging
                .ClearProviders()
                .SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace)
                //
                .AddConsole();

            // AddAuthentication "Cookies"
            builder.Services.AddAuthentication(options => options.DefaultScheme = "Cookies")
                .AddCookie("Cookies", options =>
                {
                    options.Events = new Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents
                    {
                        OnRedirectToLogin = redirectContext =>
                        {
                            redirectContext.HttpContext.Response.StatusCode = 401;
                            return Task.CompletedTask;
                        }
                    };
                });

            // Start WebApplication
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}