Ctrl.Framework
==============


[![Build Status](https://dev.azure.com/HueiFeng/Ctrl.Framework/_apis/build/status/ctrlcommunity.Ctrl.Framework?branchName=master)](https://dev.azure.com/HueiFeng/Ctrl.Framework/_build/latest?definitionId=15&branchName=master)
![LICENSE](https://img.shields.io/github/license/ctrlcommunity/Ctrl.Framework?color=%230366d6)
![language](https://img.shields.io/badge/language-csharp-green.svg)



在线预览地址：http://abp.stackable.cn/

服务器配置

|  系统   | CPU  | 内存 |
|  ----  | ----  | ---- |
| CentOS 7  | 1核 | 2G |

前言
=====

ASP.NET Core3.1、AbpvNext、BootStrap进行构建的快速开发通用型基础开发框架.


目前该框架正在从我前几年写的一个.NETCore快速开发框架中一点点向AbpvNext中迁移，本框架将打造一个AbpvNext快速开发框架。

同时该框架目前正在编码中,同时希望可以有更多的小伙伴一起参与进来.



项目介绍
=====
**Ctrl.Framework**将打造一个简单快速适合中小型企业的快速开发框架

![](https://imgkr.cn-bj.ufileos.com/0299c942-8cc3-4b8f-96b0-02f474d89e53.png)

![](https://imgkr.cn-bj.ufileos.com/1d96f50f-8417-4de6-8b96-d161b714b46a.png)



# 使用

通过CtrlCloud.Framework.EntityFrameworkCore.DbMigrations,修改**appsettings.json**中连接字符串执行如下命令附加数据库
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

[MIT](https://github.com/ctrlcommunity/Ctrl.Framework/blob/master/LICENSE)

