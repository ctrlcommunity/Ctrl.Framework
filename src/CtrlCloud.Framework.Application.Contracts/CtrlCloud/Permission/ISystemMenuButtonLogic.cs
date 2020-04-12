using Ctrl.Core.Entities;
using Ctrl.Core.Entities.Dtos;
using Ctrl.Core.Entities.Paging;
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
    /// 菜单按钮业务逻辑接口
    /// </summary>
    public interface ISystemMenuButtonLogic : ICrudAppService<SystemMenuButtonDto, Guid>, IScopedDependency
    {
        /// <summary>
        ///     获取按钮分页信息
        /// </summary>
        /// <param name="queryParam">分页信息</param>
        /// <returns></returns>
        Task<PagedResultsDto<SystemMenuButtonDto>> GetPagingMenuButton(QueryParam param);

        /// <summary>
        ///     保存功能项信息
        /// </summary>
        /// <param name="menuButton">功能项信息</param>
        /// <returns></returns>
        OperateStatus SaveMenuButton(CreateMenuButtonDto menuButton);
        /// <summary>
        ///     根据菜单获取功能项信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<IEnumerable<SystemMenuButtonDto>> GetMenuButtonByMenuId(IdInput input);
    }
}
