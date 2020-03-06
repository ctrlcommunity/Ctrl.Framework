using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ctrl.EntityFrameworkCore.DbMigrations.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sys_Article",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    ArticleTypeId = table.Column<Guid>(nullable: false),
                    Author = table.Column<string>(nullable: true),
                    IsShow = table.Column<bool>(nullable: false),
                    OrderNo = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    Pic = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    Contents = table.Column<string>(nullable: true),
                    Counter = table.Column<int>(nullable: false),
                    SeoTitle = table.Column<string>(nullable: true),
                    SeoDes = table.Column<string>(nullable: true),
                    SeoKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Article", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_ArticleType",
                columns: table => new
                {
                    ArticleTypeId = table.Column<Guid>(nullable: false),
                    ParentId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    OrderNo = table.Column<int>(nullable: false),
                    IsShow = table.Column<bool>(nullable: false),
                    SeoTitle = table.Column<string>(nullable: true),
                    SeoKey = table.Column<string>(nullable: true),
                    SeoDes = table.Column<string>(nullable: true),
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
                    Id = table.Column<Guid>(nullable: false),
                    SiteName = table.Column<string>(nullable: true),
                    Keywords = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
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
                    DictionaryId = table.Column<Guid>(nullable: false),
                    ParentId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    IsFreeze = table.Column<bool>(nullable: false),
                    OrderNo = table.Column<int>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
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
                    Message = table.Column<string>(nullable: true),
                    StackTrace = table.Column<string>(nullable: true),
                    InnerException = table.Column<string>(nullable: true),
                    ExceptionType = table.Column<string>(nullable: true),
                    ServerHost = table.Column<string>(nullable: true),
                    ClientHost = table.Column<string>(nullable: true),
                    Runtime = table.Column<string>(nullable: true),
                    RequestUrl = table.Column<string>(nullable: true),
                    RequestData = table.Column<string>(nullable: true),
                    UserAgent = table.Column<string>(nullable: true),
                    HttpMethod = table.Column<string>(nullable: true),
                    CreateUserId = table.Column<string>(nullable: true),
                    CreateUserCode = table.Column<string>(nullable: true),
                    CreateUserName = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ClientAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_ExceptionLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_LoginLog",
                columns: table => new
                {
                    LoginLogId = table.Column<string>(nullable: false),
                    IpAddressName = table.Column<string>(nullable: true),
                    ServerHost = table.Column<string>(nullable: true),
                    ClientHost = table.Column<string>(nullable: true),
                    UserAgent = table.Column<string>(nullable: true),
                    OsVersion = table.Column<string>(nullable: true),
                    LoginTime = table.Column<DateTime>(nullable: false),
                    CreateUserId = table.Column<string>(nullable: true),
                    CreateUserCode = table.Column<string>(nullable: true),
                    CreateUserName = table.Column<string>(nullable: true),
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
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    OpenType = table.Column<byte[]>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    Controller = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    OpenUrl = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
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
                    Name = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    Script = table.Column<string>(nullable: true),
                    OrderNo = table.Column<int>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_MenuButton", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_OperateLog",
                columns: table => new
                {
                    OperateLogId = table.Column<string>(nullable: false),
                    ClientHost = table.Column<string>(nullable: true),
                    ServerHost = table.Column<string>(nullable: true),
                    RequestContentLength = table.Column<int>(nullable: false),
                    RequestType = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    UrlReferrer = table.Column<string>(nullable: true),
                    RequestData = table.Column<string>(nullable: true),
                    UserAgent = table.Column<string>(nullable: true),
                    ControllerName = table.Column<string>(nullable: true),
                    ActionName = table.Column<string>(nullable: true),
                    ActionExecutionTime = table.Column<decimal>(nullable: false),
                    ResultExecutionTime = table.Column<decimal>(nullable: false),
                    ResponseStatus = table.Column<string>(nullable: true),
                    Describe = table.Column<string>(nullable: true),
                    CreateUserId = table.Column<string>(nullable: true),
                    CreateUserCode = table.Column<string>(nullable: true),
                    CreateUserName = table.Column<string>(nullable: true),
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
                    PrivilegeAccess = table.Column<short>(nullable: false),
                    PrivilegeMasterValue = table.Column<Guid>(nullable: false),
                    PrivilegeAccessValue = table.Column<string>(nullable: true),
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
                    PrivilegeMasterValue = table.Column<string>(nullable: true),
                    PrivilegeMasterUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Sys_Role",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    CanbeDelete = table.Column<bool>(nullable: false),
                    OrderNo = table.Column<int>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    IsFreeze = table.Column<bool>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateUserId = table.Column<Guid>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<Guid>(nullable: false),
                    UpdateUserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Sys_SqlLog",
                columns: table => new
                {
                    SqlLogId = table.Column<string>(nullable: false),
                    CreateUserId = table.Column<string>(nullable: true),
                    CreateUserCode = table.Column<string>(nullable: true),
                    CreateUserName = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    OperateSql = table.Column<string>(nullable: true),
                    EndDateTime = table.Column<DateTime>(nullable: false),
                    ElapsedTime = table.Column<decimal>(nullable: false),
                    Parameter = table.Column<string>(nullable: true)
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
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
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
