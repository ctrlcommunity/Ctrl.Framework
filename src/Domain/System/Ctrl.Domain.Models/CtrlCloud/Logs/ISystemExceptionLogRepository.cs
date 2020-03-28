using Ctrl.Domain.Models.Dtos.Logs;
using Ctrl.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Ctrl.Domain.DataAccess.Log
{
    /// <summary>
    ///     异常日志数据访问层接口
    /// </summary>
    public interface ISystemExceptionLogRepository : IBasicRepository<SystemExceptionLog>
    {
        //Task<List<SystemExceptionLog>> PagingExceptionLogQuery(SystemExceptionLogResultRequestDto query);

        Task<List<SystemExceptionLog>> GetListAsync(
            SystemExceptionLogResultRequestDto input,
            CancellationToken cancellationToken = default);

        Task<long> GetCountAsync(
     SystemExceptionLogResultRequestDto input,
     CancellationToken cancellationToken = default);
    }
}
