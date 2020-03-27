using Ctrl.Core.Entities;
using Ctrl.Domain.Models.Dtos.Article;
using Ctrl.Domain.Models.Entities;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Ctrl.System.Business
{
    /// <summary>
    /// 文章业务逻辑接口
    /// </summary>
    public interface ISystemArticleLogic: ICrudAppService<SystemArticleDto, Guid>, IScopedDependency
    {
        /// <summary>
        ///     保存文章
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        Task<OperateStatus> SaveArticle(SystemArticle article);
        /// <summary>
        ///     获取文章分页
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<PagedResultDto<SystemArticleDto>> GetPagingArticle(SystemArticleResultRequestDto param);
    }
}
