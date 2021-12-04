using CinemaProject;
using CinemaProject.Data;
using CinemaProject.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;


namespace CinemaProject
{
    

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
         
           services.AddDbContext<ApplicationDbContext>();
            services.AddSession();


            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.Cookie.Name = "Cookie";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(720);
                options.LoginPath = "/Session/SignIn";
                options.LogoutPath = "/Session/Logout";
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });


         





            services.AddIdentity<User, Role>(options =>
            {
                options.User.RequireUniqueEmail = false;
               

            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
          

            


            services.AddControllersWithViews();
            services.AddMvc();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();

            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   
                    pattern: "{controller}/{action}/{id?}",
                    constraints: new { id = "int" },
                    defaults: new { Controller = "Home", Action = "Index" },
                    name: "MyRoute"
                    );
            });
        }
    }
}