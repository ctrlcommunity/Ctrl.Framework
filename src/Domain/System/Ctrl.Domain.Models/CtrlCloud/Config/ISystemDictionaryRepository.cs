using Ctrl.Core.Entities.Dtos;
using Ctrl.Core.Entities.Select2;
using Ctrl.Core.Entities.Tree;
using Ctrl.Domain.Models.Dtos.Config;
using Ctrl.System.Models.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Ctrl.System.DataAccess
{
    /// <summary>
    /// 字典数据访问接口
    /// </summary>
    public interface ISystemDictionaryRepository : IBasicRepository<SystemDictionary>
    {
        /// <summary>
        ///     获取字典树
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TreeEntity>> GetDictionaryTree();
        /// <summary>
        ///     字典分页信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<List<SystemDictionary>> PagingDictionaryQuery(SystemDictionaryResultRequestDto input,
             CancellationToken cancellationToken = default);

        Task<long> GetCountAsync(
SystemDictionaryResultRequestDto input,
CancellationToken cancellationToken = default);

        /// <summary>
        ///     根据父级编码获取子级
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<IEnumerable<Select2Entity>> GetTypeChildrenByCode(IdInput input);
    }
}
