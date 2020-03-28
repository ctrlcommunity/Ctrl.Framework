using Ctrl.Core.Entities;
using Ctrl.Domain.Models.Dtos.Article;
using Ctrl.Domain.Models.Entities;
using Ctrl.System.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CtrlCloud.Framework.Application.Contracts.CtrlCloud.Article.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Ctrl.System.Business
{
    /// <summary>
    ///     文章业务逻辑接口实现
    /// </summary>
    public class SystemArticleLogic : CrudAppService<SystemArticle, SystemArticleDto, Guid>,ISystemArticleLogic, IScopedDependency
    {

        #region 构造函数
        private readonly ISystemArticleRepository _systemArticleRepository;

        public SystemArticleLogic(IRepository<SystemArticle, Guid> repository,ISystemArticleRepository articleRepository) : base(repository)
        {
            this._systemArticleRepository=articleRepository;
        }

        //public SystemArticleLogic(IRepository<SystemArticle, Guid> repository,
        //     ISystemArticleRepository systemArticleRepository) : base(repository)
        //{
        //    this._systemArticleRepository = systemArticleRepository;
        //}
        #endregion

        #region 方法
        /// <summary>
        ///     保存文章
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public Task<OperateStatus> SaveArticle(CreateArticleDto article)
        {
            return null;
            //if (article.ArticleId.IsEmptyGuid())
            //{
            //    article.ArticleId = CombUtil.NewComb();
            //    return  InsertAsync(article);
            //}
            //else {
            //    return  UpdateAsync(article);
            //}
        }
        /// <summary>
        ///     获取文章分页
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<SystemArticleDto>> GetPagingArticle(SystemArticleResultRequestDto param)
        {
            var list = await _systemArticleRepository.GetPagingArticleType(param);
            var totalCount = await _systemArticleRepository.GetCountAsync(param);

            return new PagedResultDto<SystemArticleDto>(
                totalCount,
                ObjectMapper.Map<List<SystemArticle>, List<SystemArticleDto>>(list)
                );
        }

        #endregion

  
    }
}