using Ctrl.Core.EntityFrameworkCore.EntityFrameworkCore;
using Ctrl.Domain.Models.Dtos.Logs;
using Ctrl.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Ctrl.Domain.DataAccess.Log
{
    ///// <summary>
    /////     异常日志数据访问层实现
    ///// </summary>
    //public class SystemExceptionLogRepository: PetaPocoRepository<SystemExceptionLog>,ISystemExceptionLogRepository, IScopedDependency
    //{
    //    ///// <summary>
    //    /////     异常信息分页
    //    ///// </summary>
    //    ///// <param name="query"></param>
    //    ///// <returns></returns>
    //    //public Task<PagedResultsDto<SystemExceptionLog>> PagingExceptionLogQuery(SystemLoginLogPagingInput param)
    //    //{
    //    //    string strWhere = "";
    //    //    if (!string.IsNullOrWhiteSpace(param.CreateUserCode))
    //    //    {
    //    //        strWhere += $" AND CreateUserCode='{param.CreateUserCode}' ";
    //    //    }
    //    //    if (!string.IsNullOrWhiteSpace(param.CreateUserName))
    //    //    {
    //    //        strWhere += $" AND CreateUserName='{param.CreateUserName}' ";
    //    //    }
    //    //    if (param.startTime != default(DateTime))
    //    //    {
    //    //        strWhere += $" AND CreateTime>='{param.startTime}' ";
    //    //    }
    //    //    if (param.endTime != default(DateTime))
    //    //    {
    //    //        strWhere += $" AND CreateTime<='{param.endTime}' ";
    //    //    }
    //    //    string sql = $"select * from Sys_ExceptionLog where 1=1 {strWhere}";
    //    //    return SqlMapperUtil.PagingQuery<SystemExceptionLog>(sql, param);
    //    //}
    //}

    public class SystemExceptionLogRepository : EfCoreRepository<CtrlDbContext, SystemExceptionLog, Guid>, ISystemExceptionLogRepository
    {
        public SystemExceptionLogRepository(IDbContextProvider<CtrlDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<long> GetCountAsync(SystemExceptionLogResultRequestDto input, CancellationToken cancellationToken = default)
        {
            return await this.WhereIf(
                    !input.CreateUserName.IsNullOrEmpty(),
                    o => o.CreateUserName.Contains(input.CreateUserName)
                )
                    .WhereIf(
                    !input.CreateUserCode.IsNullOrEmpty(),
                    o => o.CreateUserCode.Contains(input.CreateUserCode)
                )
                .LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<SystemExceptionLog>> GetListAsync(SystemExceptionLogResultRequestDto input, CancellationToken cancellationToken = default)
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
              .OrderBy(input.Sorting ?? nameof(SystemExceptionLog.CreateTime))
              .PageBy(input.SkipCount, input.MaxResultCount)
              .ToListAsync(GetCancellationToken(cancellationToken));
        }


    }

}
