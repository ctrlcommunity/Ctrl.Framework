using Ctrl.Domain.Models.Dtos.Logs;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Ctrl.Domain.Business.Log
{
    /// <summary>
    ///     异常日志业务逻辑接口
    /// </summary>
    public interface ISystemExceptionLogLogic : ICrudAppService<SystemExceptionLogDto, Guid>, IScopedDependency
    {
        Task<PagedResultDto<SystemExceptionLogDto>> PagingExceptionLogQuery(SystemExceptionLogResultRequestDto query);
    }
}
