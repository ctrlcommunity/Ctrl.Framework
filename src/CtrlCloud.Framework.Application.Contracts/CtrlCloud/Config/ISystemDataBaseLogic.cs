using Ctrl.Core.Entities.Dtos;
using Ctrl.Core.Entities.Tree;
using Ctrl.Domain.Models.Dtos.Config;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CtrlCloud.Framework.Application.Contracts.CtrlCloud.Config.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Ctrl.Domain.Business.Config
{
    public interface ISystemDataBaseLogic :IScopedDependency
    {
        /// <summary>
        ///     获取所有表
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<SystemDataBaseTableOutput>> GetDataBaseTables();
        /// <summary>
        ///     根据表名获取所有列
        /// </summary>
        /// <param name="idInput"></param>
        /// <returns></returns>
        Task<IEnumerable<SystemDataBaseColumnOutput>> GetDataBaseColumn(IdInput idInput);
        /// <summary>
        ///     根据表名获取所有列
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        Task<IEnumerable<TreeEntity>> GetDataBaseColumnsTree(string Name);
    }
}
