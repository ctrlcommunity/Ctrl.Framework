using Ctrl.Core.PetaPoco;
using System;
using Ctrl.Core.Entities;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace Ctrl.System.Models.Entities
{
	/// <summary>
    ///    网站配置表实体类
    /// </summary>
    [TableName("Sys_Config")]
    [PrimaryKey("Id")]
    public class SystemConfig:Entity<Guid>
    {
		        /// <summary>
        /// 主键编码
        /// </summary>
        public Guid Id { get; set; }

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
