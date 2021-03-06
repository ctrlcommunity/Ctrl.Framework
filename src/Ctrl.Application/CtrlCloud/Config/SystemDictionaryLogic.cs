using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ctrl.Core.Entities;
using Ctrl.Core.Entities.Dtos;
using Ctrl.Core.Entities.Select2;
using Ctrl.Core.Entities.Tree;
using Ctrl.Domain.Models.Dtos.Config;
using Ctrl.System.Business;
using Ctrl.System.DataAccess;
using Ctrl.System.Models.Entities;
using CtrlCloud.Framework.Application.Contracts.CtrlCloud.Config.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace CtrlCloud.Framework.Application.CtrlCloud.Config
{
    /// <summary>
    ///     字典业务逻辑接口实现
    /// </summary>
    public class SystemDictionaryLogic : CrudAppService<SystemDictionary, SystemDictionaryOutput, Guid>, ISystemDictionaryLogic, IScopedDependency
    {
        #region 构造函数
        private readonly ISystemDictionaryRepository _systemDictionaryRepository;

        public SystemDictionaryLogic(IRepository<SystemDictionary, Guid> repository, ISystemDictionaryRepository systemDictionaryRepository) : base(repository)
        {
            this._systemDictionaryRepository = systemDictionaryRepository;
        }

        #endregion

        #region 方法

        /// <summary>
        ///     保存字典
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Task<OperateStatus> SaveSystemDictionary(CreateSystemDictionaryDto input)
        {
            //if (input.Id.IsEmptyGuid())
            //{
            //    input.CreateTime = DateTime.Now;
            //   // input.Id = Guid.NewGuid();
            //    //return await InsertAsync(input);
            //}
            //else
            //{
            //  //var dir=await _systemDictionaryRepository.GetById(input.DictionaryId);
            //  //  input.CreateTime = dir.CreateTime;
            //    //return await UpdateAsync(input);
            //}
            return null;
            
        }

        /// <summary>
        ///     获取字典树
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<TreeEntity>> GetDictionaryTree()
        {
            return _systemDictionaryRepository.GetDictionaryTree();
        }
        /// <summary>
        ///     字典分页信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<SystemDictionaryOutput>> PagingDictionaryQuery(SystemDictionaryResultRequestDto query)
        {
            var list = await _systemDictionaryRepository.PagingDictionaryQuery(query);
            var totalCount = await _systemDictionaryRepository.GetCountAsync(query);

            return new PagedResultDto<SystemDictionaryOutput>(
                totalCount,
                ObjectMapper.Map<List<SystemDictionary>, List<SystemDictionaryOutput>>(list)
                );
        }
        /// <summary>
        ///     根据父级编码获取子级
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Task<IEnumerable<Select2Entity>> GetTypeChildrenByCode(IdInput input)
        {
            return _systemDictionaryRepository.GetTypeChildrenByCode(input);
        }

        #endregion
    }
}