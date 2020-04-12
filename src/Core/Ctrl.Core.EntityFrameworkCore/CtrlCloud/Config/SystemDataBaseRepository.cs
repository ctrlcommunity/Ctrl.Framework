using Ctrl.Core.Entities.Dtos;
using Ctrl.Core.Entities.Tree;
using Ctrl.Core.EntityFrameworkCore.EntityFrameworkCore;
using Ctrl.Domain.DataAccess.Config;
using Ctrl.Domain.Models.Dtos.Config;
using CtrlCloud.Framework.Application.Contracts.CtrlCloud.Config.Dtos;
using Dapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.Dapper;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace CtrlCloud.Framework.EntityFrameworkCore.CtrlCloud.Config
{

    public class SystemDataBaseDapperRepository : DapperRepository<CtrlDbContext>, ISystemDataBaseDapperRepository,
        IScopedDependency
    {
        public SystemDataBaseDapperRepository(IDbContextProvider<CtrlDbContext> dbContextProvider) : base(
            dbContextProvider)
        {
        }
        /// <summary>
        ///     获取所有表
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<SystemDataBaseTableOutput>> GetDataBaseTables()
        {
            var sql = @"SELECT
                        A.name ,C.value,A.create_date  CreateDate
                        FROM sys.tables A

                        LEFT JOIN sys.extended_properties C ON C.major_id = A.object_id
                        WHERE C.minor_id=0 
                        ";
            return this.DbConnection.QueryAsync<SystemDataBaseTableOutput>(sql);
        }
        /// <summary>
        ///     根据表名获取所有列
        /// </summary>
        /// <param name="idInput"></param>
        /// <returns></returns>
        public Task<IEnumerable<SystemDataBaseColumnOutput>> GetDataBaseColumn(IdInput idInput)
        {
            var sql = @"SELECT 
                        b.name DataType,
                        a.name FieldName,
                        isnull(g.[value], ' ') AS Remarks
                        FROM  syscolumns a 
                        left join systypes b on a.xtype=b.xusertype  
                        inner join sysobjects d on a.id=d.id and d.xtype='U' and d.name<>'dtproperties' 
                        left join sys.extended_properties g on a.id=g.major_id AND a.colid=g.minor_id
                        where b.name is not null and d.name=@name
                        order by a.id,a.colorder";
            return this.DbConnection.QueryAsync<SystemDataBaseColumnOutput>(sql, new {name = idInput.Id});
        }

        public Task<IEnumerable<TreeEntity>> GetDataBaseColumnsTree(string name)
        {
            var sql = @"SELECT 
                         a.name id,
                       cast(a.name as varchar)+cast(isnull(g.[value], ' ') as varchar) as name,
                    isnull(g.[value], ' ') as code
                        FROM  syscolumns a 
                        left join systypes b on a.xtype=b.xusertype  
                        inner join sysobjects d on a.id=d.id and d.xtype='U' and d.name<>'dtproperties' 
                        left join sys.extended_properties g on a.id=g.major_id AND a.colid=g.minor_id
                        where b.name is not null and d.name=@name
                        order by a.id,a.colorder";
            return this.DbConnection.QueryAsync<TreeEntity>(sql, new {name = name});
        }

    }

    public class SystemDataBaseRepository : EfCoreRepository<CtrlDbContext,SystemDataBaseTableOutput, Guid>, ISystemDataBaseRepository
    {
        public SystemDataBaseRepository(IDbContextProvider<CtrlDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
