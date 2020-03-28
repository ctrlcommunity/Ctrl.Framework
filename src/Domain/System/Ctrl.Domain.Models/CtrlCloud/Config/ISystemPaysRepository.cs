using Ctrl.System.Models.Entities;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Ctrl.System.DataAccess
{
    /// <summary>
    ///  支付配置表数据访问接口
    /// </summary>
    public interface ISystemPaysRepository: IRepository<SystemPays>
    {
        /// <summary>
        ///     获取支付方式信息
        /// </summary>
        /// <returns></returns>
        Task<SystemPays> GetPaysInfoByType(string TypeName);
    }
}
