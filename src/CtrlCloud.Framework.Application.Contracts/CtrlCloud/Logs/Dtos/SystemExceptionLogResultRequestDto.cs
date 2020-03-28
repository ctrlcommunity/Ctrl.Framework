using Volo.Abp.Application.Dtos;

namespace Ctrl.Domain.Models.Dtos.Logs
{
    public class SystemExceptionLogResultRequestDto: PagedAndSortedResultRequestDto
    {
        public string CreateUserName { get; set; }

        public string CreateUserCode { get; set; }
    }
}
