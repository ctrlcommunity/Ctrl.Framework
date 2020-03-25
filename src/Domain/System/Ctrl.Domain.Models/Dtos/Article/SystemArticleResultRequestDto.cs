using Volo.Abp.Application.Dtos;

namespace Ctrl.Domain.Models.Dtos.Article
{
    public class SystemArticleResultRequestDto: PagedAndSortedResultRequestDto
    {
        /// <summary>
        ///     标题
        /// </summary>
        public string Title { get; set; }
    }
}
