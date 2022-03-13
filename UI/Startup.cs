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
using DAL;
using DAL.Database;
using BLL.Services;
using BLL.Services.PatientServices;
using BLL.Mapper;
using BLL.Services.EmplyeeServices;
using BLL.Services.ReservationServices;
using BLL.Services.DepartmentServices;
using BLL.Services.UsersServices;
using BLL.Services.RolesServices;

namespace UI
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
            services.AddDbContext<AplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<AplicationDbContext>();
            services.AddControllersWithViews();

            // To Add Identity Tables (Users - Roles - ...)
            services.AddIdentity<IdentityUser, IdentityRole>(options => {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 0; 
            }).AddEntityFrameworkStores<AplicationDbContext>()
        .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>(TokenOptions.DefaultProvider);

            services.AddScoped<BLL.Services.IDoctorService, DoctorService>();
            services.AddScoped<IPatientServices, PatientServices>();
            services.AddScoped<IEmplyeeServices, EmplyeeServices>();
            services.AddScoped<IReservationServices, ReservationServices>();
            services.AddScoped<IDepartmentSevice, DepartmentService>();
            services.AddScoped<IUsersServices, UsersServices>();
            services.AddScoped<IRolesServices, RolesServices>();
            services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));  


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
              
            });
        }
    }
}
