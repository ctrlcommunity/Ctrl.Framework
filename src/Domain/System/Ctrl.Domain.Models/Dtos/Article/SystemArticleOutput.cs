using Ctrl.Core.Entities.Dtos;
using Ctrl.Domain.Models.Entities;
using Ctrl.System.Models.Entities;

namespace Ctrl.Domain.Models.Dtos.Article
{
    public class SystemArticleOutput:SystemArticle, IOutputDto
    {
        /// <summary>
        ///     文章类型名称
        /// </summary>
        public string ArticleTypeName { get; set; }
    }
}
