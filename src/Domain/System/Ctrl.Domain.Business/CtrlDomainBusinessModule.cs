using Ctrl.Domain.Models;
using CtrlCloud.Framework.Application.Contracts.CtrlCloud;
using Volo.Abp.Modularity;

namespace Ctrl.Domain.Business
{
    [DependsOn(
        typeof(CtrlDomainModule),
        typeof(CtrlCloudApplicationContractsModule)
        )]
    public class CtrlDomainBusinessModule: AbpModule
    {
    }
}
