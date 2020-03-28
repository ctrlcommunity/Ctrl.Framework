using Ctrl.Core.Core.Utils;
using Ctrl.Core.Entities.Dtos;
using Ctrl.Core.Entities.Paging;
using Ctrl.Core.EntityFrameworkCore.EntityFrameworkCore;
using Ctrl.Core.PetaPoco;
using Ctrl.Domain.Models.Dtos;
using Ctrl.Domain.Models.Dtos.Identity;
using Ctrl.Domain.Models.Entities;
using Dapper;
using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.Dapper;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Ctrl.Domain.DataAccess.Identity
{
    public class SystemUserDapperRepository : DapperRepository<CtrlDbContext>, ISystemUserDapperRepository,IScopedDependency
    {
        /// <summary>
        ///     根据用户名和密码查询用户信息
        ///     1:用户登录使用
        /// </summary>
        /// <param name="input">用户名、密码等</param>
        /// <returns></returns>
        public Task<UserLoginOutput> CheckUserByCodeAndPwd(UserLoginInput input)
        {
            var sql = @"select sysUser.Id,sysUser.Code,sysUser.Name,sysUser.IsAdmin,role.Name RoleName,sysUser.IsFreeze,sysUser.FirstVisitTime,sysUser.ImgUrl  from Sys_User sysUser
                    left join Sys_PermissionUser per on sysUser.Id=per.PrivilegeMasterUserId
                    left join Sys_Role role on  role.Id=per.PrivilegeMasterValue
                    where sysUser.Code=@Code and sysUser.Password=@pwd";

            return DbConnection.QueryFirstOrDefaultAsync<UserLoginOutput>(sql,
                new {input.Code, pwd = input.Password},DbTransaction);

        }
        /// <summary>
        ///     获取用户列表
        /// </summary>
        /// <param name="queryParam">分页参数</param>
        /// <returns></returns>
        public Task<PagedResultsDto<SystemUser>> GetPagingSysUser(QueryParam queryParam)
        {
            var sql = "SELECT * FROM Sys_User sysUser";
            return SqlMapperUtil.PagingQuery<SystemUser>(sql, queryParam);
        }

        /// <summary>
        ///     更新最后登录时间
        /// </summary>
        /// <param name="input">用户Id</param>
        /// <returns></returns>
        public async Task<bool> UpdateLastLoginTime(IdInput input)
        {
            var sql = $@"UPDATE Sys_User SET LastVisitTime='{DateTime.Now.ToString("yyyy-MM-dd H:mm:ss")}' WHERE Id=@userId";
            return (await DbConnection.ExecuteAsync(sql, new {userId = input.Id},DbTransaction))>0;
        }

        /// <summary>
        ///     更新第一次登录时间
        /// </summary>
        /// <param name="input">用户Id</param>
        /// <returns></returns>
        public async Task<bool> UpdateFirstVisitTime(IdInput input)
        {
            var sql = $@"UPDATE Sys_User SET FirstVisitTime='{DateTime.Now.ToString("yyyy-MM-dd H:mm:ss")}' WHERE Id=@userId";
            return (await DbConnection.ExecuteAsync(sql, new { userId = input.Id }, DbTransaction))>0;
        }
        /// <summary>
        ///     用户信息修改
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Task<bool> UserInfoUpdateSave(UpdateUserDto input)
        {
            const string sql = @"UPDATE Sys_User 
                                SET ImgUrl=@ImgUrl,
                                Name=@Name
                                WHERE Id=@userId";
            return SqlMapperUtil.InsertUpdateOrDeleteSqlBool(sql, input);
        }
        /// <summary>
        ///     检测代码是否已经具有重复项
        /// </summary>
        /// <param name="input">需要验证的参数</param>
        /// <returns></returns>
        public Task<bool> CheckUserCode(CheckSameValueInput input)
        {
            string sql = "select UserId from Sys_User where Code=@param";
            if (!input.Id.IsNullOrEmptyGuid())
            {
                sql += " And Id!=@UserId";
            }
            return SqlMapperUtil.SqlWithParamsBool<SystemUser>(sql, new { param = input.Param, UserId = input.Id });
        }
        public SystemUserDapperRepository(IDbContextProvider<CtrlDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }



    public class SystemUserRepository : EfCoreRepository<CtrlDbContext,SystemUser,Guid>, ISystemUserRepository
    {

        public SystemUserRepository(IDbContextProvider<CtrlDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

    }
}
