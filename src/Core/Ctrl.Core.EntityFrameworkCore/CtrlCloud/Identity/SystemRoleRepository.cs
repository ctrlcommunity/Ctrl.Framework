using System.Collections.Generic;
using System.Threading.Tasks;
using Ctrl.Core.Entities.Paging;
using Ctrl.Core.Entities.Tree;
using Ctrl.Core.EntityFrameworkCore.EntityFrameworkCore;
using Ctrl.System.DataAccess;
using Ctrl.System.Models.Entities;
using CtrlCloud.Framework.Domain.Models.CtrlCloud.Identity;
using Dapper;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.Dapper;
using Volo.Abp.EntityFrameworkCore;

namespace CtrlCloud.Framework.EntityFrameworkCore.CtrlCloud.Identity
{
    /// <summary>
    ///     角色表数据访问接口实现
    /// </summary>
    public class SystemRoleRepository : DapperRepository<CtrlDbContext>, ISystemRoleRepository, IScopedDependency
    {
        /// <summary>
        ///     获取所有角色
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<TreeEntity>> GetAllRoleTree()
        {
            var sql = @"select  roles.Name,roles.RoleId id
                        from Sys_Role roles";
            return this.DbConnection.QueryAsync<TreeEntity>(sql);
        }

        /// <summary>
        ///     获取角色分页数据
        /// </summary>
        /// <param name="queryParam"></param>
        /// <returns></returns>
        public Task<PagedResultsDto<SystemRole>> GetPagingSysRole(QueryParam queryParam)
        {
            //var sql = "SELECT * FROM Sys_Role";
            return null;
            //return SqlMapperUtil.PagingQuery<SystemRole>(sql, queryParam);
        }

        public SystemRoleRepository(IDbContextProvider<CtrlDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
