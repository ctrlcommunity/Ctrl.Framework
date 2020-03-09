Ctrl.Framework
==============

![LICENSE](https://img.shields.io/github/license/ctrlcommunity/Ctrl.Framework?style=plastic)

在线预览地址：http://abp.stackable.cn/

前言
=====

ASP.NET Core3.1、AbpvNext、BootStrap进行构建的快速开发通用型基础开发框架.


目前该框架正在从我前几年写的一个.NETCore快速开发框架中一点点向AbpvNext中迁移，本框架将打造一个AbpvNext快速开发框架。

同时该框架目前正在编码中,同时希望可以有更多的小伙伴一起参与进来.



项目介绍
=====
**Ctrl.Framework**是一个升级版基础权限开发型框架，支持权限管理，代码生成，日志审计等。

![admin](https://raw.githubusercontent.com/ctrlcommunity/ASP.NET-Core-BaseDesign/dev/src/Presentation/Ctrl.Net/wwwroot/images/admin.png)

![admin](https://raw.githubusercontent.com/ctrlcommunity/ASP.NET-Core-BaseDesign/dev/src/Presentation/Ctrl.Net/wwwroot/images/admin-oplog.png)

![admin](https://raw.githubusercontent.com/ctrlcommunity/ASP.NET-Core-BaseDesign/dev/src/Presentation/Ctrl.Net/wwwroot/images/admin-button.png)

# 使用

通过Ctrl.EntityFrameworkCore.DbMigrations,修改**appsettings.json**中连接字符串执行如下命令附加数据库
```cmd
Add-Migration InitCreate

Update-Database
```
本框架默认为MySQL数据库如果您有其他数据库需求那么您可以从如下代码中进行修改

```csharp
  public class CtrlMigrationsDbContextFactory : IDesignTimeDbContextFactory<CtrlMigrationsDbContext>
    {
        public CtrlMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<CtrlMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Test"));

            return new CtrlMigrationsDbContext(builder.Options);
        }
    }
```
```csharp
    [DependsOn(typeof(AbpEntityFrameworkCoreSqlServerModule),
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
                options.UseSqlServer();
            });
        }
    }
```



# 代码贡献

如果您有想法可以加入我们，或者发现本项目中需要改进的代码，欢迎 Fork 并提交 PR！


# LICENSE

MIT

