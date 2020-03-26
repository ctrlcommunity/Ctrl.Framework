using Ctrl.System.Models.Entities;
using System;
using Volo.Abp.Application.Dtos;

namespace Ctrl.Domain.Models.Dtos.Article
{
    /// <summary>
    ///     文章类型输出类
    /// </summary>
    public class SystemArticleTypeResultRequestDto: SystemArticleType, IEntityDto<Guid>
    {
        public string ParentName { get; set; }

        public Guid Id { get; set; }
    }
}
