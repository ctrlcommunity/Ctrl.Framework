using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ctrl.EntityFrameworkCore.DbMigrations.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sys_Article",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 64, nullable: true),
                    ArticleTypeId = table.Column<Guid>(nullable: false),
                    Author = table.Column<string>(maxLength: 50, nullable: true),
                    IsShow = table.Column<bool>(nullable: false),
                    OrderNo = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    Pic = table.Column<string>(maxLength: 100, nullable: true),
                    Summary = table.Column<string>(maxLength: 500, nullable: true),
                    Contents = table.Column<string>(nullable: true),
                    Counter = table.Column<int>(nullable: false),
                    SeoTitle = table.Column<string>(maxLength: 128, nullable: true),
                    SeoDes = table.Column<string>(maxLength: 128, nullable: true),
                    SeoKey = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Article", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_ArticleType",
                columns: table => new
                {
                    ArticleTypeId = table.Column<Guid>(maxLength: 50, nullable: false),
                    ParentId = table.Column<Guid>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: true),
                    OrderNo = table.Column<int>(nullable: false),
                    IsShow = table.Column<bool>(nullable: false),
                    SeoTitle = table.Column<string>(maxLength: 64, nullable: true),
                    SeoKey = table.Column<string>(maxLength: 64, nullable: true),
                    SeoDes = table.Column<string>(maxLength: 64, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_ArticleType", x => x.ArticleTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Sys_Config",
                columns: table => new
                {
                    Id = table.Column<Guid>(maxLength: 50, nullable: false),
                    SiteName = table.Column<string>(maxLength: 64, nullable: true),
                    Keywords = table.Column<string>(maxLength: 64, nullable: true),
                    Description = table.Column<string>(maxLength: 128, nullable: true),
                    CopyRight = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Config", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_Dictionary",
                columns: table => new
                {
                    DictionaryId = table.Column<Guid>(maxLength: 50, nullable: false),
                    ParentId = table.Column<Guid>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: true),
                    Code = table.Column<string>(maxLength: 128, nullable: true),
                    Value = table.Column<string>(maxLength: 128, nullable: true),
                    IsFreeze = table.Column<bool>(nullable: false),
                    OrderNo = table.Column<int>(nullable: false),
                    Remark = table.Column<string>(maxLength: 512, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Dictionary", x => x.DictionaryId);
                });

            migrationBuilder.CreateTable(
                name: "Sys_ExceptionLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Message = table.Column<string>(maxLength: 2048, nullable: true),
                    StackTrace = table.Column<string>(nullable: true),
                    InnerException = table.Column<string>(maxLength: 2048, nullable: true),
                    ExceptionType = table.Column<string>(maxLength: 512, nullable: true),
                    ServerHost = table.Column<string>(maxLength: 128, nullable: true),
                    ClientHost = table.Column<string>(maxLength: 128, nullable: true),
                    Runtime = table.Column<string>(maxLength: 16, nullable: true),
                    RequestUrl = table.Column<string>(maxLength: 128, nullable: true),
                    RequestData = table.Column<string>(nullable: true),
                    UserAgent = table.Column<string>(maxLength: 1024, nullable: true),
                    HttpMethod = table.Column<string>(maxLength: 16, nullable: true),
                    CreateUserId = table.Column<string>(maxLength: 50, nullable: true),
                    CreateUserCode = table.Column<string>(maxLength: 50, nullable: true),
                    CreateUserName = table.Column<string>(maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ClientAddress = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_ExceptionLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_LoginLog",
                columns: table => new
                {
                    LoginLogId = table.Column<string>(maxLength: 50, nullable: false),
                    IpAddressName = table.Column<string>(maxLength: 50, nullable: true),
                    ServerHost = table.Column<string>(maxLength: 50, nullable: true),
                    ClientHost = table.Column<string>(maxLength: 50, nullable: true),
                    UserAgent = table.Column<string>(nullable: true),
                    OsVersion = table.Column<string>(maxLength: 128, nullable: true),
                    LoginTime = table.Column<DateTime>(nullable: false),
                    CreateUserId = table.Column<string>(maxLength: 50, nullable: true),
                    CreateUserCode = table.Column<string>(maxLength: 50, nullable: true),
                    CreateUserName = table.Column<string>(maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_LoginLog", x => x.LoginLogId);
                });

            migrationBuilder.CreateTable(
                name: "Sys_Menu",
                columns: table => new
                {
                    MenuId = table.Column<Guid>(nullable: false),
                    ParentId = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(maxLength: 64, nullable: true),
                    Name = table.Column<string>(maxLength: 512, nullable: true),
                    OpenType = table.Column<byte[]>(nullable: true),
                    Icon = table.Column<string>(maxLength: 32, nullable: true),
                    Area = table.Column<string>(maxLength: 64, nullable: true),
                    Controller = table.Column<string>(maxLength: 128, nullable: true),
                    Action = table.Column<string>(maxLength: 128, nullable: true),
                    OpenUrl = table.Column<string>(maxLength: 256, nullable: true),
                    Remark = table.Column<string>(maxLength: 512, nullable: true),
                    OrderNo = table.Column<int>(nullable: false),
                    CanbeDelete = table.Column<bool>(nullable: false),
                    IsFreeze = table.Column<bool>(nullable: false),
                    IsShowMenu = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Menu", x => x.MenuId);
                });

            migrationBuilder.CreateTable(
                name: "Sys_MenuButton",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MenuId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: true),
                    Icon = table.Column<string>(maxLength: 32, nullable: true),
                    Script = table.Column<string>(maxLength: 64, nullable: true),
                    OrderNo = table.Column<int>(nullable: false),
                    Remark = table.Column<string>(maxLength: 512, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_MenuButton", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_OperateLog",
                columns: table => new
                {
                    OperateLogId = table.Column<string>(maxLength: 50, nullable: false),
                    ClientHost = table.Column<string>(maxLength: 64, nullable: true),
                    ServerHost = table.Column<string>(maxLength: 64, nullable: true),
                    RequestContentLength = table.Column<int>(nullable: false),
                    RequestType = table.Column<string>(maxLength: 64, nullable: true),
                    Url = table.Column<string>(maxLength: 128, nullable: true),
                    UrlReferrer = table.Column<string>(maxLength: 12, nullable: true),
                    RequestData = table.Column<string>(maxLength: 1024, nullable: true),
                    UserAgent = table.Column<string>(maxLength: 128, nullable: true),
                    ControllerName = table.Column<string>(maxLength: 64, nullable: true),
                    ActionName = table.Column<string>(maxLength: 64, nullable: true),
                    ActionExecutionTime = table.Column<decimal>(type: "decimal(18,7)", nullable: false),
                    ResultExecutionTime = table.Column<decimal>(type: "decimal(18,7)", nullable: false),
                    ResponseStatus = table.Column<string>(maxLength: 64, nullable: true),
                    Describe = table.Column<string>(maxLength: 512, nullable: true),
                    CreateUserId = table.Column<string>(maxLength: 50, nullable: true),
                    CreateUserCode = table.Column<string>(maxLength: 256, nullable: true),
                    CreateUserName = table.Column<string>(maxLength: 32, nullable: true),
                    CreateTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_OperateLog", x => x.OperateLogId);
                });

            migrationBuilder.CreateTable(
                name: "Sys_Permission",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PrivilegeAccess = table.Column<short>(maxLength: 50, nullable: false),
                    PrivilegeMasterValue = table.Column<Guid>(nullable: false),
                    PrivilegeAccessValue = table.Column<string>(maxLength: 50, nullable: true),
                    PrivilegeMaster = table.Column<short>(nullable: false),
                    PrivilegeMenuId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_PermissionUser",
                columns: table => new
                {
                    PrivilegeMaster = table.Column<int>(nullable: false),
                    PrivilegeMasterValue = table.Column<string>(maxLength: 50, nullable: true),
                    PrivilegeMasterUserId = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Sys_Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: true),
                    State = table.Column<int>(nullable: false),
                    CanbeDelete = table.Column<bool>(nullable: false),
                    OrderNo = table.Column<int>(nullable: false),
                    Remark = table.Column<string>(maxLength: 512, nullable: true),
                    IsFreeze = table.Column<bool>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateUserId = table.Column<Guid>(nullable: false),
                    CreateUserName = table.Column<string>(maxLength: 32, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<Guid>(nullable: false),
                    UpdateUserName = table.Column<string>(maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_SqlLog",
                columns: table => new
                {
                    SqlLogId = table.Column<string>(maxLength: 50, nullable: false),
                    CreateUserId = table.Column<string>(maxLength: 50, nullable: true),
                    CreateUserCode = table.Column<string>(maxLength: 50, nullable: true),
                    CreateUserName = table.Column<string>(maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    OperateSql = table.Column<string>(nullable: true),
                    EndDateTime = table.Column<DateTime>(nullable: false),
                    ElapsedTime = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Parameter = table.Column<string>(maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_SqlLog", x => x.SqlLogId);
                });

            migrationBuilder.CreateTable(
                name: "Sys_User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 64, nullable: true),
                    Password = table.Column<string>(maxLength: 128, nullable: true),
                    Mobile = table.Column<string>(maxLength: 50, nullable: true),
                    ImgUrl = table.Column<string>(maxLength: 128, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    FirstVisitTime = table.Column<DateTime>(nullable: true),
                    LastVisitTime = table.Column<DateTime>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    IsFreeze = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Sys_Menu",
                columns: new[] { "MenuId", "Action", "Area", "CanbeDelete", "Code", "Controller", "Icon", "IsFreeze", "IsShowMenu", "Name", "OpenType", "OpenUrl", "OrderNo", "ParentId", "Remark" },
                values: new object[,]
                {
                    { new Guid("65294c4a-6bc4-49e7-8169-ffa7d628a8f6"), "", "", false, "", "", "fas fa-user", false, true, "用户管理", null, "", 0, new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("52453f3e-02e7-47d0-a5c8-fcaa5e26005d"), "Index", "SysManage", false, "", "CodeGeneration", "fas fa-code", false, true, "代码生成", null, "/SysManage/CodeGeneration/Index", 0, new Guid("89532468-de42-4f17-b681-8db668c5e50c"), null },
                    { new Guid("004e1aeb-5270-42cf-945c-dd7a1f277ced"), "Index", "SysManage", false, "", "User", "fas fa-user", false, true, "系统用户", null, "/SysManage/User/Index", 0, new Guid("65294c4a-6bc4-49e7-8169-ffa7d628a8f6"), null },
                    { new Guid("9d804188-dded-418f-99c4-c9ee145673fb"), "", "", false, "", "", "fas fa-cog", false, true, "系统管理", null, "", 0, new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("af66d9a6-3567-4267-a7cc-a79982b53fd0"), "Index", "SysManage", false, "", "Dictionary", "fas fa-book", false, true, "字典管理", null, "/SysManage/Log/Login", 0, new Guid("26d560a2-c68a-4796-afcd-29ddce64d1f8"), null },
                    { new Guid("2986d468-ffe7-4a52-ab24-a594f5f79f33"), "", "", false, "", "", "fas fa-book-reader", false, true, "文章管理", null, "", 0, new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("89532468-de42-4f17-b681-8db668c5e50c"), "", "", false, "", "", "fas fa-handshake", false, true, "敏捷开发", null, "", 0, new Guid("9d804188-dded-418f-99c4-c9ee145673fb"), null },
                    { new Guid("7c9c9976-336c-443a-8a16-88574e887905"), "", "", false, "", "", "fas fa-desktop", false, true, "权限信息", null, "", 0, new Guid("9d804188-dded-418f-99c4-c9ee145673fb"), null },
                    { new Guid("271fade9-0e28-411b-ad92-7fc9a3b57990"), "Index", "SysManage", false, "", "LinkType", "fas fa-external-link-alt", false, true, "链接类型", null, "/SysManage/LinkType/Index", 0, new Guid("517d48c3-8551-4d2d-8a0c-3f060077b236"), null },
                    { new Guid("e0d226e9-6253-42c7-abbd-65111f73d406"), "Index", "SysManage", false, "", "Article", "fas fa-align-justify", false, true, "文章列表", null, "/SysManage/Article/Index", 0, new Guid("2986d468-ffe7-4a52-ab24-a594f5f79f33"), null },
                    { new Guid("de921f49-b63d-47c8-95b1-93d13ecab2ca"), "Index", "SysManage", false, "", "Config", "fas fa-cogs", false, true, "系统配置", null, "/SysManage/Config/Index", 0, new Guid("26d560a2-c68a-4796-afcd-29ddce64d1f8"), null },
                    { new Guid("93967f84-2598-4aca-9a50-5c4a7719820f"), "Index", "SysManage", false, "", "ArticleType", "fas fa-th-list", false, true, "文章类别", null, "/SysManage/ArticleType/Index", 0, new Guid("2986d468-ffe7-4a52-ab24-a594f5f79f33"), null },
                    { new Guid("8f9d406f-70f0-4a11-9380-616fe2395c9e"), "Index", "sysManage", false, "", "Pays", "fab fa-apple-pay", false, true, "支付方式", null, "/SysManage/Pays/Index", 0, new Guid("9d804188-dded-418f-99c4-c9ee145673fb"), null },
                    { new Guid("26d560a2-c68a-4796-afcd-29ddce64d1f8"), "", "", false, "", "", "far fa-sun", false, true, "系统设置", null, "", 0, new Guid("9d804188-dded-418f-99c4-c9ee145673fb"), null },
                    { new Guid("52ff87fd-aa44-43e8-a8c2-2ed8be1d2511"), "ExceptionLog", "SysManage", false, "", "Log", "fas fa-bug", false, true, "错误日志", null, "/SysManage/Log/ExceptionLog", 0, new Guid("b75ce484-8d7a-469e-8661-565585d302e3"), null },
                    { new Guid("d19e918c-0694-437e-b604-b989a5668695"), "Login", "SysManage", false, "", "Log", "fas fa-bug", false, true, "登录日志", null, "/SysManage/Log/Login", 0, new Guid("b75ce484-8d7a-469e-8661-565585d302e3"), null },
                    { new Guid("fc239bef-8bfa-48a4-ad99-150a1b1a017e"), "Index", "SysManage", false, "", "Menu", "fas fa-list", false, true, "模块维护", null, "/SysManage/Menu/Index", 0, new Guid("7c9c9976-336c-443a-8a16-88574e887905"), null },
                    { new Guid("6a1969b8-31ee-4bd7-9ca4-4375ddceba73"), "Index", "SysManage", false, "", "MenuButton", "fas fa-cubes", false, true, "按钮管理", null, "/SysManage/MenuButton/Index", 0, new Guid("7c9c9976-336c-443a-8a16-88574e887905"), null },
                    { new Guid("8ba0133b-3c19-4bca-a86d-527463ff4fd3"), "OperationLog", "SysManage", false, "", "Log", "fas fa-eye", false, true, "操作日志", null, "/SysManage/Log/OperationLog", 0, new Guid("b75ce484-8d7a-469e-8661-565585d302e3"), null },
                    { new Guid("b75ce484-8d7a-469e-8661-565585d302e3"), "", "", false, "", "", "fas fa-paste", false, true, "系统日志", null, "", 0, new Guid("9d804188-dded-418f-99c4-c9ee145673fb"), null },
                    { new Guid("40793482-245c-4a1c-8c58-351b6d1b2e7f"), "Index", "SysManage", false, "", "Role", "fas fa-users", false, true, "角色维护", null, "/SysManage/Role/Index", 0, new Guid("65294c4a-6bc4-49e7-8169-ffa7d628a8f6"), null }
                });

            migrationBuilder.InsertData(
                table: "Sys_MenuButton",
                columns: new[] { "Id", "Code", "CreateTime", "Icon", "MenuId", "Name", "OrderNo", "Remark", "Script" },
                values: new object[,]
                {
                    { new Guid("cb5da919-ffab-4bc9-bafd-ff7035c64b80"), "xtgl-wzlx-SaveArticleType", new DateTime(2020, 3, 11, 9, 57, 10, 485, DateTimeKind.Local).AddTicks(7074), "fas fa-plus", new Guid("93967f84-2598-4aca-9a50-5c4a7719820f"), "新增", 0, null, "btn_add_box()" },
                    { new Guid("e9caca10-5e98-4e58-b6b4-bcb1261ab973"), "ljgl-ljlx-SaveSystemLinkType", new DateTime(2020, 3, 11, 9, 57, 10, 485, DateTimeKind.Local).AddTicks(7114), "fas fa-plus", new Guid("271fade9-0e28-411b-ad92-7fc9a3b57990"), "新增", 0, null, "btn_add_box()" },
                    { new Guid("238bdbad-de73-4b63-bd2c-6ae46188c67d"), "xtgl-zdgl-SaveSystemDictionary", new DateTime(2020, 3, 11, 9, 57, 10, 485, DateTimeKind.Local).AddTicks(7109), "fas fa-edit", new Guid("af66d9a6-3567-4267-a7cc-a79982b53fd0"), "编辑", 0, null, "btn_edit_box()" },
                    { new Guid("e2bce99b-13c5-4f81-bb29-7851c1525a16"), "xtgl-cdan-SaveMenuButton", new DateTime(2020, 3, 11, 9, 57, 10, 485, DateTimeKind.Local).AddTicks(7105), "fas fa-edit", new Guid("8f9d406f-70f0-4a11-9380-616fe2395c9e"), "编辑", 0, null, "btn_edit_box()" },
                    { new Guid("c00264d0-9e5a-47fb-a7c3-6e5268347a0d"), "xtgl-zdgl-SaveSystemDictionary", new DateTime(2020, 3, 11, 9, 57, 10, 485, DateTimeKind.Local).AddTicks(7100), "fas fa-plus", new Guid("af66d9a6-3567-4267-a7cc-a79982b53fd0"), "新增", 0, null, "btn_add_box()" },
                    { new Guid("268c655a-17a7-42ea-9a86-85c868057bde"), "xtgl-mkwh-DeleteMenu", new DateTime(2020, 3, 11, 9, 57, 10, 485, DateTimeKind.Local).AddTicks(7096), "far fa-trash-alt", new Guid("fc239bef-8bfa-48a4-ad99-150a1b1a017e"), "删除", 0, null, "btn_edit_box()" },
                    { new Guid("b9b33e0b-0fa0-4650-a43d-3c009f516ca8"), "xtgl-wz-SaveArticle", new DateTime(2020, 3, 11, 9, 57, 10, 485, DateTimeKind.Local).AddTicks(7091), "fas fa-plus", new Guid("e0d226e9-6253-42c7-abbd-65111f73d406"), "编辑", 0, null, "btn_edit_box()" },
                    { new Guid("f5372795-67f5-4439-b131-2f8cfa1af3db"), null, new DateTime(2020, 3, 11, 9, 57, 10, 485, DateTimeKind.Local).AddTicks(7083), "fas fa-plus", new Guid("e0d226e9-6253-42c7-abbd-65111f73d406"), "新增", 0, null, "btn_add_box()" },
                    { new Guid("3ddc9055-7624-4062-baaf-602c59677195"), null, new DateTime(2020, 3, 11, 9, 57, 10, 485, DateTimeKind.Local).AddTicks(7078), "fas fa-edit", new Guid("93967f84-2598-4aca-9a50-5c4a7719820f"), "编辑", 0, null, "btn_edit_box()" },
                    { new Guid("fbf9c531-bab5-424a-98c2-5e4e0cf57e42"), "xtgl-zffs-SavePays", new DateTime(2020, 3, 11, 9, 57, 10, 485, DateTimeKind.Local).AddTicks(7069), "fas fa-plus", new Guid("8f9d406f-70f0-4a11-9380-616fe2395c9e"), "新增", 0, null, "btn_add_box()" },
                    { new Guid("f82046c2-c842-4be2-9b8a-b50c6297ab14"), "wzgl-wzlb-Delete", new DateTime(2020, 3, 11, 9, 57, 10, 485, DateTimeKind.Local).AddTicks(7123), "fas fa-trash-alt", new Guid("e0d226e9-6253-42c7-abbd-65111f73d406"), "删除", 0, null, "btn_delete_box()" },
                    { new Guid("531a00cf-6b92-463b-a26b-f5961818b777"), "xtgl-mkwh-SaveMenu", new DateTime(2020, 3, 11, 9, 57, 10, 485, DateTimeKind.Local).AddTicks(7058), "fas fa-edit", new Guid("fc239bef-8bfa-48a4-ad99-150a1b1a017e"), "编辑", 0, null, "btn_edit_box()" },
                    { new Guid("37ff0993-38f7-41d9-975a-0e2f1860df07"), "xtgl-mkwh-SaveMenu", new DateTime(2020, 3, 11, 9, 57, 10, 485, DateTimeKind.Local).AddTicks(7054), "fas fa-plus", new Guid("fc239bef-8bfa-48a4-ad99-150a1b1a017e"), "新增", 0, null, "btn_add_box()" },
                    { new Guid("01919204-733d-441d-b7e7-985212d900ba"), "xtgl-xtyh-SaveUser", new DateTime(2020, 3, 11, 9, 57, 10, 485, DateTimeKind.Local).AddTicks(7050), "fas fa-plus", new Guid("004e1aeb-5270-42cf-945c-dd7a1f277ced"), "新增", 0, null, "btn_add_box()" },
                    { new Guid("cdca30ba-0d5a-49a6-b804-9e3fee46fa83"), "xtgl-jswh-SaveRole", new DateTime(2020, 3, 11, 9, 57, 10, 485, DateTimeKind.Local).AddTicks(7028), "fas fa-plus", new Guid("40793482-245c-4a1c-8c58-351b6d1b2e7f"), "新增", 0, null, "btn_add_box()" },
                    { new Guid("c724cffc-b09e-472e-95f9-4525c273db47"), "xtgl-jswh-ChosenButton", new DateTime(2020, 3, 11, 9, 57, 10, 485, DateTimeKind.Local).AddTicks(7023), "fas fa-user-minus", new Guid("40793482-245c-4a1c-8c58-351b6d1b2e7f"), "按钮权限", 0, null, "buttonPermission()" },
                    { new Guid("ce5efe25-fa9e-49dc-900c-61a7c74fb32f"), "xtgl-jswh-Chosen", new DateTime(2020, 3, 11, 9, 57, 10, 485, DateTimeKind.Local).AddTicks(6985), "fas fa-user-lock", new Guid("40793482-245c-4a1c-8c58-351b6d1b2e7f"), "模块权限", 0, null, "menuPermission()" },
                    { new Guid("56150106-f167-452c-87ca-e84dbc5fd3e8"), null, new DateTime(2020, 3, 11, 9, 57, 10, 485, DateTimeKind.Local).AddTicks(6911), "fas fa-edit", new Guid("6a1969b8-31ee-4bd7-9ca4-4375ddceba73"), "编辑", 0, null, "btn_edit_box()" },
                    { new Guid("c7774014-894a-486e-bedb-a72a00d64921"), "xtgl-cdan-SaveMenuButton", new DateTime(2020, 3, 11, 9, 57, 10, 485, DateTimeKind.Local).AddTicks(3251), "fas fa-plus", new Guid("6a1969b8-31ee-4bd7-9ca4-4375ddceba73"), "新增", 0, null, "btn_add_box()" },
                    { new Guid("f5081fac-5301-479b-89f6-466b3551bfb0"), "ljgl-ljlx-SaveSystemLinkType", new DateTime(2020, 3, 11, 9, 57, 10, 485, DateTimeKind.Local).AddTicks(7118), "fas fa-edit", new Guid("271fade9-0e28-411b-ad92-7fc9a3b57990"), "编辑", 0, null, "btn_add_box()" },
                    { new Guid("58eaba3b-91b1-4594-82fb-a5cc6cfee7c6"), null, new DateTime(2020, 3, 11, 9, 57, 10, 485, DateTimeKind.Local).AddTicks(7065), "fas fa-chart-pie", new Guid("8ba0133b-3c19-4bca-a86d-527463ff4fd3"), "数据分析", 0, null, "btn_data_box()" }
                });

            migrationBuilder.InsertData(
                table: "Sys_User",
                columns: new[] { "Id", "Code", "CreateTime", "Email", "FirstVisitTime", "ImgUrl", "IsAdmin", "IsFreeze", "LastVisitTime", "Mobile", "Name", "Password", "Remark" },
                values: new object[] { new Guid("a97a6118-6930-4dd8-bcbf-a8e45711c2f9"), "admin", new DateTime(2020, 3, 11, 9, 57, 10, 482, DateTimeKind.Local).AddTicks(8144), null, null, "/images/u.jpg", true, false, null, null, "admin", "S0JRR96eei0=", "系统管理员" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sys_Article");

            migrationBuilder.DropTable(
                name: "Sys_ArticleType");

            migrationBuilder.DropTable(
                name: "Sys_Config");

            migrationBuilder.DropTable(
                name: "Sys_Dictionary");

            migrationBuilder.DropTable(
                name: "Sys_ExceptionLog");

            migrationBuilder.DropTable(
                name: "Sys_LoginLog");

            migrationBuilder.DropTable(
                name: "Sys_Menu");

            migrationBuilder.DropTable(
                name: "Sys_MenuButton");

            migrationBuilder.DropTable(
                name: "Sys_OperateLog");

            migrationBuilder.DropTable(
                name: "Sys_Permission");

            migrationBuilder.DropTable(
                name: "Sys_PermissionUser");

            migrationBuilder.DropTable(
                name: "Sys_Role");

            migrationBuilder.DropTable(
                name: "Sys_SqlLog");

            migrationBuilder.DropTable(
                name: "Sys_User");
        }
    }
}
