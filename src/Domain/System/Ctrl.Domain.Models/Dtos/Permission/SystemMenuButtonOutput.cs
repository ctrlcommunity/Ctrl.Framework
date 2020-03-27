using Ctrl.Core.Entities.Dtos;
using Ctrl.System.Models.Entities;
using System;
using Volo.Abp.Application.Dtos;

namespace Ctrl.Domain.Models.Dtos.Permission
{
    /// <summary>
    ///     按钮输出类
    /// </summary>
    public class SystemMenuButtonOutput:SystemMenuButton, IEntityDto<Guid>
    {
        /// <summary>
        ///     菜单名称
        /// </summary>
        //public string MenuName { get; set; }
        public Guid Id { get; set; }

    }
}
