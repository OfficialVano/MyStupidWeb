using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication1.Data;
using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Mocks;
using WebApplication1.Data.Models;
using WebApplication1.Data.Repository;

namespace WebApplication1
{
    public class Startup
    {
        private readonly IConfigurationRoot _configurationRoot;

        public Startup(IWebHostEnvironment hostEnvironment)
        {
            _configurationRoot = new ConfigurationBuilder().SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("dbsettings.json").Build();
        }

        /*
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }*/

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContent>(options =>
            {
                options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection"));
            });

            services.AddTransient<ICategories, CategoryRepository>();
            services.AddTransient<IProducts, ProductRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(ShopCart.GetCart);

            services.AddMvc(mvcOptions =>
            {
                mvcOptions.EnableEndpointRouting = false;
            });

            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                app.UseStaticFiles();
                app.UseSession();
                //app.UseMvcWithDefaultRoute();
                app.UseMvc(routes =>
                {
                    routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
                    routes.MapRoute("categoryFilter", "Products/{action}/{category?}", new {Controller = "Products", Action = "List"});
                });
            }

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContent = scope.ServiceProvider.GetRequiredService<AppDbContent>();
                DbObject.Initial(dbContent);
            }
            
            //}



            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello world");
            //});


            //app.UseHttpsRedirection();
            //app.UseStaticFiles();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapRazorPages();
            //});


        }
    }
}
