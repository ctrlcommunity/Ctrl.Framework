using AutoMapper;
using Ctrl.Domain.Models.Dtos.Identity;
using Ctrl.Domain.Models.Entities;

namespace Ctrl.Domain.Models
{
    public class CtrlWebAutoMapperProfile : Profile
    {
        public CtrlWebAutoMapperProfile()
        {
            CreateMap<SystemUser, UserLoginOutput>().ReverseMap();
        }
    }
}
