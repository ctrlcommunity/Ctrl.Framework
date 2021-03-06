﻿using System.IO;
using Ctrl.Core.Core.Http;
using Ctrl.Web.Host.Startup;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;

namespace CtrlCloud.Framework.Web.Startup
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
            //基于文件系统的密钥存储库（持久性保持密钥）
            services.AddDataProtection()
                .PersistKeysToFileSystem(new DirectoryInfo(Path.Combine("login-keys")));
            services.AddApplication<AppModule> ();
            // If using Kestrel:
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            // If using IIS:
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
        }

        public void Configure (IApplicationBuilder app) {
            app.InitializeApplication ();
        }

    }
}