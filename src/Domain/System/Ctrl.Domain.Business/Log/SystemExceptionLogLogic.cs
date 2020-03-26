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
    public class SystemExceptionLogLogic : CrudAppService<SystemExceptionLog, SystemExceptionLogDto,Guid>, ISystemExceptionLogLogic, IScopedDependency
    {
        private readonly ISystemExceptionLogRepository _exceptionLogRepository;
        public SystemExceptionLogLogic(IRepository<SystemExceptionLog, Guid> repository,
            ISystemExceptionLogRepository exceptionLogRepository) : base(repository)
        {
            this._exceptionLogRepository = exceptionLogRepository;
        }
        #region 构造函数
     
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
        public async Task<PagedResultDto<SystemExceptionLogDto>> PagingExceptionLogQuery(SystemExceptionLogResultRequestDto query)
        {
            var list = await _exceptionLogRepository.GetListAsync(query);
            var totalCount = await _exceptionLogRepository.GetCountAsync(query);

            return new PagedResultDto<SystemExceptionLogDto>(
                totalCount,
                ObjectMapper.Map<List<SystemExceptionLog>, List<SystemExceptionLogDto>>(list)
                );
        }
        #endregion
    }
}
