using Ctrl.Core.Entities;
using Ctrl.Core.Entities.Dtos;
using Ctrl.Domain.Business.Permission;
using Ctrl.Domain.DataAccess.Identity;
using Ctrl.Domain.Models.Dtos;
using Ctrl.Domain.Models.Dtos.Identity;
using Ctrl.Domain.Models.Entities;
using System;
using System.Threading.Tasks;
using CtrlCloud.Framework.Core.Properties;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Ctrl.Domain.Business.Identity
{
    /// <summary>
    ///     用户业务逻辑实现
    /// </summary>
    public class SystemUserLogic : CrudAppService<SystemUser, UserLoginOutput,Guid>, ISystemUserLogic,IScopedDependency
    {
        #region 构造函数
        private readonly ISystemUserRepository _systemUserRepository;
        private readonly ISystemPermissionUserLogic _permissionUserLogic;
        private readonly ISystemUserDapperRepository _systemUserDapperRepository;

        public SystemUserLogic(IRepository<SystemUser, Guid> repository, ISystemUserRepository systemUserRepository, ISystemPermissionUserLogic permissionUserLogic, ISystemUserDapperRepository systemUserDapperRepository) : base(repository)
        {
            this._systemUserRepository = systemUserRepository;
            this._permissionUserLogic = permissionUserLogic;
            this._systemUserDapperRepository = systemUserDapperRepository;
        
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
                var data = await _systemUserDapperRepository.CheckUserByCodeAndPwd(input);
                //是否存在
                if (data == null)
                {
                    operateStatus.ResultSign = ResultSign.Error;
                    operateStatus.Message = ResourceSystem.用户名或密码错误;
                    goto End;
                }
                if (data.IsFreeze.Value)
                {
                    operateStatus.ResultSign = ResultSign.Error;
                    operateStatus.Message = ResourceSystem.登录用户已冻结;
                    goto End;
                }
                operateStatus.ResultSign = ResultSign.Successful;
                operateStatus.Message = "登录成功!";
                operateStatus.Message = string.Format(Chs.Successful, "登录成功");
                operateStatus.Data = data;
                //if (data.FirstVisitTime == null)
                //{
                //    //更新用户最后一次登录时间
                //    await _systemUserDapperRepository.UpdateFirstVisitTime(new IdInput(data.Id.ToString()));
                //}
                //更新用户最后一次登录时间
                await _systemUserDapperRepository.UpdateLastLoginTime(new IdInput(data.Id.ToString()));
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
        public Task<PagedResultDto<UserLoginOutput>> GetPagingSysUser(PagedAndSortedResultRequestDto queryParam)
        {
            return GetListAsync(new PagedAndSortedResultRequestDto());
        }

        /// <summary>
        ///     保存人员信息
        /// </summary>
        /// <param name="user">人员信息</param>
        /// <returns></returns>
        public async Task<OperateStatus> SaveUser(CreateUserDto user)
        {
            OperateStatus operateStatus=new OperateStatus();
            //if (string.IsNullOrWhiteSpace(user.Id.ToString()))
            //{
            //    user.CreateTime = DateTime.Now;
            //    user.Password = _3DESEncrypt.Encrypt("123456");
            //    var resultUser = await _systemUserRepository.InsertAsync(
            //        new SystemUser(CombUtil.NewComb(), user.Code, user.Name, user.Password, user.Mobile,
            //            user.Email, user.FirstVisitTime, user.LastVisitTime, user.Remark, user.IsAdmin, user.CreateTime,
            //            user.IsFreeze, user.ImgUrl));
            //    if (resultUser !=null)
            //    {
            //        //添加用户到组织机构
            //        operateStatus = await _permissionUserLogic.SavePermissionUser(EnumPrivilegeMaster.角色, user.RoleId,
            //            new List<string> { user.Id.ToString() });
            //        if (operateStatus.ResultSign == ResultSign.Successful)
            //        {
            //            return operateStatus;
            //        }
            //    }
            //    else
            //    {
            //        return operateStatus;
            //    }
            //}
            //else
            //{
            //    //删除对应组织机构
            //    operateStatus = await _permissionUserLogic.DeletePrivilegeMasterUser(user.Id.ToString(), EnumPrivilegeMaster.角色);
            //    if (operateStatus.ResultSign == ResultSign.Successful)
            //    {
            //        //添加用户到组织机构
            //        operateStatus = await _permissionUserLogic.SavePermissionUser(EnumPrivilegeMaster.角色, user.RoleId, new List<string> { user.Id.ToString() });
            //        if (operateStatus.ResultSign == ResultSign.Successful)
            //        {
            //            var userInfo = await _systemUserRepository.GetAsync(user.Id);
            //            user.Password = userInfo.Password;
            //            var result = await _systemUserRepository.UpdateAsync(user);
            //            if (result!=null)
            //            {
            //                operateStatus.Message = "Success";
            //                operateStatus.ResultSign = ResultSign.Successful;
            //            }
            //        }
            //    }
            //}
            return operateStatus;
        }
        /// <summary>
        ///     用户信息修改
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<OperateStatus> UserInfoUpdateSave(UpdateUserDto input)
        {
            OperateStatus operateStatus = new OperateStatus() ;
            if (!await _systemUserDapperRepository.UserInfoUpdateSave(input))
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
            if (await _systemUserDapperRepository.CheckUserCode(input))
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
