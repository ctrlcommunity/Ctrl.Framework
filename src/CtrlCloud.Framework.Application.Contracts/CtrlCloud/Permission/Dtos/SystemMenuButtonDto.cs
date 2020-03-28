using System;
using Volo.Abp.Application.Dtos;

namespace Ctrl.Domain.Models.Dtos.Permission
{
    /// <summary>
    ///     按钮输出类
    /// </summary>
    public class SystemMenuButtonDto:IEntityDto<Guid>
    {
        /// <summary>
        ///     菜单名称
        /// </summary>
        //public string MenuName { get; set; }
        public Guid Id { get; set; }


        /// <summary>
        /// 菜单编码
        /// </summary>
        public Guid MenuId { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///     图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 脚本
        /// </summary>
        public string Script { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        public int OrderNo { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        ///     添加时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        ///     权限代码
        /// </summary>
        public string Code { get; set; }
    }
}
