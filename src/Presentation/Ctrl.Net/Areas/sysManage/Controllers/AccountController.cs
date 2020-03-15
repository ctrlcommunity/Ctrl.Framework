using System;
using System.Threading.Tasks;
using Ctrl.Core.Core.Attributes;
using Ctrl.Core.Core.Auth;
using Ctrl.Core.Core.Log;
using Ctrl.Core.Core.Security;
using Ctrl.Core.Entities;
using Ctrl.Core.Web;
using Ctrl.Core.Web.Attributes;
using Ctrl.Domain.Business.Identity;
using Ctrl.Domain.Models.Dtos;
using Ctrl.Domain.Models.Entities;
using Ctrl.Domain.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Ctrl.Web.Host.Areas.sysManage.Controllers
{
    /// <summary>
    ///     登录控制器
    /// </summary>
    [Ignore]
    public class AccountController : BaseController
    {
        #region  构造函数
        private readonly ISystemUserLogic _systemUserLogic;

        public AccountController(ISystemUserLogic systemUserLogic)
        {
            _systemUserLogic = systemUserLogic;
        }
        #endregion

        #region 视图
        [HttpGet]
        [SkipPermission]
        public ActionResult Login(string ReturnUrl)
        {
            return View(new UserLoginInput { ReturnUrl = ReturnUrl });
        }
        /// <summary>
        /// 登录退出界面
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            AuthenticationExtension.SignOut();
            return RedirectToAction("Login", "Account");
        }
        /// <summary>
        ///     个人资料
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> PerInfo()
        {
            var user = await _systemUserLogic.GetAsync(CurrentUser.UserId);
            return View(user);
        }
        /// <summary>
        ///     绑定账号
        /// </summary>
        /// <returns></returns>
        public ActionResult BindAccount()
        {
            return View();
        }

        #endregion

        #region 方法
        /// <summary>
        ///     登录
        /// </summary>
        /// <param name="input">登录参数</param>
        /// <returns></returns> 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginInput model)
        {
            model.Password = _3DESEncrypt.Encrypt(model.Password);
            var info = await _systemUserLogic.CheckUserByCodeAndPwdAsync(model);
            if (info.Data != null)
            {
                var prin = new PrincipalUser()
                {
                    UserId = info.Data.Id,
                    Code = info.Data.Code,
                    Name = info.Data.Name,
                    IsAdmin = info.Data.IsAdmin,
                    //TODO先注释
                    //RoleName = info.Data.RoleName,
                    ImgUrl = info.Data.ImgUrl
                };
                if (prin.Code == "admin")
                {
                    prin.RoleName = "超级管理员";
                }
                //写入Cookie信息
                AuthenticationExtension.SetAuthCookie(prin);
                //写入日志
                var logHandler = new LoginLogHandler(info.Data.Id.ToString(), info.Data.Code, info.Data.Name, (int)EnumLoginType.账号密码登录);
                logHandler.WriteLog();
            }
            if (info.ResultSign == ResultSign.Successful)
            {
                if (Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }
                else if (string.IsNullOrEmpty(model.ReturnUrl))
                {
                    return Redirect("~/");
                }
                else
                {
                    // user might have clicked on a malicious link - should be logged
                    throw new Exception("invalid return URL");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, info.Message);

            }

            return View();
        }

        #endregion
    }


}