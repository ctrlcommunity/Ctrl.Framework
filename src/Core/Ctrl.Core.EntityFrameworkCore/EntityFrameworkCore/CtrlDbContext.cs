using Ctrl.Domain.Models.Entities;
using Ctrl.System.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Ctrl.Core.EntityFrameworkCore.EntityFrameworkCore
{
    [ConnectionStringName("Default")]
    public class CtrlDbContext : AbpDbContext<CtrlDbContext>
    {
        public DbSet<SystemUser> Users { get; set; }

        public DbSet<SystemPermission> Permissions { get; set; }
        
        public DbSet<SystemArticle> SystemArticles { get; set; }

        public DbSet<SystemExceptionLog> SystemExceptionLogs { get; set; }

        public DbSet<SystemArticleType> SystemArticleTypes { get; set; }

        public DbSet<SystemConfig> SystemConfigs { get; set; }

        public DbSet<SystemDictionary> SystemDictionaries { get; set; }

        public DbSet<SystemLoginLog> SystemLoginLogs { get; set; }

        public DbSet<SystemMenu> SystemMenus { get; set; }

        public DbSet<SystemMenuButton> SystemMenuButtons { get; set; }

        public DbSet<SystemOperateLog> SystemOperateLogs { get; set; }

        public DbSet<SystemPermission> SystemPermissions { get; set; }

        public DbSet<SystemPermissionUser> SystemPermissionUsers { get; set; }

        public DbSet<SystemRole> SystemRoles { get; set; }

        public DbSet<SystemSqlLog> SystemSqlLogs { get; set; }

        public DbSet<SystemUser> SystemUsers { get; set; }

        public CtrlDbContext(DbContextOptions<CtrlDbContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ConfigureCtrl();
        }
    }
}
