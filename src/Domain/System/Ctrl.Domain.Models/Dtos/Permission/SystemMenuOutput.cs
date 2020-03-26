using Ctrl.System.Models.Entities;
using System;
using Volo.Abp.Application.Dtos;

namespace Ctrl.Domain.Models.Dtos.Permission
{
    public class SystemMenuOutput : SystemMenu, IEntityDto<Guid>
    {
       //public string ParentName { get; set; }
        public Guid Id { get; set; }
    }
}