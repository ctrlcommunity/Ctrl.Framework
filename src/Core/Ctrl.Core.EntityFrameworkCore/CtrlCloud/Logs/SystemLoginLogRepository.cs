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

    public class SystemLoginLogRepository : EfCoreRepository<CtrlDbContext, SystemLoginLog, Guid>, ISystemLoginLogRepository
    {
        public SystemLoginLogRepository(IDbContextProvider<CtrlDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        public virtual async Task<List<SystemLoginLog>> GetListAsync(
SystemLoginLogResultRequestDto input,
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
                .OrderBy(input.Sorting ?? nameof(SystemLoginLog.CreateTime))
                .PageBy(input.SkipCount, input.MaxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }
        public virtual async Task<long> GetCountAsync(
  SystemLoginLogResultRequestDto input,
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
                .LongCountAsync(GetCancellationToken(cancellationToken));
        }

    }

    //    /// <summary>
    //    ///     登录日志数据访问
    //    /// </summary>
    //    public class SystemLoginLogRepository: PetaPocoRepository<SystemLoginLog>,ISystemLoginLogRepository, IScopedDependency
    //    {

    //        public Task<List<SystemLoginLogOutput>> PagingLoginLogQuery(SystemLoginLogResultRequestDto input) { 

    //        }

    //        /// <summary>
    //        ///     获取一个月数据
    //        /// </summary>
    //        /// <returns></returns>
    //        public Task<IEnumerable<string>> GetDateMonth()
    //        {
    //            string sql = @"select convert(varchar(5),dateadd(dd,number,dateadd(month,-1,getdate())),110) as dt
    //from master..spt_values 
    //where type='P' and 
    //dateadd(dd,number,dateadd(month,-1,getdate()))<=getdate()";
    //            return SqlMapperUtil.Query<string>(sql);
    //        }

    //        /// <summary>
    //        /// 根据区域查询登录次数
    //        /// </summary>
    //        /// <param name="AreaName"></param>
    //        /// <returns></returns>
    //        public Task<int> GetLoginCountByAreaName(string AreaName)
    //        {
    //            string sql = $@"select count(1) from Sys_LoginLog
    //                            where IpAddressName like '%{AreaName}%'";
    //            return SqlMapperUtil.Count(sql);
    //        }
    //        /// <summary>
    //        ///     获取近一个月的登录记录
    //        /// </summary>
    //        /// <returns></returns>
    //        public Task<IEnumerable<SystemLoginLog>> GetLoginLogDateMonth()
    //        {
    //            string sql = @"select CreateTime from Sys_LoginLog
    //                where CreateTime>=dateadd(month,-1,getdate())";
    //            return SqlMapperUtil.Query<SystemLoginLog>(sql);
    //        }

    //        /// <summary>
    //        ///     分页查询登录信息
    //        /// </summary>
    //        /// <param name="param"></param>
    //        /// <returns></returns>
    //        public Task<PagedResultsDto<SystemLoginLog>> PagingLoginLogQuery(SystemLoginLogPagingInput param)
    //        {
    //            string strWhere = "";
    //            if (!string.IsNullOrWhiteSpace(param.CreateUserCode))
    //            {
    //                strWhere+= $" AND CreateUserCode='{param.CreateUserCode}' ";
    //            }
    //            if (!string.IsNullOrWhiteSpace(param.CreateUserName))
    //            {
    //                strWhere += $" AND CreateUserName='{param.CreateUserName}' ";
    //            }
    //            if (param.startTime!=default(DateTime))
    //            {
    //                strWhere += $" AND CreateTime>='{param.startTime}' ";
    //            }
    //            if (param.endTime != default(DateTime))
    //            {
    //                strWhere += $" AND CreateTime<='{param.endTime}' ";
    //            }
    //            string sql = $"SELECT * FROM Sys_LoginLog where 1=1 {strWhere}";

    //            return SqlMapperUtil.PagingQuery<SystemLoginLog>(sql, param);
    //        }
    //}
}
