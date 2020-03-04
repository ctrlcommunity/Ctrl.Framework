using Ctrl.Domain.Models.Entities;
using System;
using Volo.Abp.Application.Dtos;

namespace Ctrl.Domain.Models.Dtos.Article
{
    public class SystemArticleOutput:SystemArticle, IEntityDto<Guid>
    {
        /// <summary>
        ///     文章类型名称
        /// </summary>
       // public string ArticleTypeName { get; set; }
        public Guid Id { get; set; }
    }
}
