using System;
using Volo.Abp.Domain.Entities;

namespace CtrlCloud.Framework.Domain.Models.CtrlCloud.Permission
{
    /// <summary>
    ///    菜单按钮表实体类
    /// </summary>
    public class SystemMenuButton: Entity<Guid>
    {

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
        public SystemMenuButton() { }
        public SystemMenuButton(Guid id,Guid menuId, string name, string icon, string script, int orderNo, string remark, DateTime createTime, string code)
        {
            Id = id;
            MenuId = menuId;
            Name = name;
            Icon = icon;
            Script = script;
            OrderNo = orderNo;
            Remark = remark;
            CreateTime = createTime;
            Code = code;
        }
    }
}
