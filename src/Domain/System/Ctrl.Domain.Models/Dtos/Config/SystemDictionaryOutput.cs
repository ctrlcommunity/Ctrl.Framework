using Ctrl.System.Models.Entities;
using System;
using Volo.Abp.Application.Dtos;

namespace Ctrl.Domain.Models.Dtos.Config
{
    /// <summary>
    ///     字典输出类
    /// </summary>
    public class SystemDictionaryOutput: SystemDictionary,IEntityDto<Guid>
    {
        /// <summary>
        ///     父级名称
        /// </summary>
        //public string ParentName { get; set; }
        public Guid Id { get; set; }
    }
}
