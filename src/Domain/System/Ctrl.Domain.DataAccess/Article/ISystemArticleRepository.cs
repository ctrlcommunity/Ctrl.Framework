using Ctrl.Core.DataAccess;
using Ctrl.Core.Entities.Paging;
using Ctrl.Domain.Models.Dtos;
using Ctrl.Domain.Models.Dtos.Article;
using Ctrl.System.Models.Entities;
using System.Threading.Tasks;
using Ctrl.Domain.Models.Entities;
using Volo.Abp.Domain.Repositories;
using System.Collections.Generic;
using System.Threading;

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
