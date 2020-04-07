using Ctrl.Core.Core.Http;
using Ctrl.Core.PetaPoco.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace Ctrl.Web.Host.Startup
{

    public class Startup {
        public void ConfigureServices (IServiceCollection services) {
            services.AddHttpContextAccessors();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie (o => {
                    o.LoginPath = new PathString ("/sysManage/Account/Login");
                    o.AccessDeniedPath = new PathString ("/sysManage/Home/NotFounds");
                    o.SlidingExpiration = true;
                    o.Cookie.SameSite = SameSiteMode.None;
                });
            services.AddPetaPoco (o => {
                o.ConnectionString = "Data Source=.;Initial Catalog=Ctrl.Framework;User ID=sa;Password=123456;MultipleActiveResultSets=true;";
                o.Name = "mssql";
            });
            //基于文件系统的密钥存储库（持久性保持密钥）
            services.AddDataProtection()
                .PersistKeysToFileSystem(new DirectoryInfo(Path.Combine("login-keys")));
            services.AddApplication<AppModule> ();
        }

        public void Configure (IApplicationBuilder app) {
            app.InitializeApplication ();
        }

    }
}