using System;
using Volo.Abp.Domain.Entities;

namespace CtrlCloud.Framework.Application.Contracts.CtrlCloud.Config.Dtos
{
    public class SystemDataBaseTableOutput : Entity<Guid>
    {
        /// <summary>
        ///     表
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///     表注释
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        ///     创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
