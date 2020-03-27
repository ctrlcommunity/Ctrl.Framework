using Ctrl.Web.Host.Startup;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Ctrl.Application
{
    public class CtrlApplicationModule: AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                /* Use `true` for the `validate` parameter if you want to
                 * validate the profile on application startup.
                 * See http://docs.automapper.org/en/stable/Configuration-validation.html for more info
                 * about the configuration validation. */
                options.AddProfile<CtrlWebAutoMapperProfile>();
            });
        }
    }
}
