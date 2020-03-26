using Ctrl.Core.Core.Utils;
using Ctrl.Core.Entities;
using Ctrl.Core.Entities.Tree;
using Ctrl.Domain.Models.Dtos.Article;
using Ctrl.System.DataAccess;
using Ctrl.System.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Ctrl.System.Business
{
    /// <summary>
    ///     文章类型业务逻辑接口实现
    /// </summary>
    public class SystemArticleTypeLogic : CrudAppService<SystemArticleType, SystemArticleTypeResultRequestDto, Guid>, ISystemArticleTypeLogic, IScopedDependency
    {
        private readonly ISystemArticleTypeRepository _systemArticleTypeRepository;
        public SystemArticleTypeLogic(IRepository<SystemArticleType, Guid> repository, ISystemArticleTypeRepository systemArticleTypeRepository) : base(repository)
        {
            _systemArticleTypeRepository = systemArticleTypeRepository;
        }
        #region 构造函数

        #endregion

        #region 方法
        /// <summary>
        ///     保存文章类型
        /// </summary>
        /// <param name="articleType"></param>
        /// <returns></returns>

        public async Task<OperateStatus> SaveArticleType(SystemArticleType articleType)
        {
            if (articleType.Id.IsEmptyGuid())
            {
                articleType.CreateTime = DateTime.Now;
                //articleType.Id = CombUtil.NewComb();
                //return await InsertAsync(articleType);
            }
            else {
                //var artType = await _systemArticleTypeRepository.GetById(articleType.Id);
               // articleType.CreateTime = artType.CreateTime;
               // return await UpdateAsync(articleType);
            }
            return null;
        }
        /// <summary>
        ///     获取文章类型树
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<TreeEntity>> GetArticleTypeTree()
        {
            return _systemArticleTypeRepository.GetArticleTypeTree();
        }
        
        /// <summary>
        ///     获取文章类型分页
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<SystemArticleTypeResultRequestDto>> GetPagingArticleType(SystemArticleResultRequestDto param)
        {
            var list = await _systemArticleTypeRepository.GetListAsync(param);
            var totalCount = await _systemArticleTypeRepository.GetCountAsync(param);

            return new PagedResultDto<SystemArticleTypeResultRequestDto>(
                totalCount,
                ObjectMapper.Map<List<SystemArticleType>, List<SystemArticleTypeResultRequestDto>>(list)
                );
        }
        #endregion
    }
}