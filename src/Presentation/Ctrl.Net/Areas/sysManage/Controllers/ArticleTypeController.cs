using Ctrl.Core.Core.Attributes;
using Ctrl.Core.Core.Utils;
using Ctrl.Core.Entities.Dtos;
using Ctrl.Core.Web;
using Ctrl.Core.Web.Attributes;
using Ctrl.Domain.Models.Dtos.Article;
using Ctrl.System.Business;
using Ctrl.System.Models.Entities;
using CtrlCloud.Framework.Application.Contracts.CtrlCloud.Article.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Ctrl.Net.Areas.sysManage.Controllers
{
    /// <summary>
    /// 文章类型控制器
    /// </summary>
    public class  ArticleTypeController : BaseController
    {
        #region 构造函数

        private readonly ISystemArticleTypeLogic _systemArticleTypeLogic;


        public ArticleTypeController(ISystemArticleTypeLogic systemArticleTypeLogic)
        {
            _systemArticleTypeLogic = systemArticleTypeLogic;
        }

        #endregion

        #region 视图
		 /// <summary>
        ///     列表
        /// </summary>
        /// <returns></returns>
        [CreateBy("冯辉")]
        [Description("应用系统-文章类型-列表")]
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        ///     编辑
        /// </summary>
        /// <returns></returns>
        [CreateBy("冯辉")]
        [Description("应用系统-文章类型-编辑")]
        [Permission("xtgl-wzlx-SaveArticleType")]
        public IActionResult Edit(NullableIdInput input)
        {
            SystemArticleType ArticleType = new SystemArticleType();
            if (!input.Id.IsNullOrEmptyGuid())
            {
                //  ArticleType = await _systemArticleTypeLogic.GetById(input.Id);
            }
            return View(ArticleType);
        }
        #endregion

        #region 方法
        /// <summary>
        ///     获取文章类型
        /// </summary>
        /// <returns></returns>
        [CreateBy("冯辉")]
        [Description("应用系统-文章类型-方法-获取文章类型")]
        public JsonResult GetList()
        {
            return null;
            //return Json(await _systemArticleTypeLogic.GetAllEnumerableAsync());
        }
        /// <summary>
        ///     保存文章类型
        /// </summary>
        /// <returns></returns>
        [CreateBy("冯辉")]
        [ValidateAntiForgeryToken]
        [Description("应用系统-文章类型-方法-保存文章类型")]
        [Permission("xtgl-wzlx-SaveArticleType")]
        public JsonResult SaveArticleType(CreateArticleTypeDto articleType)
        {
            return Json(_systemArticleTypeLogic.SaveArticleType(articleType));
        }
        [CreateBy("冯辉")]
        [Description("应用系统-文章类型-方法-获取文章类型树")]
        public async Task<JsonResult> GetArticleTypeTree() {
            return Json(await _systemArticleTypeLogic.GetArticleTypeTree());
        }
        /// <summary>
        ///     获取文章类型分页
        /// </summary>
        /// <returns></returns>
        [CreateBy("冯辉")]
        [Description("应用系统-文章类型-方法-获取文章类型列表")]
        public async Task<JsonResult> GetPagingArticleType(SystemArticleResultRequestDto param) {
            return Json(await _systemArticleTypeLogic.GetPagingArticleType(param));
        }

        #endregion
    }
}