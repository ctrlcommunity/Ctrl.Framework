using Ctrl.Domain.Models.Entities;
using Ctrl.Domain.Models.Enums;
using System;
using System.Threading.Tasks;
using CtrlCloud.Framework.Domain.Models.CtrlCloud.Permission;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.Dapper;

namespace Ctrl.System.DataAccess
{
    public interface ISystemPermissionUserRepository: IRepository<SystemPermissionUser>
    {
    }

    public interface ISystemPermissionUserDapperRepository : IDapperRepository
    {
        /// <summary>
        ///     根据用户Id删除权限用户信息
        /// </summary>
        /// <param name="privilegeMaster"></param>
        /// <param name="privilegeMasterValue"></param>DeletePermissionUser
        /// <returns></returns>     
        Task<bool> DeletePermissionUser(EnumPrivilegeMaster privilegeMaster, Guid privilegeMasterValue);

        /// <summary>
        ///     删除用户
        /// </summary>
        /// <param name="privilegeMasterUserId">用户Id</param>
        /// <param name="privilegeMaster">归属人员类型:组织机构、角色</param>
        /// <returns></returns>
        Task<bool> DeletePrivilegeMasterUser(string privilegeMasterUserId,
            EnumPrivilegeMaster privilegeMaster);
    }
}