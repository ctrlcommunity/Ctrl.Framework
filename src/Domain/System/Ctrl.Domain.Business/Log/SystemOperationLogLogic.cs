using System;
using System.Threading.Tasks;
using Ctrl.Core.Business;
using Ctrl.Core.Entities.Paging;
using Ctrl.Domain.DataAccess.Log;
using Ctrl.Domain.Models.Dtos.Logs;
using Ctrl.Domain.Models.Entities;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Ctrl.Domain.Business.Log
{
    public class SystemOperationLogLogic : CrudAppService<SystemOperateLog, SystemOperateLogOutput,Guid>, ISystemOperationLogLogic,IScopedDependency
    {
        public SystemOperationLogLogic(IRepository<SystemOperateLog, Guid> repository) : base(repository)
        {
        }
        #region 构造函数

        //private readonly ISystemOperationLogRepository _repository;

        //public SystemOperationLogLogic(ISystemOperationLogRepository operationLogRepository)
        //    : base(operationLogRepository)
        //{
        //    _repository = operationLogRepository;
        //}

        #endregion
        /// <summary>
        ///     分页
        /// </summary>
        /// <param name="queryParam"></param>
        /// <returns></returns>
        public Task<PagedResultDto<SystemOperateLogOutput>> GetPagingOperationLog(PagedAndSortedResultRequestDto queryParam)
        {
            return GetListAsync(queryParam);
        }
    }
}
