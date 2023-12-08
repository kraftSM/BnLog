using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
using BnLog.VAL.Services.IService;
using BnLog.VAL.Services;
using System.Diagnostics.Eventing.Reader;
//using BnLog.BLL.Exceptions;
using BnLog.BLL.Controllers;
using Microsoft.AspNetCore.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using BnLog.VAL.Models;
using BnLog.VAL.Exceptions;
using BnLog.VAL.Extentions;

namespace BnLog
{
    public class Program
        {
        public static void Main ( string[ ] args )
            {
            var builder = WebApplication.CreateBuilder(args);

            // Add services Configuration
            //builder.Services.AddScoped<ExceptionMiddleware>();
            builder.Services.Configure<ApplConfiguration>(builder.Configuration.GetSection("ApplConfig"));
            

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddControllersWithViews();
            //builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddRazorPages();

			// Connect DataBase
			string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
            //builder.Services.AddDbContext<BlogDbContext>(options => options.UseSqlServer(connection), ServiceLifetime.Singleton);
            builder.Services.AddDbContext<BlogDbContext>(options => options.UseSqlServer(connection), ServiceLifetime.Scoped); // контекст вызова явно
            // Add MS SECURITY
            builder.Services
                .AddIdentity<User, Role>(opts => {
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

            // Configure Logging Connect NLog as logger & Console
            builder.Logging
                .ClearProviders()
                .SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace)
                .AddNLog("nlog")
                .AddConsole();


            // AddAuthentication "Cookies"
            builder.Services.AddAuthentication(options => options.DefaultScheme = "Cookies")
                .AddCookie("Cookies", options => {
                    options.Events = new Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents
                        {
                        OnRedirectToLogin = redirectContext => {
                            redirectContext.HttpContext.Response.StatusCode = 401;
                            return Task.CompletedTask;
                        }
                    };
                });

            // AddConsole & Start WebApplication
            var app = builder.Build();

            //app.UseMiddleware<GlobalExceptionMiddleware>();
            //app.UseMiddleware<ExceptionMiddleware>();
            //app.UseGlobalExceptionHandler();

            // Configure the HTTP request pipeline.
            #region For UseDeveloperExceptionPage Try-1


            //if (!app.Environment.IsDevelopment())
            //    {
            //    ////app.UseDeveloperExceptionPage();

            //    ////app.UseExceptionHandler("/Home/Error");
            //    ////app.UseStatusCodePagesWithReExecute("/Home/HandleError/{0}");

            //    //app.UseStatusCodePagesWithReExecute("/Home/Error/{0}", "?code={0}");

            //    //1
            //    app.UseExceptionHandler("/Error");                
            //    //The default HSTS value is 30 days.You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();

            //    }

            ////app.UseStatusCodePagesWithReExecute("/StatusCode/{0}");//1


            //    // Этот сегмент кода пока не в работе, скажем так не ясно, будет ли нужен... Здесь просто STUB
            //else
            //    {
            //    app.UseExceptionHandler("/Error");
            //    app.UseHsts();
            //    };
            #endregion

            // 3 -> Error are based on ErrorsController
            #region For UseDeveloperExceptionPage Try-3
            // 3 -> Error are based on ErrorsController
            // <snippet_ConsistentEnvironments>
            if (app.Environment.IsDevelopment())
                {
                app.UseExceptionHandler("/error-exp");
                
                //app.UseExceptionHandler("/error-development"); 
                //app.UseExceptionHandler(exceptionHandlerApp =>
                //{
                //	exceptionHandlerApp.Run(async context =>
                //	{
                //		context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                //		// using static System.Net.Mime.MediaTypeNames;
                //		context.Response.ContentType = Text.Plain;

                //		await context.Response.WriteAsync("An exception was thrown. Lambda CASE");

                //		var exceptionHandlerPathFeature =
                //			context.Features.Get<IExceptionHandlerPathFeature>();

                //		if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
                //			{
                //			await context.Response.WriteAsync(" The file was not found.");
                //			}

                //		if (exceptionHandlerPathFeature?.Path == "/")
                //			{
                //			await context.Response.WriteAsync(" Page: Home.");
                //			}
                //	});
                //});

                app.UseHsts();


                }
            else
                {
                app.UseExceptionHandler("/error");
                }



            // </snippet_ConsistentEnvironments>
            #endregion

            app.UseHttpsRedirection(); //?? 

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseMiddleware<GlobalExceptionMiddleware>();            
            //app.UseMiddleware<ExceptionMiddleware>();
            //app.UseGlobalExceptionHandler();


            //app.MapRazorPages();//3?
            //app.MapControllers();


            app.UseStatusCodePagesWithReExecute("/Errors/ErrorsRedirect", "?statusCode={0}");//3-2
            //app.UseStatusCodePagesWithReExecute("error/error/{0}"); //3-1 work +/-
            //app.UseStatusCodePagesWithRedirects("/error/{0}"); //3-0
            //app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}"); //2

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            //app.UseGlobalExceptionHandler();

            app.Run();
            }

    }
       
}