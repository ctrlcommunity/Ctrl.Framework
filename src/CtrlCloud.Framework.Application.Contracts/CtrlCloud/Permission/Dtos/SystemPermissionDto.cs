using System;

namespace CtrlCloud.Framework.Application.Contracts.CtrlCloud.Permission.Dtos
{
    public class SystemPermissionDto
    {
        /// <summary>
        /// 权限归属(0菜单、1按钮、字段等)
        /// </summary>
        public short PrivilegeAccess { get; set; }

        /// <summary>
        /// 对应类型主键值(角色id,人员id,组id,岗位id,)
        /// </summary>
        public Guid PrivilegeMasterValue { get; set; }

        /// <summary>
        /// 对应权限归属主键(菜单id,按钮id等)
        /// </summary>
        public string PrivilegeAccessValue { get; set; }

        /// <summary>
        ///  
        /// </summary>
        public short PrivilegeMaster { get; set; }

        /// <summary>
        /// 菜单ID
        /// </summary>
        public Guid PrivilegeMenuId { get; set; }
    }
}
