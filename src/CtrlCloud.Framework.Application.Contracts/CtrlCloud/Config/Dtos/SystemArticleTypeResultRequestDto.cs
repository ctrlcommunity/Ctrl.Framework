using Volo.Abp.Application.Dtos;

namespace Ctrl.Domain.Models.Dtos.Config
{
    /// <summary>
    ///     字典分页dto
    /// </summary>
    public class SystemDictionaryResultRequestDto : PagedAndSortedResultRequestDto
    {
        public string Id { get; set; }
    }
}
