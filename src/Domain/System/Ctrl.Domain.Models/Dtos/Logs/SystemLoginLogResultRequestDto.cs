using Volo.Abp.Application.Dtos;

namespace Ctrl.Domain.Models.Dtos.Logs
{
    public class SystemLoginLogResultRequestDto: PagedAndSortedResultRequestDto
    {
        public string CreateUserName { get; set; }

        public string CreateUserCode { get; set; }
    }
}
