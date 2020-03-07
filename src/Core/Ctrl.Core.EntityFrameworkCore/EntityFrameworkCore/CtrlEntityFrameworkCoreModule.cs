using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Guids;
using Volo.Abp.Modularity;

namespace Ctrl.Core.EntityFrameworkCore.EntityFrameworkCore
{
    [DependsOn(typeof(AbpEntityFrameworkCoreMySQLModule),
        typeof(AbpGuidsModule))]
    public class CtrlEntityFrameworkCoreModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<CtrlDbContext>(options =>
            {
                /* Remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots */
                options.AddDefaultRepositories(includeAllEntities: true);
            });

            Configure<AbpDbContextOptions>(options =>
            {
                /* The main point to change your DBMS.
                 * See also StackableMigrationsDbContextFactory for EF Core tooling. */
                options.UseMySQL();
            });
        }
    }
}
