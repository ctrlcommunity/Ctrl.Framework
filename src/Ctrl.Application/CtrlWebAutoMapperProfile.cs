using AutoMapper;
using Ctrl.Domain.Models.Dtos.Article;
using Ctrl.Domain.Models.Dtos.Config;
using Ctrl.Domain.Models.Dtos.Identity;
using Ctrl.Domain.Models.Dtos.Logs;
using Ctrl.Domain.Models.Entities;
using Ctrl.System.Models.Entities;
using CtrlCloud.Framework.Domain.Models.CtrlCloud.Article;
using CtrlCloud.Framework.Domain.Models.CtrlCloud.Logs;

namespace Ctrl.Web.Host.Startup
{
    public class CtrlWebAutoMapperProfile : Profile
    {
        public CtrlWebAutoMapperProfile()
        {
            CreateMap<SystemUser, UserLoginOutput>().ReverseMap();
            CreateMap<SystemArticle, SystemArticleDto>().ReverseMap();
            CreateMap<SystemExceptionLog, SystemExceptionLogDto>().ReverseMap();
            CreateMap<SystemOperateLog, SystemOperateLogOutput>().ReverseMap();
            CreateMap<SystemLoginLog,SystemLoginLogOutput>().ReverseMap();
            CreateMap<SystemDictionary, SystemDictionaryOutput>().ReverseMap();
        }
    }
}
