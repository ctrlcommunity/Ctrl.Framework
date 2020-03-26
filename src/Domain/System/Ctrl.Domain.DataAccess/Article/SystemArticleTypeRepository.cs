using Ctrl.Core.Entities.Paging;
using Ctrl.Core.Entities.Tree;
using Ctrl.Core.EntityFrameworkCore.EntityFrameworkCore;
using Ctrl.Core.PetaPoco;
using Ctrl.Domain.Models.Dtos.Article;
using Ctrl.System.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Ctrl.System.DataAccess
{
    /// <summary>
    ///     文章类型数据访问接口实现
    /// </summary>
    public class SystemArticleTypeRepository : EfCoreRepository<CtrlDbContext, SystemArticleType, Guid>, ISystemArticleTypeRepository
    {
        public SystemArticleTypeRepository(IDbContextProvider<CtrlDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        /// <summary>
        ///     获取文章类型树
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<TreeEntity>> GetArticleTypeTree()
        {
            string sql = "select Name,ArticleTypeId id,ParentId pId from Sys_ArticleType";
            return SqlMapperUtil.Query<TreeEntity>(sql);
        }

        public async Task<long> GetCountAsync(SystemArticleResultRequestDto input, CancellationToken cancellationToken = default)
        {
            return await this
               .LongCountAsync(GetCancellationToken(cancellationToken));
        }

        /// <summary>
        ///     获取文章类型分页
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public virtual async Task<List<SystemArticleType>> GetListAsync(
                PagedAndSortedResultRequestDto input,
                CancellationToken cancellationToken = default)
        {
            return await DbSet
                .OrderBy(input.Sorting ?? nameof(SystemArticleType.CreateTime))
                .PageBy(input.SkipCount, input.MaxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }
    }
}
