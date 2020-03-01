using Ctrl.Core.Business;
using Ctrl.Core.Core.Resource;
using Ctrl.Core.Core.Security;
using Ctrl.Core.Core.Utils;
using Ctrl.Core.Entities;
using Ctrl.Core.Entities.Dtos;
using Ctrl.Core.Entities.Paging;
using Ctrl.Domain.Business.Permission;
using Ctrl.Domain.DataAccess.Identity;
using Ctrl.Domain.Models.Dtos;
using Ctrl.Domain.Models.Dtos.Identity;
using Ctrl.Domain.Models.Entities;
using Ctrl.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Ctrl.Domain.Business.Identity
{
    /// <summary>
    ///     用户业务逻辑实现
    /// </summary>
    public class SystemUserLogic : AsyncLogic<SystemUser>, ISystemUserLogic,IScopedDependency
    {
        #region 构造函数
        private readonly ISystemUserRepository _systemUserRepository;
        private readonly ISystemPermissionUserLogic _permissionUserLogic;

        public SystemUserLogic(ISystemUserRepository systemUserRepository, ISystemPermissionUserLogic _permissionUserLogic)
        {
            _systemUserRepository = systemUserRepository;
            this._permissionUserLogic = _permissionUserLogic;
        }

        #endregion

        #region 方法
        /// <summary>
        ///     根据登录名和密码查询是否存在
        /// </summary>
        /// <param name="input">登录名、密码等</param>
        /// <returns></returns>
        public async Task<OperateStatus<UserLoginOutput>> CheckUserByCodeAndPwdAsync(UserLoginInput input)
        {
            var operateStatus = new OperateStatus<UserLoginOutput>();
            try
            {
                var data = await _systemUserRepository.CheckUserByCodeAndPwd(input);
                //是否存在
                if (data == null)
                {
                    operateStatus.ResultSign = ResultSign.Error;
                    operateStatus.Message = ResourceSystem.用户名或密码错误;
                    goto End;
                }
                if (data.IsFreeze)
                {
                    operateStatus.ResultSign = ResultSign.Error;
                    operateStatus.Message = ResourceSystem.登录用户已冻结;
                    goto End;
                }
                operateStatus.ResultSign = ResultSign.Successful;
                operateStatus.Message = "登录成功!";
                operateStatus.Message = string.Format(Chs.Successful, "登录成功");
                operateStatus.Data = data;
                if (data.FirstVisitTime == null)
                {
                    //更新用户最后一次登录时间
                    await _systemUserRepository.UpdateFirstVisitTime(new IdInput(data.UserId));
                }
                //更新用户最后一次登录时间
                await _systemUserRepository.UpdateLastLoginTime(new IdInput(data.UserId));
            }
            catch(Exception ex)
            {
                operateStatus.Message = string.Format(Chs.Successful, "登录失败");
                operateStatus.Message = ex.Message;
                goto End;
            }
            End:
            return operateStatus;

        }


        /// <summary>
        ///     用户列表分页
        /// </summary>
        /// <param name="queryParam"></param>
        /// <returns></returns>
        public Task<PagedResults<SystemUser>> GetPagingSysUser(QueryParam queryParam)
        {
            return _systemUserRepository.GetPagingSysUser(queryParam);
        }

        /// <summary>
        ///     保存人员信息
        /// </summary>
        /// <param name="user">人员信息</param>
        /// <returns></returns>
        public async Task<OperateStatus> SaveUser(SystemUserSaveInput user)
        {
            OperateStatus operateStatus;
            if (string.IsNullOrWhiteSpace(user.Id.ToString()))
            {
                user.CreateTime = DateTime.Now;
                user.Password = _3DESEncrypt.Encrypt("123456");
                operateStatus = await InsertAsync(
                    new SystemUser(CombUtil.NewComb(), user.Code, user.Name, user.Password, user.Mobile,
                        user.Email, user.FirstVisitTime, user.LastVisitTime, user.Remark, user.IsAdmin, user.CreateTime,
                        user.IsFreeze, user.ImgUrl));

                if (operateStatus.ResultSign == ResultSign.Successful)
                {
                    //添加用户到组织机构
                    operateStatus = await _permissionUserLogic.SavePermissionUser(EnumPrivilegeMaster.角色, user.RoleId,
                        new List<string> { user.Id.ToString() });
                    if (operateStatus.ResultSign == ResultSign.Successful)
                    {
                        return operateStatus;
                    }
                }
                else
                {
                    return operateStatus;
                }
            }
            else
            {
                //删除对应组织机构
                operateStatus = await _permissionUserLogic.DeletePrivilegeMasterUser(user.Id.ToString(), EnumPrivilegeMaster.角色);
                if (operateStatus.ResultSign == ResultSign.Successful)
                {
                    //添加用户到组织机构
                    operateStatus = await _permissionUserLogic.SavePermissionUser(EnumPrivilegeMaster.角色, user.RoleId, new List<string> { user.Id.ToString() });
                    if (operateStatus.ResultSign == ResultSign.Successful)
                    {
                        var userInfo = await GetById(user.Id);
                        user.Password = userInfo.Password;
                        return await UpdateAsync(user);
                    }
                }
            }
            return operateStatus;
        }
        /// <summary>
        ///     用户信息修改
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<OperateStatus> UserInfoUpdateSave(UserUpdateInput input)
        {
            OperateStatus operateStatus = new OperateStatus() ;
            if (!await _systemUserRepository.UserInfoUpdateSave(input))
            {
                operateStatus.ResultSign = ResultSign.Successful;
                operateStatus.Message = Chs.Successful;
                return operateStatus;
            }
            else {
                operateStatus.ResultSign = ResultSign.Error;
                operateStatus.Message =string.Format(Chs.Error,"修改失败!");
                return operateStatus;
            }
        }
        /// <summary>
        ///     检测代码是否已经具有重复项
        /// </summary>
        /// <param name="input">需要验证的参数</param>
        /// <returns></returns>
        public async Task<OperateStatus> CheckUserCode(CheckSameValueInput input)
        {
            var operateStatus = new OperateStatus();
            if (await _systemUserRepository.CheckUserCode(input))
            {
                operateStatus.ResultSign = ResultSign.Error;
                operateStatus.Message = string.Format(Chs.HaveCode, input.Id);
            }
            else
            {
                operateStatus.ResultSign = ResultSign.Successful;
                operateStatus.Message = Chs.CheckSuccessful;
            }
            return operateStatus;
        }

        #endregion
    }
}
