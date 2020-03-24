using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Ctrl.Core.DataAccess;
using Ctrl.Core.Entities.Paging;
using Ctrl.Core.EntityFrameworkCore.EntityFrameworkCore;
using Ctrl.Core.PetaPoco;
using Ctrl.Domain.Models.Dtos.Logs;
using Ctrl.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Ctrl.Domain.DataAccess.Log
{
    ///// <summary>
    /////     操作日志数据访问实现
    ///// </summary>
    //public class SystemOperationLogRepository : PetaPocoRepository<SystemOperateLog>, ISystemOperationLogRepository,IScopedDependency
    //{
    //    public Task<PagedResultsDto<SystemOperateLog>> GetPagingOperationLog(SystemLoginLogPagingInput param)
    //    {

    //        string strWhere = "";
    //        if (!string.IsNullOrWhiteSpace(param.CreateUserCode))
    //        {
    //            strWhere += $" AND CreateUserCode='{param.CreateUserCode}' ";
    //        }
    //        if (!string.IsNullOrWhiteSpace(param.CreateUserName))
    //        {
    //            strWhere += $" AND CreateUserName='{param.CreateUserName}' ";
    //        }
    //        if (param.startTime != default(DateTime))
    //        {
    //            strWhere += $" AND CreateTime>='{param.startTime}' ";
    //        }
    //        if (param.endTime != default(DateTime))
    //        {
    //            strWhere += $" AND CreateTime<='{param.endTime}' ";
    //        }
    //        string sql = $"SELECT * FROM Sys_OperateLog where 1=1 {strWhere}";
    //        return SqlMapperUtil.PagingQuery<SystemOperateLog>(sql, param);
    //    }
    //}


    /// <summary>
    ///     操作日志数据访问实现
    /// </summary>
    public class SystemOperationLogRepository : EfCoreRepository<CtrlDbContext, SystemOperateLog, Guid>, ISystemOperationLogRepository
    {
        public SystemOperationLogRepository(IDbContextProvider<CtrlDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public virtual async Task<List<SystemOperateLog>> GetListAsync(
   SystemOperateLogResultRequestDto input,
    CancellationToken cancellationToken = default)
        {
            return await DbSet
                  .WhereIf(
                    !input.CreateUserName.IsNullOrEmpty(),
                    o => o.CreateUserName.Contains(input.CreateUserName)
                )
                    .WhereIf(
                    !input.CreateUserCode.IsNullOrEmpty(),
                    o => o.CreateUserCode.Contains(input.CreateUserCode)
                )
                      .WhereIf(
                    input.StartTime != default,
                    o => o.CreateTime >= input.StartTime
                ).WhereIf(
                    input.EndTime != default,
                    o => o.CreateTime <= input.EndTime
                )
                .OrderBy(input.Sorting ?? nameof(SystemOperateLog.CreateTime))
                .PageBy(input.SkipCount, input.MaxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task<long> GetCountAsync(
          SystemOperateLogResultRequestDto input,
          CancellationToken cancellationToken = default)
        {
            return await this.WhereIf(
                    !input.CreateUserName.IsNullOrEmpty(),
                    o => o.CreateUserName.Contains(input.CreateUserName)
                )
                    .WhereIf(
                    !input.CreateUserCode.IsNullOrEmpty(),
                    o => o.CreateUserCode.Contains(input.CreateUserCode)
                )
                      .WhereIf(
                    input.StartTime != default,
                    o => o.CreateTime >= input.StartTime
                ).WhereIf(
                    input.EndTime != default,
                    o => o.CreateTime <= input.EndTime
                )
                .LongCountAsync(GetCancellationToken(cancellationToken));
        }
    }
}
