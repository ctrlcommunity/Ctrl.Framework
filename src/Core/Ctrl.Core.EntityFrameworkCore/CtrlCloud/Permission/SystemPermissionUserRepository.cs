using Ctrl.Core.EntityFrameworkCore.EntityFrameworkCore;
using Ctrl.Domain.Models.Entities;
using Ctrl.Domain.Models.Enums;
using Ctrl.System.DataAccess;
using Dapper;
using System;
using System.Threading.Tasks;
using CtrlCloud.Framework.Domain.Models.CtrlCloud.Permission;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.Dapper;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace CtrlCloud.Framework.EntityFrameworkCore.CtrlCloud.Permission
{
    /// <summary>
    ///     权限记录表数据访问接口实现
    /// </summary>
    public class SystemPermissionUserRepository : EfCoreRepository<CtrlDbContext, SystemPermissionUser, Guid>, ISystemPermissionUserRepository
    {
        public SystemPermissionUserRepository(IDbContextProvider<CtrlDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }

    public class SystemPermissionUserDapperRepository : DapperRepository<CtrlDbContext>,
        ISystemPermissionUserDapperRepository,
        IScopedDependency
    {
        public SystemPermissionUserDapperRepository(IDbContextProvider<CtrlDbContext> dbContextProvider) : base(
            dbContextProvider)
        {
        }
        /// <summary>
        ///     根据特性id删除权限用户信息
        /// </summary>
        /// <param name="privilegeMaster">特性类型：组织机构、角色等</param>
        /// <param name="privilegeMasterValue">特性类型：组织机构、角色等</param>
        /// <returns></returns>
        public async Task<bool> DeletePermissionUser(EnumPrivilegeMaster privilegeMaster, Guid privilegeMasterValue)
        {
            const string sql = "DELETE FROM Columns WHERE PrivilegeMaster=@privilegeMaster AND PrivilegeMasterValue=@privilegeMasterValue";
            return (await this.DbConnection.ExecuteAsync(sql,
                new
                {
                    privilegeMaster = (byte)privilegeMaster,
                    privilegeMasterValue
                })) > 0;
        }
        /// <summary>
        ///     删除用户
        /// </summary>
        /// <param name="privilegeMasterUserId">用户Id</param>
        /// <param name="privilegeMaster">归属人员类型:组织机构、角色</param>
        /// <returns></returns>
        public async Task<bool> DeletePrivilegeMasterUser(string privilegeMasterUserId, EnumPrivilegeMaster privilegeMaster)
        {
            const string sql = "DELETE FROM System_PermissionUser WHERE PrivilegeMaster=@privilegeMaster AND PrivilegeMasterUserId=@privilegeMasterUserId";
            return (await this.DbConnection.ExecuteAsync(sql, new { privilegeMaster = (byte)privilegeMaster, privilegeMasterUserId })>0);
        }

    }
}