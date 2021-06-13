using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Identity;
using RepositoryLayer.Seed;
using RepositoryLayer;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Identity;

namespace CineWeb
{
    public class Startup
    {
        private IConfiguration Configuration { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();

            //* Configure all about identity
            ConfigureIdentity.DoConfiguration(services, Configuration);
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("CinePlus")));


            services.AddScoped<IUserStore, CinemaUsersStore>();
            services.AddScoped<IAuthorizeUser, CinemaAuthorization>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // * Handle error 404
            app.UseStatusCodePagesWithReExecute("/Home/Error404");

            // * To load static files
            app.UseStaticFiles();

            app.UseRouting();

            // * Auth and sign
            app.UseAuthentication();
            app.UseAuthorization();
             
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });


            // * Seeds
            Sower.SowSeeds(app);
        }
    }
}

