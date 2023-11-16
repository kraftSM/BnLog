using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using NLog;
using NLog.Fluent;
using NLog.Web;

using BnLog.DAL.IRepository;
using BnLog.DAL.Models.Security;
using BnLog.DAL.Models.Items;
using BnLog.DAL.Repository;
using BnLog.DAL.Repository.Items;
using BnLog.DAL.Repository.Entity;
using BnLog.VAL;
using BnLog.BLL.Services.IService;
using BnLog.BLL.Services;
using BnLog.BLL.Extentions;
using System.Diagnostics.Eventing.Reader;

namespace BnLog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //builder.Configuration.Get
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Connect DataBase
            string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
            //builder.Services.AddDbContext<BlogDbContext>(options => options.UseSqlServer(connection), ServiceLifetime.Singleton);
            builder.Services.AddDbContext<BlogDbContext>(options => options.UseSqlServer(connection), ServiceLifetime.Scoped); // rконтекст вызова явно
            // Add MS SECURITY
            builder.Services
                .AddIdentity<User, Role>(opts =>
                    {
                        opts.Password.RequiredLength = 5;
                        opts.Password.RequireNonAlphanumeric = false;
                        opts.Password.RequireLowercase = false;
                        opts.Password.RequireUppercase = false;
                        opts.Password.RequireDigit = false;
                    })
                .AddEntityFrameworkStores<BlogDbContext>();


            // subServices, mapper & Company...+ Try ( but  NOT WORK) UnitOfWork() 
            builder.Services
                .AddServicesBL()
                .AddDirectRepositories()
                // // UnitOfWork() не интегруем, DI exception - дописать потом,if any...
                //.AddUnitOfWork()
                // //(1) or (2)
                // // (1).AddCustomRepository<ItemOption, ItemOptionRepository>()
                // // (1).AddCustomRepository<ItemResurce, ItemResurceRepository>()
                // // (2).AddRepositories()
                .AddAutoMapper();

            // Connect logger
            builder.Logging
                .ClearProviders()
                .SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace)
                //.AddConsole();
            .AddConsole()
            .AddNLog("nlog");

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
                ////app.UseDeveloperExceptionPage();

                ////app.UseExceptionHandler("/Home/Error");
                ////app.UseStatusCodePagesWithReExecute("/Home/HandleError/{0}");

                //app.UseStatusCodePagesWithReExecute("/Home/Error/{0}", "?code={0}");

                //1
                app.UseExceptionHandler("/Error");                
                //The default HSTS value is 30 days.You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();

                };

            //app.UseStatusCodePagesWithReExecute("/StatusCode/{0}");//1
            

            // Этот сегмент кода пока не в работе, скажем так не ясно, будет ли нужен... Здесь просто STUB
            //else
            //    {
            //    app.UseExceptionHandler("/Error");
            //    app.UseHsts();
            //    }

            // app.UseHttpsRedirection(); //?? 
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}"); //2

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}