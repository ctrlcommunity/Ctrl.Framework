using Ctrl.Core.DataAccess;
using Ctrl.Core.Entities.Paging;
using Ctrl.Core.EntityFrameworkCore.EntityFrameworkCore;
using Ctrl.Core.PetaPoco;
using Ctrl.Domain.Models.Dtos.Article;
using Ctrl.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Ctrl.System.DataAccess
{
    public class SystemArticleRepository : EfCoreRepository<CtrlDbContext, SystemArticle, Guid>, ISystemArticleRepository
    {
        public SystemArticleRepository(IDbContextProvider<CtrlDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<long> GetCountAsync(SystemArticleResultRequestDto input, CancellationToken cancellationToken = default)
        {
            //{No property or field 'article' exists in type 'SystemArticle' (at index 0)}
            return await this.WhereIf(
                 !input.Title.IsNullOrEmpty(),
                 o => o.Title.Contains(input.Title)
             )
             .LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<SystemArticle>> GetPagingArticleType(SystemArticleResultRequestDto param,
             CancellationToken cancellationToken = default)
        {
            return await DbSet.WhereIf(
                !param.Title.IsNullOrEmpty(),
                a=>a.Title.Contains(param.Title)
                )
              .OrderBy(param.Sorting ?? nameof(SystemArticle.CreateTime))
              .PageBy(param.SkipCount, param.MaxResultCount)
              .ToListAsync(GetCancellationToken(cancellationToken));
        }
    }


    ///// <summary>
    /////     文章数据访问接口实现
    ///// </summary>
    //public class SystemArticleRepository : PetaPocoRepository<SystemArticle>, ISystemArticleRepository, IScopedDependency
    //{
    //    /// <summary>
    //    ///     获取文章分页
    //    /// </summary>
    //    /// <param name="param"></param>
    //    /// <returns></returns>
    //    public Task<PagedResultsDto<SystemArticleOutput>> GetPagingArticleType(SystemArticlePagingInput param)
    //    {
    //        string sWhere = "";
    //        if (!string.IsNullOrWhiteSpace(param.Title))
    //        {
    //            sWhere += $" And Title like '%{param.Title.Trim()}%'";
    //        }
    //        string sql = @"select article.*,articletype.Name ArticleTypeName
    //                        from Sys_Article article
    //                        left join Sys_ArticleType articletype on article.ArticleTypeId=articletype.ArticleTypeId
    //                          Where 1=1 "+sWhere;
    //        return SqlMapperUtil.PagingQuery<SystemArticleOutput>(sql, param); ;
    //    }
    //}
}
