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
using BLL.Services.NerseServices;
using BLL.Services.shiftServeses;
using BLL.Services.RoomServices;
using BLL.Services.RepologeyServices;
using BLL.Services.MedicineServices;
using BLL.Services.LabServices;
using BLL.Services.DoctorWork.DoctorPatiant;
using BLL.Services.PatientLabServices;
using BLL.Services.PatientRediologyServices;
using BLL.Services.PatientRoomServices;
using BLL.Services.PatientSurgeryServices;
using BLL.Services.PatientMedicineServices;
using BLL.Services.SurgeryServices;
using BLL.Services.LabDoctorWorkServices;
using BLL.Services.RadiologyDoctorWorkServices;

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
            //To Get Connection string
            services.AddDbContextPool<AplicationDbContext>(options =>
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

            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IPatientServices, PatientServices>();
            services.AddScoped<IEmplyeeServices, EmplyeeServices>();
            services.AddScoped<IReservationServices, ReservationServices>();
            services.AddScoped<IDepartmentSevice, DepartmentService>();
            services.AddScoped<IUsersServices, UsersServices>();
            services.AddScoped<IRolesServices, RolesServices>();
            services.AddScoped<INurseServices, NurseServices>();
            services.AddScoped<IShiftServeses, ShiftServices>();
            services.AddScoped<IRoomServices, RoomServices>();
            services.AddScoped<IRepologeyServices, RepologeyServices>();
            services.AddScoped<IMedicineServices, MedicineServices>();
            services.AddScoped<ILabServices, LabServices>();
            services.AddScoped<IPatiantDoctor, PatiantDoctor>();
            services.AddScoped<IPatientLabServices, PatientLabServices>();
            services.AddScoped<IPatientMedicineServices, PatientMedicineServices>();
            services.AddScoped<IPatientRediologyServices, PatientRediologyServices>();
            services.AddScoped<IPatientRoomServices, PatientRoomServices>();
            services.AddScoped<IPatientSurgeryServices, PatientSurgeryServices>();
            services.AddScoped<ISurgeryServices, SurgeryServices>();
            services.AddScoped<ILabDoctorWorkServices, LabDoctorWorkServices>();
            services.AddScoped<IRadiologyDoctorWorkServices, RadiologyDoctorWorkServices>();

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
                    pattern: "{controller=Account}/{action=Login}/{id?}");
              
            });
        }
    }
}
