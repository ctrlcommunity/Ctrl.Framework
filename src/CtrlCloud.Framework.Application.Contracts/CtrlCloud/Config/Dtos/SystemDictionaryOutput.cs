using System;
using Volo.Abp.Application.Dtos;

namespace Ctrl.Domain.Models.Dtos.Config
{
    /// <summary>
    ///     字典输出类
    /// </summary>
    public class SystemDictionaryOutput:IEntityDto<Guid>
    {
        /// <summary>
        ///     父级名称
        /// </summary>
        //public string ParentName { get; set; }
        public Guid Id { get; set; }


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
