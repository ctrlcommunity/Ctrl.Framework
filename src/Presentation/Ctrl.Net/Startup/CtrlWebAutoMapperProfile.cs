using AutoMapper;
using Ctrl.Domain.Models.Dtos.Article;
using Ctrl.Domain.Models.Dtos.Identity;
using Ctrl.Domain.Models.Dtos.Logs;
using Ctrl.Domain.Models.Entities;

namespace Ctrl.Web.Host.Startup
{
    public class CtrlWebAutoMapperProfile : Profile
    {
        public CtrlWebAutoMapperProfile()
        {
            CreateMap<SystemUser, UserLoginOutput>().ReverseMap();
            CreateMap<SystemArticle, SystemArticleOutput>().ReverseMap();
            CreateMap<SystemExceptionLog, SystemExceptionLogDto>().ReverseMap();
            CreateMap<SystemOperateLog, SystemOperateLogOutput>().ReverseMap();
        }
    }
}
