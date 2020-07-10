using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SportStore.Models;

namespace SportStore
{
    public class Startup
    {
        //   F i e l d s   &   P r o p e r t i e s

        private IConfiguration configuration { get; }

        //   C o n s t r u c t o r s

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        //   M e t h o d s

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer
                    (configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICartRepository, SessionCartRepository>();
            services.AddScoped<IOrderRepository, EfOrderRepository>();
            services.AddScoped<IProductRepository, EfProductRepository>();

            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: null,
                   pattern: "{controller=Product}/{action=Index}/{category}/Page{productPage:int}");

                endpoints.MapControllerRoute(
                   name: null,
                   pattern: "{controller=Product}/{action=Index}/Page{productPage:int}");

                endpoints.MapControllerRoute(
                   name: null,
                   pattern: "{controller=Product}/{action=Index}/{category:alpha?}");

                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Product}/{action=Index}/{id:int?}");
            });
        }
    }
}
