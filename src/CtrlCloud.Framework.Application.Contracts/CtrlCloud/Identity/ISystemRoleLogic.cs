using Ctrl.Core.Entities;
using Ctrl.Core.Entities.Tree;
using Ctrl.Domain.Models.Dtos.Identity;
using CtrlCloud.Framework.Application.Contracts.CtrlCloud.Identity.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Ctrl.System.Business
{
    /// <summary>
    /// 角色表业务逻辑接口
    /// </summary>
    public interface ISystemRoleLogic: ICrudAppService<SystemRoleDto, Guid> 
    {
        /// <summary>
        ///     保存角色信息
        /// </summary>
        /// <param name="role">角色信息</param>
        /// <returns></returns>
        Task<OperateStatus> SaveRole(CreateRoleDto role);

        /// <summary>
        ///     获取角色分页信息
        /// </summary>
        /// <param name="queryParam">分页信息</param>
        /// <returns></returns>
        Task<PagedResultDto<SystemRoleDto>> GetPagingSysRole(PagedAndSortedResultRequestDto queryParam);
        /// <summary>
        ///     获取角色树
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TreeEntity>> GetAllRoleTree();


    }
}
