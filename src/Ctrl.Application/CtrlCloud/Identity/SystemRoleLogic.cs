using Ctrl.Core.Entities;
using Ctrl.Core.Entities.Tree;
using Ctrl.Domain.Models.Dtos.Identity;
using Ctrl.System.DataAccess;
using Ctrl.System.Models.Entities;
using CtrlCloud.Framework.Application.Contracts.CtrlCloud.Identity.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CtrlCloud.Framework.Domain.Models.CtrlCloud.Identity;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Ctrl.System.Business
{
    /// <summary>
    ///     角色表业务逻辑接口实现
    /// /// </summary>
    public class SystemRoleLogic:CrudAppService<SystemRole,SystemRoleDto,Guid>,ISystemRoleLogic, IScopedDependency
    {
        #region 构造函数
        private readonly ISystemRoleRepository _systemRoleRepository;

        public SystemRoleLogic(IRepository<SystemRole, Guid> repository,ISystemRoleRepository systemRoleRepository) : base(repository)
        {
            _systemRoleRepository = systemRoleRepository;
        }
        #endregion

        #region 方法
        /// <summary>
        ///     保存角色信息
        /// </summary>
        /// <param name="role">角色信息</param>
        /// <returns></returns>
        public  Task<OperateStatus> SaveRole(CreateRoleDto role)
        {
            //if (role.Id.IsEmptyGuid())
            //{
            //    role.CreateTime = DateTime.Now;
            //   // role.RoleId = Guid.NewGuid();
            //    //return InsertAsync(role);
            //    return null;
            //}
            return null;
        }
        /// <summary>
        ///     获取角色分页
        /// </summary>
        /// <param name="queryParam">分页信息</param>
        /// <returns></returns>
        public Task<PagedResultDto<SystemRoleDto>> GetPagingSysRole(PagedAndSortedResultRequestDto queryParam)
        {
            return  GetListAsync(queryParam);
        }
        /// <summary>
        ///     获取角色树
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<TreeEntity>> GetAllRoleTree()
        {
            return _systemRoleRepository.GetAllRoleTree();
        }
        #endregion
    }
}