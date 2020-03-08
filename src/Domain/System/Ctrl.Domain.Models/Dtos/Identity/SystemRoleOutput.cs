using System;
using Ctrl.Core.Entities.Dtos;
using Ctrl.System.Models.Entities;
using Volo.Abp.Application.Dtos;

namespace Ctrl.Domain.Models.Dtos.Identity
{
    /// <summary>
    ///     角色dto
    /// </summary>
    public class SystemRoleOutput:SystemRole,IEntityDto<Guid>
    {
        /// <summary>
        ///     组织机构名称
        /// </summary>
        /// <value></value>
        public string OrganizationName { get; set; }
        public Guid Id { get; set; }
    }
}