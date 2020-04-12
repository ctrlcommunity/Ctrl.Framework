using Ctrl.System.Models.Entities;
using CtrlCloud.Framework.Domain.Models.CtrlCloud.Config;
using Volo.Abp.Domain.Repositories;

namespace Ctrl.System.DataAccess
{
    /// <summary>
    /// 网站配置数据访问接口
    /// </summary>
    public interface ISystemConfigRepository: IRepository<SystemConfig>
    {
       
    }
}
