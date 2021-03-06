using Ctrl.Core.Entities;
using Ctrl.Core.Entities.Dtos;
using Ctrl.Core.Entities.Tree;
using Ctrl.Domain.Models.Dtos.Permission;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CtrlCloud.Framework.Application.Contracts.CtrlCloud.Permission.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Ctrl.System.Business
{
    /// <summary>
    /// 系统菜单业务逻辑接口
    /// </summary>
    public interface ISystemMenuLogic: ICrudAppService<SystemMenuDto, Guid>, IScopedDependency
    {
        /// <summary>
        ///     保存菜单
        /// </summary>
        /// <param name="systemMenu"></param>
        /// <returns></returns>
        Task<OperateStatus> SaveMenu (CreateMenuDto systemMenu);
        /// <summary>
        ///     根据状态为True的菜单信息
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TreeEntity>> GetAllMenu ();
        /// <summary>
        /// 根据父级查询下级
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<IEnumerable<SystemMenuDto>> GetMenuByPid (IdInput input);
         /// <summary>
        ///   删除菜单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<OperateStatus>DeleteMenu(IdInput input);
    }
}