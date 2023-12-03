using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using NLog;
using NLog.Fluent;
using NLog.Web;

using BnLog.DAL.IRepository;
using BnLog.DAL.Models.Security;
using BnLog.DAL.Models.Items;
using BnLog.DAL.Repository;
using BnLog.DAL.Repository.Items;
using BnLog.DAL.Repository.Entity;


var builder = WebApplication.CreateBuilder(args);
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
// Add services to the container.

builder.Services.AddControllers();
// поддерживает автоматическую генерацию документации WebApi с использованием Swagger
builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "BnLog.Api", Version = "v1" }); });

var app = builder.Build();

if (app.Environment.IsDevelopment())
    {
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BnLog.API v1"));
    }
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
// Сопоставляем маршруты с контроллерами
//app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
app.Run();
