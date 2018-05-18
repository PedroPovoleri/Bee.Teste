using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Context.ctx;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using Bll.Customers.Interfaces;
using Repository.Generic;
using Bll.Customers.Implemetiation;
using Bll.Validation.Interfaces;
using Bll.Validation.Implemetiation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Bll.Login.Interface;

namespace WebApp
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
            
            string assemblyName = typeof(ApplicationDbContext).Namespace;

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    optionsBuilder =>
                        optionsBuilder.MigrationsAssembly("Context.ctx")
                      )
            );
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(ICustomers), typeof(Custumers));
            services.AddScoped(typeof(IResources), typeof(Resources));
            services.AddScoped(typeof(ILogin), typeof(Bll.Login.Implementation.LoginValidation));

            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddSession(options =>
            {
                options.Cookie.Name = ".UserState";
                options.IdleTimeout = TimeSpan.FromSeconds(300);
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseSession( );
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseAuthentication();
        }
    }
}
