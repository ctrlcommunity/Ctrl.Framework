using System;
using Ctrl.Core.Core.Http;
using Ctrl.Core.PetaPoco.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Ctrl.Web.Host.Startup
{

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMemoryCache();
            //services.AddHttpContextAccessors();
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(o =>
            //    {
            //        o.LoginPath = new PathString("/sysManage/Account/Login");
            //        o.AccessDeniedPath = new PathString("/sysManage/Home/NotFounds");
            //        o.SlidingExpiration = true;
            //    });
            //services.AddPetaPoco(o =>
            //{
            //    o.ConnectionString = "Data Source=.;Initial Catalog=Ctrl.Framework;User ID=sa;Password=sa;MultipleActiveResultSets=true;";
            //    o.Name = "mssql";
            //});
            //services.AddControllersWithViews(options =>
            //{
            //    options.Filters.Add(typeof(OperationLogAttribute));
            //    options.Filters.Add(typeof(ExceptionFilterAttribute));
            //    options.Filters.Add(typeof(WebPermissionFilter));
            //}).AddNewtonsoftJson(options =>
            //{
            //    options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            //});

            services.AddApplication<AppModule>();
        }


        public void Configure(IApplicationBuilder app)
        {
            app.InitializeApplication();
        }
    }
}
