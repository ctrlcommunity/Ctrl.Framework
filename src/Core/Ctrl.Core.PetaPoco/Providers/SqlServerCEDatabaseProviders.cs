﻿using Ctrl.Core.PetaPoco.Core;
using Ctrl.Core.PetaPoco.Utilities;
using System.Data.Common;
using System.Linq;

namespace Ctrl.Core.PetaPoco.Providers
{
    public class SqlServerCEDatabaseProviders : DatabaseProvider
    {
        public override DbProviderFactory GetFactory()
        {
            return GetFactory("System.Data.SqlServerCe.SqlCeProviderFactory, System.Data.SqlServerCe, Culture=neutral, PublicKeyToken=89845dcd8080cc91");
        }

        public override string BuildPageQuery(long skip, long take, SQLParts parts, ref object[] args)
        {
            if (string.IsNullOrEmpty(parts.SqlOrderBy))
                parts.Sql += " ORDER BY ABS(1)";
            var sqlPage = string.Format("{0}\nOFFSET @{1} ROWS FETCH NEXT @{2} ROWS ONLY", parts.Sql, args.Length, args.Length + 1);
            args = args.Concat(new object[] { skip, take }).ToArray();
            return sqlPage;
        }

        public override object ExecuteInsert(Database db, System.Data.IDbCommand cmd, string primaryKeyName)
        {
            ExecuteNonQueryHelper(db, cmd);
            return db.ExecuteScalar<object>("SELECT @@@IDENTITY AS NewID;");
        }
    }
}
