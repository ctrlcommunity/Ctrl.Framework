using Ctrl.Domain.Models.Dtos.Article;
using Ctrl.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CtrlCloud.Framework.Domain.Models.CtrlCloud.Article;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.Dapper;

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

    public interface ISystemArticleDapperRepository : IDapperRepository
    {

    }
}
