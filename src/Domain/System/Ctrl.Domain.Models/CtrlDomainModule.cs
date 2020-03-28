using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Ctrl.Domain.Models
{

    public class CtrlDomainModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<CtrlDomainModule>();
            });
        }
    }
}
