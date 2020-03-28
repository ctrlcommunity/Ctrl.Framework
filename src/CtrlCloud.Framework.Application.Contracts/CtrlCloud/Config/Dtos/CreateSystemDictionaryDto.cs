using System;

namespace CtrlCloud.Framework.Application.Contracts.CtrlCloud.Config.Dtos
{
    public class CreateSystemDictionaryDto
    {

        /// <summary>
        /// 父级编码
        /// </summary>
        public Guid ParentId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 是否冻结
        /// </summary>
        public bool IsFreeze { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        public int OrderNo { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        ///     创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        public Guid? TenantId { get; set; }
    }
}
