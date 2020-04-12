using System;
using Volo.Abp.Domain.Entities;

namespace CtrlCloud.Framework.Domain.Models.CtrlCloud.Article
{
    /// <summary>
    ///    文章表实体类
    /// </summary>
    public class SystemArticle: Entity<Guid>
    {
        ///// <summary>
        ///// 主键编码
        ///// </summary>
        //public Guid ArticleId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 类型编码
        /// </summary>
        public Guid ArticleTypeId { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        public bool IsShow { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        public int OrderNo { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        public string Pic { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Contents { get; set; }

        /// <summary>
        /// 阅读量
        /// </summary>
        public int Counter { get; set; }

        /// <summary>
        ///  
        /// </summary>
        public string SeoTitle { get; set; }

        /// <summary>
        ///  
        /// </summary>
        public string SeoDes { get; set; }

        /// <summary>
        ///  
        /// </summary>
        public string SeoKey { get; set; }

    }
}
