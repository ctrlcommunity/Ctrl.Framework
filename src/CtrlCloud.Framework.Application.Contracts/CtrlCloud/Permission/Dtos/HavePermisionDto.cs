using Ctrl.Core.Entities.Dtos;

namespace Ctrl.Domain.Models.Dtos.Permission
{
    public class HavePermisionDto:IOutputDto
    {
        /// <summary>
        ///     区域
        /// </summary>
        public string Area { get; set; }
        /// <summary>
        ///     控制器
        /// </summary>
        public string Controller { get; set; }
        /// <summary>
        ///     方法
        /// </summary>
        public string Action { get; set; }
    }
}
