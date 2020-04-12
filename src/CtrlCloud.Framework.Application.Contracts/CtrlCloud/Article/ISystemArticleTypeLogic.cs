using Ctrl.Core.Entities;
using Ctrl.Domain.Models.Dtos.Article;
using CtrlCloud.Framework.Application.Contracts.CtrlCloud.Article.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ctrl.Core.Entities.Tree;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Ctrl.System.Business
{
    /// <summary>
    /// 文章类型业务逻辑接口
    /// </summary>
    public interface ISystemArticleTypeLogic : ICrudAppService<ArticleTypeDto, Guid>, IScopedDependency
    {
        /// <summary>
        ///     保存文章类型
        /// </summary>
        /// <param name="articleType"></param>
        /// <returns></returns>
        OperateStatus SaveArticleType(CreateArticleTypeDto articleType);
        /// <summary>
        ///     获取文章类型树 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TreeEntity>> GetArticleTypeTree();
        /// <summary>
        ///     获取文章类型分页
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<PagedResultDto<ArticleTypeDto>> GetPagingArticleType(SystemArticleResultRequestDto param);
    }
}
