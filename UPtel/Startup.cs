using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UPtel.Data;
using UPtel.Services;

namespace UPtel
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
             
            services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseSqlServer(
                     Configuration.GetConnectionString("DefaultConnection")));

            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddMvc();


            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                // Sign in
                options.SignIn.RequireConfirmedAccount = false;

                // Password
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                //options.Password.RequiredLength = 8;
                //options.Password.RequiredUniqueChars = 6;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;

                // Lockout
                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>();
  
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddDbContext<UPtelContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("UPtelContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UPtelContext Dbcontext,
            UserManager<IdentityUser> gestorUtilizadores,
            RoleManager<IdentityRole> gestorRoles)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            if (env.IsDevelopment())
            {

                SeedData.InsereDadosTeste(Dbcontext);
                SeedData.InsereDadosTestePaginacaoPesquisa(Dbcontext);

                SeedData.InsereRolesAsync(gestorRoles).Wait();
                SeedData.InsereAdministradorPadraoAsync(gestorUtilizadores).Wait();
                SeedData.InsereUtilizadoresFicticiosAsync(gestorUtilizadores).Wait();


            }
        }
    }
}
