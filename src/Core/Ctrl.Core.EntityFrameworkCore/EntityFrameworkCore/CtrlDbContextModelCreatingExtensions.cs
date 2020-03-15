using System;
using System.Collections.Generic;
using System.Text;
using Ctrl.Domain.Models.Entities;
using Ctrl.System.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Guids;

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
                b.Property(p => p.Code).HasMaxLength(50);
                b.Property(p => p.Name).HasMaxLength(64);
                b.Property(p => p.Password).HasMaxLength(128);
                b.Property(p => p.Mobile).HasMaxLength(50);
                b.Property(p => p.ImgUrl).HasMaxLength(128);
                b.Property(p => p.Email).HasMaxLength(256);
                b.ConfigureByConvention();
            });
            builder.Entity<SystemMenuButton>(b =>
            {
                b.ToTable("Sys_MenuButton");
                b.HasKey(p => p.Id);
                b.Property(p => p.Name).HasMaxLength(64);
                b.Property(p => p.Icon).HasMaxLength(32);
                b.Property(p => p.Code).HasMaxLength(64);
                b.Property(p => p.Script).HasMaxLength(64);
                b.Property(p => p.Remark).HasMaxLength(512);
                b.ConfigureByConvention();

            });
            builder.Entity<SystemPermission>(b =>
            {
                b.ToTable("Sys_Permission");
                b.HasKey(p => p.Id);
                b.Property(p => p.PrivilegeAccess).HasMaxLength(50);
                b.ConfigureByConvention();
            });
            builder.Entity<SystemArticle>(b =>
            {
                b.ToTable("Sys_Article");
                b.HasKey(p => p.Id);
                b.Property(p => p.Title).HasMaxLength(64);
                b.Property(p => p.Author).HasMaxLength(50);
                b.Property(p => p.Pic).HasMaxLength(100);
                b.Property(p => p.Summary).HasMaxLength(500);
                b.Property(p => p.SeoTitle).HasMaxLength(128);
                b.Property(p => p.SeoDes).HasMaxLength(128);
                b.Property(p => p.SeoKey).HasMaxLength(128);
                b.ConfigureByConvention();
            });

            builder.Entity<SystemExceptionLog>(b =>
            {
                b.ToTable("Sys_ExceptionLog");
                b.HasKey(p => p.Id);
                b.Property(p => p.Message).HasMaxLength(2048);
                b.Property(p => p.InnerException).HasMaxLength(2048);
                b.Property(p => p.ExceptionType).HasMaxLength(512);
                b.Property(p => p.ServerHost).HasMaxLength(128);
                b.Property(p => p.ClientHost).HasMaxLength(128);
                b.Property(p => p.Runtime).HasMaxLength(16);
                b.Property(p => p.RequestUrl).HasMaxLength(128);
                b.Property(p => p.UserAgent).HasMaxLength(1024);
                b.Property(p => p.HttpMethod).HasMaxLength(16);
                b.Property(p => p.CreateUserId).HasMaxLength(50);
                b.Property(p => p.CreateUserCode).HasMaxLength(50);
                b.Property(p => p.CreateUserName).HasMaxLength(50);
                b.Property(p => p.ClientAddress).HasMaxLength(128);
                b.ConfigureByConvention();
            });

            builder.Entity<SystemArticleType>(b =>
            {
                b.ToTable("Sys_ArticleType");
                b.HasKey(p => p.ArticleTypeId);
                b.Property(p => p.ArticleTypeId).HasMaxLength(50);
                b.Property(p => p.ParentId).HasMaxLength(50);
                b.Property(p => p.Name).HasMaxLength(64);
                b.Property(p => p.SeoTitle).HasMaxLength(64);
                b.Property(p => p.SeoKey).HasMaxLength(64);
                b.Property(p => p.SeoDes).HasMaxLength(64);
                b.ConfigureByConvention();
            });

            builder.Entity<SystemConfig>(b =>
            {
                b.ToTable("Sys_Config");
                b.HasKey(p => p.Id);
                b.Property(p => p.Id).HasMaxLength(50);
                b.Property(p => p.SiteName).HasMaxLength(64);
                b.Property(p => p.Keywords).HasMaxLength(64);
                b.Property(p => p.Description).HasMaxLength(128);
                b.ConfigureByConvention();
            });

            builder.Entity<SystemDictionary>(b =>
            {
                b.ToTable("Sys_Dictionary");
                b.HasKey(p => p.DictionaryId);
                b.Property(p => p.DictionaryId).HasMaxLength(50);
                b.Property(p => p.ParentId).HasMaxLength(128);
                b.Property(p => p.Name).HasMaxLength(128);
                b.Property(p => p.Code).HasMaxLength(128);
                b.Property(p => p.Value).HasMaxLength(128);
                b.Property(p => p.Remark).HasMaxLength(512);
                b.ConfigureByConvention();
            });
            builder.Entity<SystemLoginLog>(b =>
            {
                b.ToTable("Sys_LoginLog");
                b.HasKey(p => p.Id);
                b.Property(p => p.IpAddressName).HasMaxLength(50);
                b.Property(p => p.ServerHost).HasMaxLength(50);
                b.Property(p => p.ClientHost).HasMaxLength(50);
                b.Property(p => p.OsVersion).HasMaxLength(128);
                b.Property(p => p.CreateUserId).HasMaxLength(50);
                b.Property(p => p.CreateUserCode).HasMaxLength(50);
                b.Property(p => p.CreateUserName).HasMaxLength(50);
                b.ConfigureByConvention();
            });

            builder.Entity<SystemMenu>(b =>
            {
                b.ToTable("Sys_Menu");
                b.HasKey(p => p.MenuId);
                b.Property(p => p.Code).HasMaxLength(64);
                b.Property(p => p.Name).HasMaxLength(512);
                b.Property(p => p.Icon).HasMaxLength(32);
                b.Property(p => p.Area).HasMaxLength(64);
                b.Property(p => p.Controller).HasMaxLength(128);
                b.Property(p => p.Action).HasMaxLength(128);
                b.Property(p => p.OpenUrl).HasMaxLength(256);
                b.Property(p => p.Remark).HasMaxLength(512);
                b.ConfigureByConvention();
            });
            builder.Entity<SystemMenuButton>(b =>
            {
                b.ToTable("Sys_MenuButton");
                b.HasKey(p => p.Id);
                b.Property(p => p.Name).HasMaxLength(64);
                b.Property(p => p.Icon).HasMaxLength(32);
                b.Property(p => p.Code).HasMaxLength(64);
                b.Property(p => p.Script).HasMaxLength(64);
                b.Property(p => p.Remark).HasMaxLength(512);
                b.ConfigureByConvention();
            });
            builder.Entity<SystemOperateLog>(b =>
            {
                b.ToTable("Sys_OperateLog");
                b.HasKey(p => p.Id);
                b.Property(p => p.Id).HasMaxLength(50);
                b.Property(p => p.ClientHost).HasMaxLength(64);
                b.Property(p => p.ServerHost).HasMaxLength(64);
                b.Property(p => p.RequestType).HasMaxLength(64);
                b.Property(p => p.Url).HasMaxLength(128);
                b.Property(p => p.UrlReferrer).HasMaxLength(1024);
                b.Property(p => p.RequestData).HasMaxLength(1024);
                b.Property(p => p.UserAgent).HasMaxLength(128);
                b.Property(p => p.ControllerName).HasMaxLength(64);
                b.Property(p => p.ActionName).HasMaxLength(64);
                b.Property(p => p.ResponseStatus).HasMaxLength(64);
                b.Property(p => p.Describe).HasMaxLength(512);
                b.Property(p => p.CreateUserId).HasMaxLength(50);
                b.Property(p => p.CreateUserCode).HasMaxLength(256);
                b.Property(p => p.CreateUserName).HasMaxLength(32);
                b.Property(p => p.ActionExecutionTime).HasColumnType("decimal(18,7)");
                b.Property(p => p.ResultExecutionTime).HasColumnType("decimal(18,7)");
                b.ConfigureByConvention();
            });
            builder.Entity<SystemPermission>(b =>
            {
                b.ToTable("Sys_Permission");
                b.HasKey(p => p.Id);
                b.Property(p => p.PrivilegeAccessValue).HasMaxLength(50);
                b.ConfigureByConvention();
            });

            builder.Entity<SystemPermissionUser>(b =>
            {
                b.ToTable("Sys_PermissionUser");
                b.HasNoKey();
                b.Property(p => p.PrivilegeMasterValue).HasMaxLength(50);
                b.Property(p => p.PrivilegeMasterUserId).HasMaxLength(50);
                b.ConfigureByConvention();
            });
            builder.Entity<SystemRole>(b =>
            {
                b.ToTable("Sys_Role");
                b.HasKey(p => p.Id);
                b.Property(p => p.Name).HasMaxLength(64);
                b.Property(p => p.Remark).HasMaxLength(512);
                b.Property(p => p.CreateUserName).HasMaxLength(32);
                b.Property(p => p.UpdateUserName).HasMaxLength(32);
                b.ConfigureByConvention();
            });
            builder.Entity<SystemSqlLog>(b =>
            {
                b.ToTable("Sys_SqlLog");
                b.HasKey(p => p.SqlLogId);
                b.Property(p => p.SqlLogId).HasMaxLength(50);
                b.Property(p => p.CreateUserId).HasMaxLength(50);
                b.Property(p => p.CreateUserCode).HasMaxLength(50);
                b.Property(p => p.CreateUserName).HasMaxLength(50);
                b.Property(p => p.Parameter).HasMaxLength(512);
                b.Property(p => p.ElapsedTime).HasColumnType("decimal(18,6)");
                b.ConfigureByConvention();
            });

            //init Data
            builder.Entity<SystemUser>().HasData(new SystemUser(SimpleGuidGenerator.Instance.Create(), "admin", "admin", "S0JRR96eei0=", null, null, null, null, "系统管理员", true, DateTime.Now, false, @"/images/u.jpg"));

            builder.Entity<SystemMenuButton>().HasData(
                new SystemMenuButton(id: SimpleGuidGenerator.Instance.Create(), menuId: Guid.Parse("6a1969b8-31ee-4bd7-9ca4-4375ddceba73"), name: "新增", icon: "fas fa-plus", script: "btn_add_box()", orderNo: 0, remark: null, createTime: DateTime.Now, code: "xtgl-cdan-SaveMenuButton"),
                new SystemMenuButton(id: SimpleGuidGenerator.Instance.Create(), menuId: Guid.Parse("6a1969b8-31ee-4bd7-9ca4-4375ddceba73"), name: "编辑", icon: "fas fa-edit", script: "btn_edit_box()", orderNo: 0, remark: null, createTime: DateTime.Now, code: null),
                new SystemMenuButton(id: SimpleGuidGenerator.Instance.Create(), menuId: Guid.Parse("40793482-245c-4a1c-8c58-351b6d1b2e7f"), name: "模块权限", icon: "fas fa-user-lock", script: "menuPermission()", orderNo: 0, remark: null, createTime: DateTime.Now, code: "xtgl-jswh-Chosen"),
                new SystemMenuButton(id: SimpleGuidGenerator.Instance.Create(), menuId: Guid.Parse("40793482-245c-4a1c-8c58-351b6d1b2e7f"), name: "按钮权限", icon: "fas fa-user-minus", script: "buttonPermission()", orderNo: 0, remark: null, createTime: DateTime.Now, code: "xtgl-jswh-ChosenButton"),
                new SystemMenuButton(id: SimpleGuidGenerator.Instance.Create(), menuId: Guid.Parse("40793482-245c-4a1c-8c58-351b6d1b2e7f"), name: "新增", icon: "fas fa-plus", script: "btn_add_box()", orderNo: 0, remark: null, createTime: DateTime.Now, code: "xtgl-jswh-SaveRole"),
                new SystemMenuButton(id: SimpleGuidGenerator.Instance.Create(), menuId: Guid.Parse("004e1aeb-5270-42cf-945c-dd7a1f277ced"), name: "新增", icon: "fas fa-plus", script: "btn_add_box()", orderNo: 0, remark: null, createTime: DateTime.Now, code: "xtgl-xtyh-SaveUser"),
                new SystemMenuButton(id: SimpleGuidGenerator.Instance.Create(), menuId: Guid.Parse("fc239bef-8bfa-48a4-ad99-150a1b1a017e"), name: "新增", icon: "fas fa-plus", script: "btn_add_box()", orderNo: 0, remark: null, createTime: DateTime.Now, code: "xtgl-mkwh-SaveMenu"),
                new SystemMenuButton(id: SimpleGuidGenerator.Instance.Create(), menuId: Guid.Parse("fc239bef-8bfa-48a4-ad99-150a1b1a017e"), name: "编辑", icon: "fas fa-edit", script: "btn_edit_box()", orderNo: 0, remark: null, createTime: DateTime.Now, code: "xtgl-mkwh-SaveMenu"),
                new SystemMenuButton(id: SimpleGuidGenerator.Instance.Create(), menuId: Guid.Parse("8ba0133b-3c19-4bca-a86d-527463ff4fd3"), name: "数据分析", icon: "fas fa-chart-pie", script: "btn_data_box()", orderNo: 0, remark: null, createTime: DateTime.Now, code: null),
                new SystemMenuButton(id: SimpleGuidGenerator.Instance.Create(), menuId: Guid.Parse("8f9d406f-70f0-4a11-9380-616fe2395c9e"), name: "新增", icon: "fas fa-plus", script: "btn_add_box()", orderNo: 0, remark: null, createTime: DateTime.Now, code: "xtgl-zffs-SavePays"),
                new SystemMenuButton(id: SimpleGuidGenerator.Instance.Create(), menuId: Guid.Parse("93967f84-2598-4aca-9a50-5c4a7719820f"), name: "新增", icon: "fas fa-plus", script: "btn_add_box()", orderNo: 0, remark: null, createTime: DateTime.Now, code: "xtgl-wzlx-SaveArticleType"),
                new SystemMenuButton(id: SimpleGuidGenerator.Instance.Create(), menuId: Guid.Parse("93967f84-2598-4aca-9a50-5c4a7719820f"), name: "编辑", icon: "fas fa-edit", script: "btn_edit_box()", orderNo: 0, remark: null, createTime: DateTime.Now, code: null),
                new SystemMenuButton(id: SimpleGuidGenerator.Instance.Create(), menuId: Guid.Parse("e0d226e9-6253-42c7-abbd-65111f73d406"), name: "新增", icon: "fas fa-plus", script: "btn_add_box()", orderNo: 0, remark: null, createTime: DateTime.Now, code: null),
                new SystemMenuButton(id: SimpleGuidGenerator.Instance.Create(), menuId: Guid.Parse("e0d226e9-6253-42c7-abbd-65111f73d406"), name: "编辑", icon: "fas fa-plus", script: "btn_edit_box()", orderNo: 0, remark: null, createTime: DateTime.Now, code: "xtgl-wz-SaveArticle"),
                new SystemMenuButton(id: SimpleGuidGenerator.Instance.Create(), menuId: Guid.Parse("fc239bef-8bfa-48a4-ad99-150a1b1a017e"), name: "删除", icon: "far fa-trash-alt", script: "btn_edit_box()", orderNo: 0, remark: null, createTime: DateTime.Now, code: "xtgl-mkwh-DeleteMenu"),
                new SystemMenuButton(id: SimpleGuidGenerator.Instance.Create(), menuId: Guid.Parse("af66d9a6-3567-4267-a7cc-a79982b53fd0"), name: "新增", icon: "fas fa-plus", script: "btn_add_box()", orderNo: 0, remark: null, createTime: DateTime.Now, code: "xtgl-zdgl-SaveSystemDictionary"),
                new SystemMenuButton(id: SimpleGuidGenerator.Instance.Create(), menuId: Guid.Parse("8f9d406f-70f0-4a11-9380-616fe2395c9e"), name: "编辑", icon: "fas fa-edit", script: "btn_edit_box()", orderNo: 0, remark: null, createTime: DateTime.Now, code: "xtgl-cdan-SaveMenuButton"),
                new SystemMenuButton(id: SimpleGuidGenerator.Instance.Create(), menuId: Guid.Parse("af66d9a6-3567-4267-a7cc-a79982b53fd0"), name: "编辑", icon: "fas fa-edit", script: "btn_edit_box()", orderNo: 0, remark: null, createTime: DateTime.Now, code: "xtgl-zdgl-SaveSystemDictionary"),
                new SystemMenuButton(id: SimpleGuidGenerator.Instance.Create(), menuId: Guid.Parse("271fade9-0e28-411b-ad92-7fc9a3b57990"), name: "新增", icon: "fas fa-plus", script: "btn_add_box()", orderNo: 0, remark: null, createTime: DateTime.Now, code: "ljgl-ljlx-SaveSystemLinkType"),
                new SystemMenuButton(id: SimpleGuidGenerator.Instance.Create(), menuId: Guid.Parse("271fade9-0e28-411b-ad92-7fc9a3b57990"), name: "编辑", icon: "fas fa-edit", script: "btn_add_box()", orderNo: 0, remark: null, createTime: DateTime.Now, code: "ljgl-ljlx-SaveSystemLinkType"),
                new SystemMenuButton(id: SimpleGuidGenerator.Instance.Create(), menuId: Guid.Parse("e0d226e9-6253-42c7-abbd-65111f73d406"), name: "删除", icon: "fas fa-trash-alt", script: "btn_delete_box()", orderNo: 0, remark: null, createTime: DateTime.Now, code: "wzgl-wzlb-Delete")
                );

            builder.Entity<SystemMenu>().HasData(
                new SystemMenu(menuId: Guid.Parse("fc239bef-8bfa-48a4-ad99-150a1b1a017e"), parentId: Guid.Parse("7c9c9976-336c-443a-8a16-88574e887905"), code: "", name: "模块维护", openType: null, icon: "fas fa-list", area: "SysManage", controller: "Menu", action: "Index", openUrl: "/SysManage/Menu/Index", remark: null, orderNo: 0, canbeDelete: false, isFreeze: false, isShowMenu: true),
                new SystemMenu(menuId: Guid.Parse("26d560a2-c68a-4796-afcd-29ddce64d1f8"), parentId: Guid.Parse("9d804188-dded-418f-99c4-c9ee145673fb"), code: "", name: "系统设置", openType: null, icon: "far fa-sun", area: "", controller: "", action: "", openUrl: "", remark: null, orderNo: 0, canbeDelete: false, isFreeze: false, isShowMenu: true),
                new SystemMenu(menuId: Guid.Parse("52ff87fd-aa44-43e8-a8c2-2ed8be1d2511"), parentId: Guid.Parse("b75ce484-8d7a-469e-8661-565585d302e3"), code: "", name: "错误日志", openType: null, icon: "fas fa-bug", area: "SysManage", controller: "Log", action: "ExceptionLog", openUrl: "/SysManage/Log/ExceptionLog", remark: null, orderNo: 0, canbeDelete: false, isFreeze: false, isShowMenu: true),
                new SystemMenu(menuId: Guid.Parse("d19e918c-0694-437e-b604-b989a5668695"), parentId: Guid.Parse("b75ce484-8d7a-469e-8661-565585d302e3"), code: "", name: "登录日志", openType: null, icon: "fas fa-bug", area: "SysManage", controller: "Log", action: "Login", openUrl: "/SysManage/Log/Login", remark: null, orderNo: 0, canbeDelete: false, isFreeze: false, isShowMenu: true),
                new SystemMenu(menuId: Guid.Parse("40793482-245c-4a1c-8c58-351b6d1b2e7f"), parentId: Guid.Parse("65294c4a-6bc4-49e7-8169-ffa7d628a8f6"), code: "", name: "角色维护", openType: null, icon: "fas fa-users", area: "SysManage", controller: "Role", action: "Index", openUrl: "/SysManage/Role/Index", remark: null, orderNo: 0, canbeDelete: false, isFreeze: false, isShowMenu: true),
                new SystemMenu(menuId: Guid.Parse("6a1969b8-31ee-4bd7-9ca4-4375ddceba73"), parentId: Guid.Parse("7c9c9976-336c-443a-8a16-88574e887905"), code: "", name: "按钮管理", openType: null, icon: "fas fa-cubes", area: "SysManage", controller: "MenuButton", action: "Index", openUrl: "/SysManage/MenuButton/Index", remark: null, orderNo: 0, canbeDelete: false, isFreeze: false, isShowMenu: true),
                new SystemMenu(menuId: Guid.Parse("8ba0133b-3c19-4bca-a86d-527463ff4fd3"), parentId: Guid.Parse("b75ce484-8d7a-469e-8661-565585d302e3"), code: "", name: "操作日志", openType: null, icon: "fas fa-eye", area: "SysManage", controller: "Log", action: "OperationLog", openUrl: "/SysManage/Log/OperationLog", remark: null, orderNo: 0, canbeDelete: false, isFreeze: false, isShowMenu: true),
                new SystemMenu(menuId: Guid.Parse("b75ce484-8d7a-469e-8661-565585d302e3"), parentId: Guid.Parse("9d804188-dded-418f-99c4-c9ee145673fb"), code: "", name: "系统日志", openType: null, icon: "fas fa-paste", area: "", controller: "", action: "", openUrl: "", remark: null, orderNo: 0, canbeDelete: false, isFreeze: false, isShowMenu: true),
                new SystemMenu(menuId: Guid.Parse("93967f84-2598-4aca-9a50-5c4a7719820f"), parentId: Guid.Parse("2986d468-ffe7-4a52-ab24-a594f5f79f33"), code: "", name: "文章类别", openType: null, icon: "fas fa-th-list", area: "SysManage", controller: "ArticleType", action: "Index", openUrl: "/SysManage/ArticleType/Index", remark: null, orderNo: 0, canbeDelete: false, isFreeze: false, isShowMenu: true),
                new SystemMenu(menuId: Guid.Parse("8f9d406f-70f0-4a11-9380-616fe2395c9e"), parentId: Guid.Parse("9d804188-dded-418f-99c4-c9ee145673fb"), code: "", name: "支付方式", openType: null, icon: "fab fa-apple-pay", area: "sysManage", controller: "Pays", action: "Index", openUrl: "/SysManage/Pays/Index", remark: null, orderNo: 0, canbeDelete: false, isFreeze: false, isShowMenu: true),
                new SystemMenu(menuId: Guid.Parse("e0d226e9-6253-42c7-abbd-65111f73d406"), parentId: Guid.Parse("2986d468-ffe7-4a52-ab24-a594f5f79f33"), code: "", name: "文章列表", openType: null, icon: "fas fa-align-justify", area: "SysManage", controller: "Article", action: "Index", openUrl: "/SysManage/Article/Index", remark: null, orderNo: 0, canbeDelete: false, isFreeze: false, isShowMenu: true),
                new SystemMenu(menuId: Guid.Parse("271fade9-0e28-411b-ad92-7fc9a3b57990"), parentId: Guid.Parse("517d48c3-8551-4d2d-8a0c-3f060077b236"), code: "", name: "链接类型", openType: null, icon: "fas fa-external-link-alt", area: "SysManage", controller: "LinkType", action: "Index", openUrl: "/SysManage/LinkType/Index", remark: null, orderNo: 0, canbeDelete: false, isFreeze: false, isShowMenu: true),
                new SystemMenu(menuId: Guid.Parse("7c9c9976-336c-443a-8a16-88574e887905"), parentId: Guid.Parse("9d804188-dded-418f-99c4-c9ee145673fb"), code: "", name: "权限信息", openType: null, icon: "fas fa-desktop", area: "", controller: "", action: "", openUrl: "", remark: null, orderNo: 0, canbeDelete: false, isFreeze: false, isShowMenu: true),
                new SystemMenu(menuId: Guid.Parse("89532468-de42-4f17-b681-8db668c5e50c"), parentId: Guid.Parse("9d804188-dded-418f-99c4-c9ee145673fb"), code: "", name: "敏捷开发", openType: null, icon: "fas fa-handshake", area: "", controller: "", action: "", openUrl: "", remark: null, orderNo: 0, canbeDelete: false, isFreeze: false, isShowMenu: true),
                new SystemMenu(menuId: Guid.Parse("de921f49-b63d-47c8-95b1-93d13ecab2ca"), parentId: Guid.Parse("26d560a2-c68a-4796-afcd-29ddce64d1f8"), code: "", name: "系统配置", openType: null, icon: "fas fa-cogs", area: "SysManage", controller: "Config", action: "Index", openUrl: "/SysManage/Config/Index", remark: null, orderNo: 0, canbeDelete: false, isFreeze: false, isShowMenu: true),
                new SystemMenu(menuId: Guid.Parse("2986d468-ffe7-4a52-ab24-a594f5f79f33"), parentId: Guid.Parse("00000000-0000-0000-0000-000000000000"), code: "", name: "文章管理", openType: null, icon: "fas fa-book-reader", area: "", controller: "", action: "", openUrl: "", remark: null, orderNo: 0, canbeDelete: false, isFreeze: false, isShowMenu: true),
                new SystemMenu(menuId: Guid.Parse("af66d9a6-3567-4267-a7cc-a79982b53fd0"), parentId: Guid.Parse("26d560a2-c68a-4796-afcd-29ddce64d1f8"), code: "", name: "字典管理", openType: null, icon: "fas fa-book", area: "SysManage", controller: "Dictionary", action: "Index", openUrl: "/SysManage/Log/Login", remark: null, orderNo: 0, canbeDelete: false, isFreeze: false, isShowMenu: true),
                new SystemMenu(menuId: Guid.Parse("9d804188-dded-418f-99c4-c9ee145673fb"), parentId: Guid.Parse("00000000-0000-0000-0000-000000000000"), code: "", name: "系统管理", openType: null, icon: "fas fa-cog", area: "", controller: "", action: "", openUrl: "", remark: null, orderNo: 0, canbeDelete: false, isFreeze: false, isShowMenu: true),
                new SystemMenu(menuId: Guid.Parse("004e1aeb-5270-42cf-945c-dd7a1f277ced"), parentId: Guid.Parse("65294c4a-6bc4-49e7-8169-ffa7d628a8f6"), code: "", name: "系统用户", openType: null, icon: "fas fa-user", area: "SysManage", controller: "User", action: "Index", openUrl: "/SysManage/User/Index", remark: null, orderNo: 0, canbeDelete: false, isFreeze: false, isShowMenu: true),
                new SystemMenu(menuId: Guid.Parse("52453f3e-02e7-47d0-a5c8-fcaa5e26005d"), parentId: Guid.Parse("89532468-de42-4f17-b681-8db668c5e50c"), code: "", name: "代码生成", openType: null, icon: "fas fa-code", area: "SysManage", controller: "CodeGeneration", action: "Index", openUrl: "/SysManage/CodeGeneration/Index", remark: null, orderNo: 0, canbeDelete: false, isFreeze: false, isShowMenu: true),
                new SystemMenu(menuId: Guid.Parse("65294c4a-6bc4-49e7-8169-ffa7d628a8f6"), parentId: Guid.Parse("00000000-0000-0000-0000-000000000000"), code: "", name: "用户管理", openType: null, icon: "fas fa-user", area: "", controller: "", action: "", openUrl: "", remark: null, orderNo: 0, canbeDelete: false, isFreeze: false, isShowMenu: true)
            );

        }
    }
}
