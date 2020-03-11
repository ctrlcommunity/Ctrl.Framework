using Ctrl.Core.Entities.Paging;
using Ctrl.Domain.Models.Dtos.Logs;
using Ctrl.Domain.Models.Entities;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Ctrl.Domain.Business.Log
{
    public interface ISystemOperationLogLogic: ICrudAppService<SystemOperateLogOutput, Guid>,IScopedDependency
    {
        /// <summary>
        ///     分页查询登录日志
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<PagedResultDto<SystemOperateLogOutput>> GetPagingOperationLog(PagedAndSortedResultRequestDto queryParam);
    }
}
