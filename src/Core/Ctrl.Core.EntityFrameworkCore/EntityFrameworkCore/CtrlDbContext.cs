using Ctrl.Domain.Models.Entities;
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
        }
    }
}
