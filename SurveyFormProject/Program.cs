using System;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SurveyFormProject.DbContexts;
using SurveyFormProject.Repositories;

namespace SurveyFormProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var useEf = bool.Parse(builder.Configuration["ConnectionSettings:UseEf"]);
            
            //set framework settings from appsettins.Development.Json
            if(useEf) 
                builder.Services.AddScoped<IRepository, RepositoryEF>();             //EF
            else
                builder.Services.AddScoped<IRepository, RepositoryAdo>();           //AdoNet

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //EF
            builder.Services.AddDbContext<SurveyFormContext>(dbContextOptions =>
                dbContextOptions.UseSqlServer(
                    builder.Configuration["ConnectionStrings:DockerConnectionString"]));

            //AdoNet
            


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios.
                // See https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
