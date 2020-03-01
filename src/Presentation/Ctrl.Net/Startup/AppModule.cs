using Ctrl.Core.Core.Http;
using Ctrl.System.Business;
using Ctrl.System.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;

namespace Ctrl.Web.Host.Startup
{

    [DependsOn(typeof(AbpAspNetCoreMvcModule))]
    [DependsOn(typeof(AbpAutofacModule))]
    [DependsOn(typeof(AbpMultiTenancyModule))]
    public class AppModule:AbpModule
    {
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        
        
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            var Provider = new FileExtensionContentTypeProvider();
            Provider.Mappings[".less"] = "text/css";
            app.UseStaticFiles(new StaticFileOptions()
            {
                ContentTypeProvider = Provider
            });
            //app.UseMultiTenancy();
            app.UseStaticHttpContext();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRouting();
            app.UseMvcWithDefaultRouteAndArea();

        }
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAssemblyOf<ISystemSqlLogLogic>();
            context.Services.AddAssemblyOf<ISystemSqlLogRepository>();

        }


    }
}
