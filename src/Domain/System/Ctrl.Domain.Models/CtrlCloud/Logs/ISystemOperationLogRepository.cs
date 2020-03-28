using Ctrl.Domain.Models.Dtos.Logs;
using Ctrl.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Ctrl.Domain.DataAccess.Log
{
    ///// <summary>
    /////     操作日志数据访问层接口
    ///// </summary>
    //public interface ISystemOperationLogRepository:IRepository<SystemOperateLog>
    //{
    //    /// <summary>
    //    ///     分页查询登录信息
    //    /// </summary>
    //    /// <param name="param"></param>
    //    /// <returns></returns>
    //    Task<PagedResultsDto<SystemOperateLog>> GetPagingOperationLog(SystemLoginLogPagingInput queryParam);
    //}


    public interface ISystemOperationLogRepository : IBasicRepository<SystemOperateLog, Guid>
    {
        Task<List<SystemOperateLog>> GetListAsync(
   SystemOperateLogResultRequestDto input,
    CancellationToken cancellationToken = default);

        Task<long> GetCountAsync(
          SystemOperateLogResultRequestDto input,
          CancellationToken cancellationToken = default);
    }
}
