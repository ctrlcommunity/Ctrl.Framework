using Ctrl.Core.Core.Utils;
using Ctrl.Core.Entities;
using Ctrl.Core.Entities.Dtos;
using Ctrl.Core.Entities.Paging;
using Ctrl.Domain.Models.Dtos.Permission;
using Ctrl.System.DataAccess;
using Ctrl.System.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Ctrl.System.Business
{
    /// <summary>
    ///     菜单按钮业务逻辑接口实现
    /// </summary>
    //public class SystemMenuButtonLogic:AsyncLogic<SystemMenuButton>,ISystemMenuButtonLogic
    public class SystemMenuButtonLogic : CrudAppService<SystemMenuButton, SystemMenuButtonOutput, Guid>, ISystemMenuButtonLogic, IScopedDependency
    {
        #region 构造函数
        private readonly ISystemMenuButtonRepository _systemMenuButtonRepository;
        private readonly ISystemMenuButtonDapperRepository _systemMenuButtonDapperRepository;

        public SystemMenuButtonLogic(IRepository<SystemMenuButton, Guid> repository,
            ISystemMenuButtonRepository systemMenuButtonRepository, ISystemMenuButtonDapperRepository systemMenuButtonDapperRepository) : base(repository)
        {
            this._systemMenuButtonDapperRepository = systemMenuButtonDapperRepository;
            this._systemMenuButtonRepository = systemMenuButtonRepository;


        }
        #endregion

        #region 方法

        /// <summary>
        ///     获取按钮分页
        /// </summary>
        /// <returns></returns>
        public Task<PagedResultsDto<SystemMenuButtonOutput>> GetPagingMenuButton(QueryParam param)
        {
            return _systemMenuButtonDapperRepository.GetPagingMenuButton(param);
        }
        /// <summary>
        ///     保存功能项信息  
        /// </summary>
        /// <returns>功能项信息</returns>
        public async Task<OperateStatus> SaveMenuButton(SystemMenuButton menuButton)
        {
            if (menuButton.Id.IsEmptyGuid())
            {
                menuButton.CreateTime = DateTime.Now;
                //TODO 先注释
                //menuButton.Id = CombUtil.NewComb();
                //return await InsertAsync(menuButton);
            }
            else {
                //TODO 先注释
                //var  sysbutton=await _systemMenuButtonRepository.GetById(menuButton.MenuButtonId);
              //  menuButton.CreateTime = sysbutton.CreateTime;
                //return await UpdateAsync(menuButton);
            }
            return null;
        }
        /// <summary>
        ///     根据菜单获取功能项信息
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<SystemMenuButtonOutput>> GetMenuButtonByMenuId(IdInput input) {
            return _systemMenuButtonDapperRepository.GetMenuButtonByMenuId(input);
        }
        #endregion
    }
}