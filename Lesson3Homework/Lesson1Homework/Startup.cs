using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lesson1Homework.Infrastructure;
using Lesson1Homework.Infrastructure.InMemory;
using Lesson1Homework.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Homework.DAL;
//Без этого не работает UseSqlServer 
//https://github.com/aspnet/EntityFrameworkCore/issues/7891
using Microsoft.EntityFrameworkCore;
using Homework.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Lesson1Homework
{
    public class Startup
    {
        //используем автосвойство
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton<IEmployeesData, InMemoryEmployees>();
            services.AddSingleton<IProductData, InMemoryProductData>();

            //Error CS1061  'DbContextOptionsBuilder' does not contain a definition for 'UseSqlServer' and no extension method 'UseSqlServer' accepting a first argument of type 'DbContextOptionsBuilder' could be found
            //using Microsoft.EntityFrameworkCore;
            services.AddDbContext<HomeworkContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<HomeworkContext>()
                .AddDefaultTokenProviders();

            //параметры входа
            services.Configure<IdentityOptions>(options => {
                options.Password.RequiredLength = 6;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(60);
                options.Lockout.MaxFailedAccessAttempts = 10;

                options.Lockout.AllowedForNewUsers = true;
            });

            services.ConfigureApplicationCookie(options => {
                options.CookieHttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromDays(150);

                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";

                options.AccessDeniedPath = "/Account/AccessDenied";

                options.SlidingExpiration = true;
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //использование конфигов и другого
            app.UseStaticFiles();

            //var test = Configuration["CustomKey"];

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync(test);
            //});

            //аутентификация
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );
            }
                );
        }
    }
}
