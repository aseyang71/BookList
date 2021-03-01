using BookList.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookList
{
    public class Startup
    {
        // Save the configuration to the variable "Configuration" 
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<BookListDbContext>(options =>
           {
               options.UseSqlServer(Configuration["ConnectionStrings:BookListConnection"]);
           });

            // Adding <TService, TImplementation>
            services.AddScoped<IBookListRepository, EFBookListRepository>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //Improve the URLs to a pattern that is more user-friendly
                // Created a few new endpoints route controllers for different url input scenarios such as /{pageNumber}, /{Category}, and {Category}/{pageNumber} below
                endpoints.MapControllerRoute(
                    "pagination",
                    "P{page}",
                    new { Controller = "Home", action = "Index" });

                // Build in the functionality so that the category is dynamically-displayed in the URL
                // I use the property "Category1" from BLP.cs model to categorize each category such as (English) 1. Fiction 2. Non-fiction (Mandarin) 3.商業理財 and 4.投資學
                endpoints.MapControllerRoute("catpage",
                    "{category}/{page:int}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("category",
                    "{category}",
                    new { Controller = "Home", action = "Index" });
                  
                endpoints.MapDefaultControllerRoute();
            });

            SeedData.EnsurePopulated(app);
        }
    }
}
