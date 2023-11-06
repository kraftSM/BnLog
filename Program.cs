using AutoMapper;
using BnLog.BLL;
using BnLog.BLL.Services.IService;
using BnLog.BLL.Services;
using Microsoft.EntityFrameworkCore;
using BnLog.DAL.IRepository;
using BnLog.DAL.Models.Security;
using BnLog.DAL.Repository.Entity;
using BnLog.DAL.Repository;

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
            var mapperConfig = new MapperConfiguration((v) =>
            {
                v.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();

            // Connect DataBase
            string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<BlogDbContext>(options => options.UseSqlServer(connection))
                .AddIdentity<User, Role>(opts =>
                {
                    opts.Password.RequiredLength = 5;
                    opts.Password.RequireNonAlphanumeric = false;
                    opts.Password.RequireLowercase = false;
                    opts.Password.RequireUppercase = false;
                    opts.Password.RequireDigit = false;
                })
                .AddEntityFrameworkStores<BlogDbContext>();


            // Services AddSingletons/Transient
            builder.Services
                .AddSingleton(mapper)
                .AddTransient<ICommentService, CommentService>()
                .AddTransient<IHomeService, HomeService>()
                .AddTransient<IPostService, PostService>()
                .AddTransient<ITagService, TagService>()
                .AddTransient<IRoleService, RoleService>()
                .AddTransient<ICommentRepository, CommentRepository>()
                .AddTransient<ITagRepository, TagRepository>()
                .AddTransient<IPostRepository, PostRepository>()
                .AddTransient<ISecurityService, SecurityService>();

            // Connect logger
            builder.Logging
                .ClearProviders()
                .SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace)
                //
                .AddConsole();        


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