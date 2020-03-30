using Ctrl.Domain.DataAccess.Log;
using Ctrl.Domain.Models.Dtos.Logs;
using Ctrl.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Ctrl.Domain.Business.Log
{
    public class SystemOperationLogLogic : CrudAppService<SystemOperateLog, SystemOperateLogOutput,
        Guid, SystemOperateLogResultRequestDto>, ISystemOperationLogLogic, IScopedDependency
    {
        private readonly ISystemOperationLogRepository _systemOperationLogRepository;
        public SystemOperationLogLogic(IRepository<SystemOperateLog, Guid> repository, ISystemOperationLogRepository systemOperationLogRepository) : base(repository)
        {
            this._systemOperationLogRepository = systemOperationLogRepository;
        }
        #region 构造函数

        #endregion
        /// <summary>
        ///     分页
        /// </summary>
        /// <param name="queryParam"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<SystemOperateLogOutput>> GetPagingOperationLog(SystemOperateLogResultRequestDto queryParam)
        {
            var list = await _systemOperationLogRepository.GetListAsync(queryParam);
            var totalCount = await _systemOperationLogRepository.GetCountAsync(queryParam);

            return new PagedResultDto<SystemOperateLogOutput>(
                totalCount,
                ObjectMapper.Map<List<SystemOperateLog>, List<SystemOperateLogOutput>>(list)
                );
        }


    }
}
