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

        public CtrlDbContext(DbContextOptions<CtrlDbContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<SystemUser>(b =>
            {
                b.ToTable("Sys_User");
                b.ConfigureByConvention();

            });
            builder.Entity<SystemMenuButton>(b =>
            {
                b.ToTable("Sys_MenuButton");
                b.ConfigureByConvention();

            });
            builder.Entity<SystemPermission>(b =>
            {
                b.ToTable("Sys_Permission");
                b.ConfigureByConvention();
            });
            builder.Entity<SystemArticle>(b =>
            {
                b.ToTable("Sys_Article");
                b.ConfigureByConvention();
            });

            builder.Entity<SystemExceptionLog>(b =>
            {
                b.ToTable("Sys_ExceptionLog");
                b.ConfigureByConvention();
            });
        }
    }
}
