using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Ctrl.EntityFrameworkCore.DbMigrations.EntityFrameworkCore
{
    public class CtrlMigrationsDbContextFactory : IDesignTimeDbContextFactory<CtrlMigrationsDbContext>
    {
        public CtrlMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<CtrlMigrationsDbContext>()
                .UseMySql(configuration.GetConnectionString("Test"));

            return new CtrlMigrationsDbContext(builder.Options);
        }
        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
