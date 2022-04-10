using Farhurkala_Store.Application.Interfaces.Contexts;
using Farhurkala_Store.Application.Services.Users.Commands.EditUser;
using Farhurkala_Store.Application.Services.Users.Commands.RegisterUser;
using Farhurkala_Store.Application.Services.Users.Commands.RemoveUser;
using Farhurkala_Store.Application.Services.Users.Commands.UserStatusChange;
using Farhurkala_Store.Application.Services.Users.Queries.GetRoles;
using Farhurkala_Store.Application.Services.Users.Queries.GetUsers;
using Farhurkala_Store.Persistance.Contexts;
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

namespace EndPoint.Site
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
            //ثبت دپندنسی ها و استفاده از سرویس ها
            services.AddScoped<IDataBaseContext,DataBaseContext>();
            services.AddScoped<IGetUsersService,GetUsersService>();
            services.AddScoped<IGetRolesService,GetRolesService>();
            services.AddScoped<IRegisterUserService,RegisterUserService>();
            services.AddScoped<IRemoveUserService, RemoveUserService>();
            services.AddScoped<IUserStatusChangeService, UserStatusChangeService>();
            services.AddScoped<IEditUserService, EditUserService>();


            string connectionString = "Data Source=DESKTOP-O7F0MKL;User Id=sa;Password=nasrin4992;Initial Catalog=Farhurkala_StoreDb;Integrated Security=True;";
            services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(option => option.UseSqlServer(connectionString));
            services.AddControllersWithViews();
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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
