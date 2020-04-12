using Ctrl.Core.Entities.Paging;
using Ctrl.Core.Entities.Tree;
using Ctrl.System.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using CtrlCloud.Framework.Domain.Models.CtrlCloud.Identity;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.Dapper;

namespace Ctrl.System.DataAccess
{
    /// <summary>
    /// 角色表数据访问接口
    /// </summary>
    public interface ISystemRoleRepository: IDapperRepository
    {
        /// <summary>
        ///     获取角色分页信息
        /// </summary>
        /// <param name="queryParam">分页信息</param>
        /// <returns></returns>
        Task<PagedResultsDto<SystemRole>> GetPagingSysRole(QueryParam queryParam);

        /// <summary>
        ///     获取所有角色
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TreeEntity>> GetAllRoleTree();
    }
}
