using Ctrl.Domain.Models.Dtos.Article;
using Ctrl.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Ctrl.System.DataAccess
{
    /// <summary>
    /// 文章数据访问接口
    /// </summary>
    public interface ISystemArticleRepository : IBasicRepository<SystemArticle>
    {
        Task<long> GetCountAsync(
        SystemArticleResultRequestDto input,
        CancellationToken cancellationToken = default);
        /// <summary>
        ///     获取文章分页
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<List<SystemArticle>> GetPagingArticleType(SystemArticleResultRequestDto param, CancellationToken cancellationToken = default);
    }
}
