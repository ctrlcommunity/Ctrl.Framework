using Ctrl.Core.Core.Http;
using Ctrl.Core.EntityFrameworkCore.EntityFrameworkCore;
using Ctrl.System.Business;
using Ctrl.System.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Dapper;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;

namespace Ctrl.Web.Host.Startup
{

    [DependsOn(
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutofacModule),
        typeof(AbpMultiTenancyModule),
        typeof(AbpAspNetCoreMultiTenancyModule),
        typeof(CtrlEntityFrameworkCoreModule),
        typeof(AbpDapperModule))]
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
            var provider = new FileExtensionContentTypeProvider();
            provider.Mappings[".less"] = "text/css";
            app.UseStaticFiles(new StaticFileOptions()
            {
                ContentTypeProvider = provider
            });
            app.UseMultiTenancy();
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

            Configure<AbpMultiTenancyOptions>(options =>
            {
                options.IsEnabled = true;
            });
            Configure<AbpTenantResolveOptions>(options =>
            {
                options.TenantResolvers.Add(new QueryStringTenantResolveContributor());
                options.TenantResolvers.Add(new RouteTenantResolveContributor());
                options.TenantResolvers.Add(new HeaderTenantResolveContributor());
                options.TenantResolvers.Add(new CookieTenantResolveContributor());
            });

        }


    }
}
