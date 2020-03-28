using Ctrl.Domain.Models.Dtos.Article;
using System;
using System.Threading.Tasks;
using CtrlCloud.Framework.Application.Contracts.CtrlCloud.Article.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Ctrl.Core.Entities;

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
        Task<OperateStatus> SaveArticle(CreateArticleDto article);
        /// <summary>
        ///     获取文章分页
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<PagedResultDto<SystemArticleDto>> GetPagingArticle(SystemArticleResultRequestDto param);
    }
}
