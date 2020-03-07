using Ctrl.Core.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Ctrl.EntityFrameworkCore.DbMigrations.EntityFrameworkCore
{
    public class CtrlMigrationsDbContext:AbpDbContext<CtrlMigrationsDbContext>
    {
        public CtrlMigrationsDbContext(DbContextOptions<CtrlMigrationsDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ConfigureCtrl();
            /* Include modules to your migration db context */
        }
    }
}
