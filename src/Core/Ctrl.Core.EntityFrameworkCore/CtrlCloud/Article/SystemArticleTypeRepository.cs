using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Ctrl.Core.Entities.Tree;
using Ctrl.Core.EntityFrameworkCore.EntityFrameworkCore;
using Ctrl.Domain.Models.Dtos.Article;
using Ctrl.System.DataAccess;
using Ctrl.System.Models.Entities;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.Dapper;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace CtrlCloud.Framework.EntityFrameworkCore.CtrlCloud.Article
{
    /// <summary>
    ///     文章类型数据访问接口实现
    /// </summary>
    public class SystemArticleTypeRepository : EfCoreRepository<CtrlDbContext, SystemArticleType, Guid>, ISystemArticleTypeRepository
    {
        public SystemArticleTypeRepository(IDbContextProvider<CtrlDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        public async Task<long> GetCountAsync(SystemArticleResultRequestDto input, CancellationToken cancellationToken = default)
        {
            return await this
               .LongCountAsync(GetCancellationToken(cancellationToken));
        }

        /// <summary>
        ///     获取文章类型分页
        /// </summary>
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

    public class SystemArticleTypeDapperRepository : DapperRepository<CtrlDbContext>, ISystemArticleTypeDapperRepository,
        IScopedDependency
    {
        public SystemArticleTypeDapperRepository(IDbContextProvider<CtrlDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        /// <summary>
        ///     获取文章类型树
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<TreeEntity>> GetArticleTypeTree()
        {
            var sql = "select Name,ArticleTypeId id,ParentId pId from Sys_ArticleType";
            return DbConnection.QueryAsync<TreeEntity>(sql);
        }
    }
}
