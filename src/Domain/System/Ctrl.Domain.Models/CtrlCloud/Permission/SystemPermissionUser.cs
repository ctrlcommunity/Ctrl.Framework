using System;
using Volo.Abp.Domain.Entities;

namespace CtrlCloud.Framework.Domain.Models.CtrlCloud.Permission
{
    /// <summary>
    /// System_PermissionUser表实体类
    /// </summary>
    public class SystemPermissionUser:Entity<Guid>
    {
         /// <summary>
        /// 人员归属类型:角色0,组织机构1,人员4(用于查询某用户具有哪些岗位、组等)
        /// </summary>		
        public int PrivilegeMaster { get; set; }

        /// <summary>
        /// 对应类型Id(角色Id,岗位Id,人员Id)
        /// </summary>		
        public string PrivilegeMasterValue { get; set; }

        /// <summary>
        /// 人员Id
        /// </summary>		
        public string PrivilegeMasterUserId { get; set; }

    }
}