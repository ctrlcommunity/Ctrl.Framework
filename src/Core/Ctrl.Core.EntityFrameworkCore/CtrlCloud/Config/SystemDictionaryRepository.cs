using Ctrl.Core.Entities.Dtos;
using Ctrl.Core.Entities.Select2;
using Ctrl.Core.Entities.Tree;
using Ctrl.Core.EntityFrameworkCore.EntityFrameworkCore;
using Ctrl.Domain.Models.Dtos.Config;
using Ctrl.System.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Ctrl.System.DataAccess
{
    /// <summary>
    ///     字典数据访问接口实现
    /// </summary>
    public class SystemDictionaryRepository : EfCoreRepository<CtrlDbContext, SystemDictionary, Guid>, ISystemDictionaryRepository
    {
        public SystemDictionaryRepository(IDbContextProvider<CtrlDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<long> GetCountAsync(SystemDictionaryResultRequestDto input, CancellationToken cancellationToken = default)
        {
            return await this
              .WhereIf(
               !input.Id.IsNullOrEmpty(),
               o => o.Id == Guid.Parse(input.Id)
              )
    .LongCountAsync(GetCancellationToken(cancellationToken));
        }

        /// <summary>
        ///     获取字典树
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<TreeEntity>> GetDictionaryTree()
        {
           // const string sql = "select Name,DictionaryId id,ParentId pId from Sys_Dictionary";
           //return SqlMapperUtil.Query<TreeEntity>(sql);
           return null;
        }
        /// <summary>
        ///     根据父级编码获取子级
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Task<IEnumerable<Select2Entity>> GetTypeChildrenByCode(IdInput input)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"select sds.DictionaryId id,sds.Name text  from Sys_Dictionary sd
                            left join Sys_Dictionary sds on sds.ParentId=sd.DictionaryId
                            where sd.Code='{0}'
                            order by sds.OrderNo desc", input.Id);
            return null;
            //return SqlMapperUtil.Query<Select2Entity>(sb.ToString());
        }

        /// <summary>
        ///     字典分页信息
        /// </summary>
        /// <returns></returns>
        public async Task<List<SystemDictionary>> PagingDictionaryQuery(SystemDictionaryResultRequestDto input,
             CancellationToken cancellationToken = default)
        {
            return await DbSet
             .WhereIf(
               !input.Id.IsNullOrEmpty(),
               o => o.Id == Guid.Parse(input.Id)
              )
           .OrderBy(input.Sorting ?? nameof(SystemDictionary.CreateTime))
           .PageBy(input.SkipCount, input.MaxResultCount)
           .ToListAsync(GetCancellationToken(cancellationToken));
        }
    }
}
