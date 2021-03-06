﻿using Ctrl.Application;
using Ctrl.Core.Core.Http;
using Ctrl.Core.EntityFrameworkCore.EntityFrameworkCore;
using Ctrl.Core.Web.Attributes;
using Ctrl.Domain.Models;
using CtrlCloud.Framework.Application.Contracts.CtrlCloud;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using Volo.Abp;
using Volo.Abp.Application;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.Dapper;
using Volo.Abp.Json;
using Volo.Abp.Modularity;

namespace Ctrl.Web.Host.Startup
{

    [DependsOn(
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAspNetCoreMultiTenancyModule),
        typeof(CtrlEntityFrameworkCoreModule),
        typeof(AbpDddApplicationModule),
        typeof(CtrlCloudApplicationContractsModule),
        typeof(AbpAutoMapperModule),
        typeof(AbpAutofacModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpAspNetCoreMvcUiBasicThemeModule),
        typeof(CtrlApplicationModule),
        typeof(CtrlDomainModule),
        typeof(AbpDapperModule))]
    public class AppModule : AbpModule
    {
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();
            //if (env.IsDevelopment())
            //{
            app.UseDeveloperExceptionPage();
            //}
            var provider = new FileExtensionContentTypeProvider();
            provider.Mappings[".less"] = "text/css";
            app.UseStaticFiles(new StaticFileOptions()
            {
                ContentTypeProvider = provider
            });

            #region Nlog
            LogManager.Configuration.Variables["connectionString"] = context.GetConfiguration()["ConnectionStrings:Default"];
            LogManager.Configuration.Variables["nlogDbProvider"] = context.GetConfiguration()["ConnectionStrings:Default"];
            #endregion
         
            app.UseStaticHttpContext();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRouting();
            app.UseMvcWithDefaultRouteAndArea();
        }
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddConventionalRegistrar(new AbpAspNetCoreMvcConventionalRegistrar());
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<MvcNewtonsoftJsonOptions>(options =>
            {
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";//对类型为DateTime的生效
            });
            Configure<MvcOptions>(options =>
            {
                options.Filters.Add(typeof(OperationLogAttribute));
                options.Filters.Add(typeof(ExceptionFilterAttribute));
                options.Filters.Add(typeof(WebPermissionFilter));
            });
            Configure<AbpJsonOptions>(options => options.DefaultDateTimeFormat = "yyyy-MM-dd HH:mm:ss");
            ConfigureAutoMapper();
        }

        private void ConfigureAutoMapper()
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<AppModule>(validate: true);
            });

        }


    }
}
