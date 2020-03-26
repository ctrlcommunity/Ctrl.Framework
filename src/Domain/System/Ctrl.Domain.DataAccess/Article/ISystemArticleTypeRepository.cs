using Ctrl.Core.DataAccess;
using Ctrl.Core.Entities.Paging;
using Ctrl.Core.Entities.Tree;
using Ctrl.Domain.Models.Dtos.Article;
using Ctrl.System.Models.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace Ctrl.System.DataAccess
{
    /// <summary>
    /// 文章类型数据访问接口
    /// </summary>
    public interface ISystemArticleTypeRepository : IBasicRepository<SystemArticleType>
    {
        Task<IEnumerable<TreeEntity>> GetArticleTypeTree();

        // Task<PagedResultsDto<SystemArticleTypeOutput>> GetPagingArticleType(PagedAndSortedResultRequestDto param);
        /// <summary>
        ///     获取文章类型分页
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<List<SystemArticleType>> GetListAsync(
                PagedAndSortedResultRequestDto input,
                CancellationToken cancellationToken = default);


        Task<long> GetCountAsync(
            SystemArticleResultRequestDto input,
            CancellationToken cancellationToken = default);




    }
}
