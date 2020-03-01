using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ctrl.Core.Business;
using Ctrl.Core.Core.Utils;
using Ctrl.Core.Entities;
using Ctrl.Core.Entities.Dtos;
using Ctrl.Core.Entities.Paging;
using Ctrl.Core.Entities.Select2;
using Ctrl.Core.Entities.Tree;
using Ctrl.Domain.Models.Dtos.Config;
using Ctrl.System.Business;
using Ctrl.System.DataAccess;
using Ctrl.System.Models.Entities;
using Volo.Abp.DependencyInjection;

namespace Ctrl.Domain.Business.Config
{
    /// <summary>
    ///     字典业务逻辑接口实现
    /// </summary>
    public class SystemDictionaryLogic : AsyncLogic<SystemDictionary>, ISystemDictionaryLogic, IScopedDependency
    {
        #region 构造函数
        private readonly ISystemDictionaryRepository _systemDictionaryRepository;

        public SystemDictionaryLogic(ISystemDictionaryRepository systemDictionaryRepository) : base(systemDictionaryRepository)
        {
            _systemDictionaryRepository = systemDictionaryRepository;
        }

        #endregion

        #region 方法

        /// <summary>
        ///     保存字典
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<OperateStatus> SaveSystemDictionary(SystemDictionary input)
        {
            if (input.DictionaryId.IsEmptyGuid())
            {
                input.CreateTime = DateTime.Now;
                input.DictionaryId = Guid.NewGuid();
                return await InsertAsync(input);
            }
            else
            {
              var dir=await _systemDictionaryRepository.GetById(input.DictionaryId);
                input.CreateTime = dir.CreateTime;
                return await UpdateAsync(input);
            }
            
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
        public Task<PagedResults<SystemDictionaryOutput>> PagingDictionaryQuery(SystemDictionaryPagingInput query)
        {
            return _systemDictionaryRepository.PagingDictionaryQuery(query);
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