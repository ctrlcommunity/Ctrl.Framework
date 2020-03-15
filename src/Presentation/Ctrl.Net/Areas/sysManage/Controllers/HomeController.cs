using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Ctrl.Core.Core.Attributes;
using Ctrl.Core.Entities.Tree;
using Ctrl.Core.Web;
using Ctrl.Core.Web.Attributes;
using Ctrl.Domain.Business.Permission;
using Ctrl.System.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectMapping;

namespace Ctrl.Web.Host.Areas.sysManage.Controllers
{
    /// <summary>
    ///     首页
    /// </summary>
    public class HomeController : BaseController
    {

        #region 构造函数
        private readonly ISystemPermissionLogic _permissionLogic;
        public HomeController(ISystemPermissionLogic permissionLogic)
        {
            _permissionLogic = permissionLogic;
        }

        #endregion

        #region 视图
        /// <summary>
        ///     首页
        /// </summary>
        [Route(""), Route("/SysManage/Home/Index"), Route("/SysManage")]
        [CreateBy("冯辉")]
        [Description("首页-界面")]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///     处理404
        /// </summary>
        /// <returns></returns>
        [SkipPermission]
        public ActionResult NotFounds(){
            return View();
        }
        /// <summary>
        ///     处理401未授权
        /// </summary>
        /// <returns></returns>
        [SkipPermission]
        public ActionResult Unauthorizeds() {
            return View();
        }
        #endregion

        #region 方法 
        [HttpPost]
        [CreateBy("冯辉")]
        [Description("首页-方法-获取菜单模块权限")]
        public Task<IEnumerable<TreeEntity>> LoadMenuPermission()
        {
            var data = (_permissionLogic.GetSystemPermissionMenuByUserId(CurrentUser.UserId));
            return data;
        }

        #endregion

    }
}