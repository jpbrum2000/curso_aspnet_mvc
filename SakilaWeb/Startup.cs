﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SakilaWeb.DB;
using SakilaWeb.Service;
using SakilaWeb.Security;
using Microsoft.AspNetCore.Identity;
using SakilaWeb.Middlewares;
using Microsoft.Extensions.Options;

namespace SakilaWeb
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<SakilaDbContext>(options => options.UseMySql(Configuration.GetConnectionString("sakila")));

            services.AddScoped(typeof(IFilmService),typeof(FilmService));

            services.AddIdentity<ApplicationUser,ApplicationRole>().AddEntityFrameworkStores<SakilaDbContext>();

            services.Configure<IdentityOptions>(options => {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.User.RequireUniqueEmail = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseLoggerMiddleware(new LoggerMiddlewareOptions(){
                FileName = "C:\\Users\\ADM\\AppData\\Local\\Temp\\sakila.log"
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Film}/{action=ListAll}/{id?}");
                    routes.MapRoute(
                        name: "areas",
                        template:"{area:exists}/{controller=Home}/{action=Index}"
                    );
            });

           
        }
    }
}
