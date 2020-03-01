using System;
using System.Threading.Tasks;
using Ctrl.Core.Business;
using Ctrl.Core.Core.Utils;
using Ctrl.Core.Entities;
using Ctrl.System.Business;
using Ctrl.System.DataAccess;
using Ctrl.System.Models.Entities;
using Volo.Abp.DependencyInjection;

namespace Ctrl.Domain.Business.Config
{
    /// <summary>
    ///      支付配置表业务逻辑接口实现
    /// </summary>
    public class SystemPaysLogic:AsyncLogic<SystemPays>,ISystemPaysLogic, IScopedDependency
    {
        #region 构造函数
        private readonly ISystemPaysRepository _systemPaysRepository;

        public SystemPaysLogic(ISystemPaysRepository systemPaysRepository):base(systemPaysRepository) {
            _systemPaysRepository = systemPaysRepository;
        }
        /// <summary>
        ///     获取支付方式信息
        /// </summary>
        /// <returns></returns>
        public Task<SystemPays> GetPaysInfoByType(string TypeName)
        {
            return _systemPaysRepository.GetPaysInfoByType(TypeName);
        }
        #endregion

        #region 方法
        public async Task<OperateStatus> SavePays(SystemPays systemPays)
        {
            if (systemPays.PayId.IsEmptyGuid())
            {
                systemPays.PayId = CombUtil.NewComb();
                systemPays.CreateTime = DateTime.Now;
                return await InsertAsync(systemPays);
            }
            else
            {
                var pay = await _systemPaysRepository.GetById(systemPays.PayId);
                systemPays.CreateTime = pay.CreateTime;
                return await UpdateAsync(systemPays);
            }
        }
        #endregion
    }
}