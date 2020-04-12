using Ctrl.Domain.Models.Dtos.Logs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Ctrl.Domain.Business.Log
{
    /// <summary>
    ///     登录日志业务逻辑接口
    /// </summary>
    public interface ISystemLoginLogLogic: ICrudAppService<SystemLoginLogOutput, Guid>,IScopedDependency
    {
        /// <summary>
        ///     分页查询登录信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<PagedResultDto<SystemLoginLogOutput>> PagingLoginLogQuery(SystemLoginLogResultRequestDto input);
        /// <summary>
        ///     登录数据分析图数据
        /// </summary>
        /// <returns></returns>
        List<LoginDataOutPut> GetLoginCountData();
        /// <summary>
        ///     获取登录日志分析数据
        /// </summary>
        /// <returns></returns>
        LoginDataAnalysisOutPut FindLoginLogAnalysis();
    }
}
