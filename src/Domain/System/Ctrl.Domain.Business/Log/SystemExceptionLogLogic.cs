using Ctrl.Core.Business;
using Ctrl.Core.Entities.Paging;
using Ctrl.Domain.DataAccess.Log;
using Ctrl.Domain.Models.Dtos.Logs;
using Ctrl.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Ctrl.Domain.Business.Log
{
    public class SystemExceptionLogLogic : CrudAppService<SystemExceptionLog, SystemExceptionLogDto,Guid>, ISystemExceptionLogLogic, IScopedDependency
    {
        public SystemExceptionLogLogic(IRepository<SystemExceptionLog, Guid> repository) : base(repository)
        {
        }
        #region 构造函数
        //private readonly ISystemExceptionLogRepository _exceptionLogRepository;
        //public SystemExceptionLogLogic(ISystemExceptionLogRepository exceptionLogRepository)
        //    : base(exceptionLogRepository)
        //{
        //    this._exceptionLogRepository = exceptionLogRepository;
        //}




        /// <summary>
        ///     异常信息分页
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public Task<PagedResultDto<SystemExceptionLogDto>> PagingExceptionLogQuery(PagedAndSortedResultRequestDto query)
        {
            return GetListAsync(query);
        }
        #endregion
    }
}
