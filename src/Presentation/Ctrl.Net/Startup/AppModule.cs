﻿using System;
using Ctrl.Core.Core.Http;
using Ctrl.Core.EntityFrameworkCore.EntityFrameworkCore;
using Ctrl.Domain.Models;
using Ctrl.Domain.Models.Dtos.Identity;
using Ctrl.System.Business;
using Ctrl.System.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Volo.Abp;
using Volo.Abp.Application;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.AspNetCore.VirtualFileSystem;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.Dapper;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectMapping;

namespace Ctrl.Web.Host.Startup
{

    [DependsOn(
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpMultiTenancyModule),
        typeof(AbpAspNetCoreMultiTenancyModule),
        typeof(CtrlEntityFrameworkCoreModule),
        typeof(AbpDddApplicationModule),
             // typeof(AbpAutoMapperModule),
        typeof(AbpAutofacModule),
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
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddConventionalRegistrar(new AbpAspNetCoreMvcConventionalRegistrar());
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAssemblyOf<ISystemSqlLogLogic>();
          
            context.Services.AddAssemblyOf<ISystemSqlLogRepository>();
           // context.Services.AddAutoMapperObjectMapper<AppModule>();
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
            // context.Services.AddApplication<AppModule>();
            // ConfigureAutoMapper();
            context.Services.Insert(0,
                ServiceDescriptor.Singleton<IConfigureOptions<RazorViewEngineOptions>>(
                    new ConfigureOptions<RazorViewEngineOptions>(options =>
                        {
                        
                        
                        }
                    )
                )
            );
            context.Services.GetSingletonInstance<IObjectAccessor<IServiceProvider>>();
        }
   

        //private void ConfigureAutoMapper()
        //{
        //    Configure<AbpAutoMapperOptions>(options =>
        //    {
        //        options.AddMaps<AppModule>(validate: true);
        //    });

        //}


    }
}
