using Ctrl.Core.Entities.Dtos;
using Ctrl.Core.Entities.Paging;
using Ctrl.Core.EntityFrameworkCore.EntityFrameworkCore;
using Ctrl.Core.PetaPoco;
using Ctrl.Domain.Models.Dtos.Identity;
using Ctrl.Domain.Models.Dtos.Permission;
using Ctrl.System.DataAccess;
using Ctrl.System.Models.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.Dapper;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Ctrl.Domain.DataAccess.Permission
{
    public class SystemMenuButtonRepository : EfCoreRepository<CtrlDbContext, SystemMenuButton, Guid>, ISystemMenuButtonRepository, IScopedDependency
    {
        public SystemMenuButtonRepository(IDbContextProvider<CtrlDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }

    /// <summary>
    ///     菜单按钮数据访问接口实现
    /// </summary>
    public class SystemMenuButtonDapperRepository : DapperRepository<CtrlDbContext>, ISystemMenuButtonDapperRepository, IScopedDependency
    {
        public SystemMenuButtonDapperRepository(IDbContextProvider<CtrlDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        /// <summary>
        ///     根据菜单项获取功能项信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public  Task<IEnumerable<SystemMenuButtonOutput>> GetMenuButtonByMenuId(IdInput input)
        {
            var sb = new StringBuilder();
            sb.Append("SELECT f.*,menu.Name MenuName FROM Sys_MenuButton f LEFT JOIN Sys_Menu menu ON menu.MenuId=f.MenuId WHERE 1=1");
            if (!string.IsNullOrWhiteSpace(input.Id))
            {
                sb.AppendFormat(" AND f.MenuId='{0}'", input.Id);
            }
            return SqlMapperUtil.Query<SystemMenuButtonOutput>(sb.ToString());
        }
        /// <summary>
        ///     根据用户编码获取权限按钮
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="isAdmin"></param> 
        /// <returns></returns>
        public Task<IEnumerable<AuthMenuButtonOutput>> GetMenuButtonByUserId(string userId, bool isAdmin)
        { 
            StringBuilder sql = new StringBuilder();
            sql.Append(@"	SELECT
	                            func.* ,menu.Area,menu.Controller,menu.Action
                            FROM
	                            sys_menubutton func
	                            LEFT JOIN sys_menu menu ON func.MenuId = menu.MenuId
	                            LEFT JOIN sys_permission sper ON sper.PrivilegeAccessValue = func.Id
	                            LEFT JOIN sys_permissionuser spuser ON sper.PrivilegeMasterValue = spuser.PrivilegeMasterValue
	                            WHERE 1=1 ");
            if (!isAdmin)
            {
                sql.AppendFormat(" and spuser.PrivilegeMasterUserId='{0}'", userId);
            }
            sql.Append("	order by OrderNo desc");
            return DbConnection.QueryAsync<AuthMenuButtonOutput>(sql.ToString(),transaction: DbTransaction);
        }

        /// <summary>
        ///     获取按钮分页查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public Task<PagedResultsDto<SystemMenuButtonOutput>> GetPagingMenuButton(QueryParam param)
        {
            string sql = @"select button.*,menu.Name menuname
                        from Sys_MenuButton button
                        left join Sys_Menu menu on button.MenuId=menu.MenuId";
            return SqlMapperUtil.PagingQuery<SystemMenuButtonOutput>(sql, param);
        }

    }

    
}
