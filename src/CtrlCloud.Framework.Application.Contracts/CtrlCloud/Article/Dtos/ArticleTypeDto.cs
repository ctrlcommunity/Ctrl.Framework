using System;
using Volo.Abp.Application.Dtos;

namespace Ctrl.Domain.Models.Dtos.Article
{
    /// <summary>
    ///     文章类型输出类
    /// </summary>
    public class ArticleTypeDto: IEntityDto<Guid>
    {
        public string ParentName { get; set; }

        public Guid Id { get; set; }

        /// <summary>
        /// 上级编码
        /// </summary>
        public Guid ParentId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        public int OrderNo { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        public bool IsShow { get; set; }

        /// <summary>
        ///  
        /// </summary>
        public string SeoTitle { get; set; }

        /// <summary>
        ///  
        /// </summary>
        public string SeoKey { get; set; }

        /// <summary>
        ///  
        /// </summary>
        public string SeoDes { get; set; }
        /// <summary>
        ///     添加时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        public Guid? TenantId { get; set; }
    }
}
