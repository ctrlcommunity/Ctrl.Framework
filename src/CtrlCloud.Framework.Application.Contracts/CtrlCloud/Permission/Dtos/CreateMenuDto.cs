using System;

namespace CtrlCloud.Framework.Application.Contracts.CtrlCloud.Permission.Dtos
{
    public class CreateMenuDto
    {
        /// <summary>
        /// 主键编码
        /// </summary>
        public Guid MenuId { get; set; }

        /// <summary>
        /// 父级id
        /// </summary>
        public Guid ParentId { get; set; }

        /// <summary>
        ///  
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 打开类型
        /// </summary>
        public byte[] OpenType { get; set; }
        /// <summary>
        ///     按钮
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        ///  区域
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        ///  控制器
        /// </summary>
        public string Controller { get; set; }

        /// <summary>
        ///  方法
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// 打开地址
        /// </summary>
        public string OpenUrl { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        ///  排序
        /// </summary>
        public int OrderNo { get; set; }

        /// <summary>
        /// 允许删除
        /// </summary>
        public bool CanbeDelete { get; set; }
        /// <summary>
        ///  冻结
        /// </summary>
        public bool IsFreeze { get; set; }

        /// <summary>
        ///  显示
        /// </summary>
        public bool IsShowMenu { get; set; }
        public CreateMenuDto() { }
        public CreateMenuDto(Guid menuId, Guid parentId, string code, string name, byte[] openType, string icon, string area, string controller, string action, string openUrl, string remark, int orderNo, bool canbeDelete, bool isFreeze, bool isShowMenu)
        {
            MenuId = menuId;
            ParentId = parentId;
            Code = code;
            Name = name;
            OpenType = openType;
            Icon = icon;
            Area = area;
            Controller = controller;
            Action = action;
            OpenUrl = openUrl;
            Remark = remark;
            OrderNo = orderNo;
            CanbeDelete = canbeDelete;
            IsFreeze = isFreeze;
            IsShowMenu = isShowMenu;
        }
    }
}
