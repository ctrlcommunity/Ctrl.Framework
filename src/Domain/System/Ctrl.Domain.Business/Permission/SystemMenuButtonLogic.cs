using Ctrl.Core.Business;
using Ctrl.Core.Entities;
using Ctrl.System.DataAccess;
using Ctrl.Domain.Models.Dtos;
using Ctrl.System.Models.Entities;
using System.Threading.Tasks;
using Ctrl.Core.Entities.Paging;
using System.Collections.Generic;
using System;
using Ctrl.Core.Core.Utils;
using Ctrl.Domain.Models.Dtos.Permission;
using Ctrl.Core.Entities.Dtos;

namespace Ctrl.System.Business
{
    /// <summary>
    ///     菜单按钮业务逻辑接口实现
    /// </summary>
    public class SystemMenuButtonLogic:AsyncLogic<SystemMenuButton>,ISystemMenuButtonLogic
    {
        #region 构造函数
        private readonly ISystemMenuButtonRepository _systemMenuButtonRepository;
        private readonly ISystemMenuButtonDapperRepository _systemMenuButtonDapperRepository;

        public SystemMenuButtonLogic(ISystemMenuButtonRepository systemMenuButtonRepository,ISystemMenuButtonDapperRepository systemMenuButtonDapperRepository) {
            _systemMenuButtonRepository = systemMenuButtonRepository;
            this._systemMenuButtonDapperRepository = systemMenuButtonDapperRepository;
        }

        #endregion

        #region 方法

        /// <summary>
        ///     获取按钮分页
        /// </summary>
        /// <returns></returns>
        public Task<PagedResults<SystemMenuButtonOutput>> GetPagingMenuButton(QueryParam param)
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
                return await InsertAsync(menuButton);
            }
            else {
                //TODO 先注释
                //var  sysbutton=await _systemMenuButtonRepository.GetById(menuButton.MenuButtonId);
              //  menuButton.CreateTime = sysbutton.CreateTime;
                return await UpdateAsync(menuButton);
            }
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