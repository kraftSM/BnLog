using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

using BnLog.VAL;

using BnLog.DAL.Models.Security;
using BnLog.DAL.Models.Info;
using BnLog.DAL.IRepository;
using BnLog.DAL.Repository;
using BnLog.DAL.Repository.Item;
using BnLog.DAL.Repository.Entity;
using BnLog.VAL.Services;
using BnLog.VAL.Services.IService;
using BnLog.VAL.Extentions;

namespace BnLog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            
            //var mapperConfig = new MapperConfiguration((v) =>
            //{
            //    v.AddProfile(new MappingProfile());
            //});
            //IMapper mapper = mapperConfig.CreateMapper();

            // Connect DataBase
            string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
            //builder.Services.AddDbContext<BlogDbContext>(option => option.UseSqlServer(connection), ServiceLifetime.Scoped);
            builder.Services.AddDbContext<BlogDbContext>(option => option.UseSqlServer(connection), ServiceLifetime.Singleton);


            // subServices mapper & Company... via ServiceExtentions
            builder.Services.AddAutoMapper() // Connect AutoMapper
                //.AddUnitOfWork()
                .AddRepositories()
                .AddServicesBLL();
            builder.Services
                //.AddSingleton(mapper)
                // This moved to AddServicesBLL()
                //.AddTransient<ICommentService, CommentService>()
                .AddTransient<IHomeService, HomeService>()
                //.AddTransient<IPostService, PostService>()
                //.AddTransient<ITagService, TagService>()
                //.AddTransient<IRoleService, RoleService>()
                //.AddTransient<ISecurityService, SecurityService>()
                .AddTransient<IItemInfoRepository, ItemInfoRepository>()
                .AddTransient<ICommentRepository, CommentRepository>()
                .AddTransient<ITagRepository, TagRepository>()
                .AddTransient<IPostRepository, PostRepository>();

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

            // Connect logger
            builder.Logging
                .ClearProviders()
                .SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace)
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
            //app.UseStatusCodePagesWithRedirects("/Home/{0}");
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}