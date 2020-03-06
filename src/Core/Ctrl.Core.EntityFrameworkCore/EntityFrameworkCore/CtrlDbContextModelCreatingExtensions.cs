using System;
using System.Collections.Generic;
using System.Text;
using Ctrl.Domain.Models.Entities;
using Ctrl.System.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Ctrl.Core.EntityFrameworkCore.EntityFrameworkCore
{
    public static class CtrlDbContextModelCreatingExtensions
    {
        public static void ConfigureCtrl(this ModelBuilder builder)
        {
            builder.Entity<SystemUser>(b =>
            {
                b.ToTable("Sys_User");
                b.HasKey(p => p.Id);
                b.ConfigureByConvention();

            });
            builder.Entity<SystemMenuButton>(b =>
            {
                b.ToTable("Sys_MenuButton");
                b.HasKey(p => p.Id);
                b.ConfigureByConvention();

            });
            builder.Entity<SystemPermission>(b =>
            {
                b.ToTable("Sys_Permission");
                b.HasKey(p => p.Id);
                b.ConfigureByConvention();
            });
            builder.Entity<SystemArticle>(b =>
            {
                b.ToTable("Sys_Article");
                b.HasKey(p => p.Id);
                b.ConfigureByConvention();
            });

            builder.Entity<SystemExceptionLog>(b =>
            {
                b.ToTable("Sys_ExceptionLog");
                b.HasKey(p => p.Id);
                b.ConfigureByConvention();
            });

            builder.Entity<SystemArticleType>(b =>
            {
                b.ToTable("Sys_ArticleType");
                b.HasKey(p => p.ArticleTypeId);
                b.ConfigureByConvention();
            });

            builder.Entity<SystemConfig>(b =>
            {
                b.ToTable("Sys_Config");
                b.HasKey(p => p.Id);
                b.ConfigureByConvention();
            });

            builder.Entity<SystemDictionary>(b =>
            {
                b.ToTable("Sys_Dictionary");
                b.HasKey(p => p.DictionaryId);
                b.ConfigureByConvention();
            });
            builder.Entity<SystemLoginLog>(b =>
            {
                b.ToTable("Sys_LoginLog");
                b.HasKey(p => p.LoginLogId);
                b.ConfigureByConvention();
            });

            builder.Entity<SystemMenu>(b =>
            {
                b.ToTable("Sys_Menu");
                b.HasKey(p => p.MenuId);
                b.ConfigureByConvention();
            });
            builder.Entity<SystemMenuButton>(b =>
            {
                b.ToTable("Sys_MenuButton");
                b.HasKey(p => p.Id);
                b.ConfigureByConvention();
            });
            builder.Entity<SystemOperateLog>(b =>
            {
                b.ToTable("Sys_OperateLog");
                b.HasKey(p => p.OperateLogId);
                b.ConfigureByConvention();
            });
            builder.Entity<SystemPermission>(b =>
            {
                b.ToTable("Sys_Permission");
                b.HasKey(p => p.Id);
                b.ConfigureByConvention();
            });

            builder.Entity<SystemPermissionUser>(b =>
            {
                b.ToTable("Sys_PermissionUser");
                b.HasNoKey();
                b.ConfigureByConvention();
            });
            builder.Entity<SystemRole>(b =>
            {
                b.ToTable("Sys_Role");
                b.HasKey(p => p.RoleId);
                b.ConfigureByConvention();
            });
            builder.Entity<SystemSqlLog>(b =>
            {
                b.ToTable("Sys_SqlLog");
                b.HasKey(p => p.SqlLogId);
                b.ConfigureByConvention();
            });
            builder.Entity<SystemUser>(b =>
            {
                b.ToTable("Sys_User");
                b.HasKey(p => p.Id);
                b.ConfigureByConvention(); ;
            });
        }
    }
}
