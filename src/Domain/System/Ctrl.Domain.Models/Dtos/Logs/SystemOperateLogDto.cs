using System;
using Volo.Abp.Application.Dtos;

namespace Ctrl.Domain.Models.Dtos.Logs
{
    public class SystemOperateLogResultRequestDto : PagedAndSortedResultRequestDto
    {
        /// <summary>
        ///     用户名
        /// </summary>
        public string CreateUserName { get; set; }
        /// <summary>
        ///     登录代码
        /// </summary>
        public string CreateUserCode { get; set; }
        /// <summary>
        ///     开始日期
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        ///     结束日期
        /// </summary>
        public DateTime EndTime { get; set; }
    }
}
