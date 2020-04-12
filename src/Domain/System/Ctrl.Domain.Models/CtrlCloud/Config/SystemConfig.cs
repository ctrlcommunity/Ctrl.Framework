using System;
using Volo.Abp.Domain.Entities;

namespace CtrlCloud.Framework.Domain.Models.CtrlCloud.Config
{
    /// <summary>
    ///    网站配置表实体类
    /// </summary>
    public class SystemConfig:Entity<Guid>
    {

        /// <summary>
        /// 网站名称
        /// </summary>
        public string SiteName { get; set; }

        /// <summary>
        /// 关键字
        /// </summary>
        public string Keywords { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 底部信息
        /// </summary>
        public string CopyRight { get; set; }
        /// <summary>
        ///     创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        public Guid? TenantId { get; set; }
    }
}
