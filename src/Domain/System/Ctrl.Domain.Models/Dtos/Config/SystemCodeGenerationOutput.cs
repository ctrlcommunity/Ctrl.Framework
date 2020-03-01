﻿using Ctrl.Core.Entities.Dtos;

namespace Ctrl.Domain.Models.Dtos.Config
{
    /// <summary>
    /// 代码生成器输出参数
    /// </summary>
    public class SystemCodeGenerationOutput : IOutputDto
    {
        /// <summary>
        ///     实体类名
        /// </summary>
        public string Entities { get; set; }

        /// <summary>
        ///     DataAccess接口
        /// </summary>
        public string DataAccessInterface { get; set; }

        /// <summary>
        ///     DataAccess实现
        /// </summary>
        public string DataAccess { get; set; }

        /// <summary>
        ///     Business接口
        /// </summary>
        public string BusinessInterface { get; set; }

        /// <summary>
        ///     Business实现
        /// </summary>
        public string Business { get; set; }

        /// <summary>
        ///     控制器
        /// </summary>
        public string Controller { get; set; }

        /// <summary>
        ///     列表页名
        /// </summary>
        public string List { get; set; }
        /// <summary>
        ///     编辑页面
        /// </summary>
        public string Edit { get; set; }

    }
}
