﻿using Ctrl.Core.PetaPoco.Core;
using System.Data.Common;

namespace Ctrl.Core.PetaPoco.Providers
{
    public class PostgreSQLDatabaseProvider : DatabaseProvider
    {
        public override bool HasNativeGuidSupport
        {
            get { return true; }
        }

        public override DbProviderFactory GetFactory()
        {
            return GetFactory("Npgsql.NpgsqlFactory, Npgsql, Culture=neutral, PublicKeyToken=5d8b90d52f46fda7");
        }

        public override string GetExistsSql()
        {
            return "SELECT CASE WHEN EXISTS(SELECT 1 FROM {0} WHERE {1}) THEN 1 ELSE 0 END";
        }

        public override object MapParameterValue(object value)
        {
            // Don't map bools to ints in PostgreSQL
            if (value.GetType() == typeof(bool))
                return value;

            return base.MapParameterValue(value);
        }

        public override string EscapeSqlIdentifier(string sqlIdentifier)
        {
            return string.Format("\"{0}\"", sqlIdentifier);
        }

        public override object ExecuteInsert(Database db, System.Data.IDbCommand cmd, string primaryKeyName)
        {
            if (primaryKeyName != null)
            {
                cmd.CommandText += string.Format("returning {0} as NewID", EscapeSqlIdentifier(primaryKeyName));
                return ExecuteScalarHelper(db, cmd);
            }
            else
            {
                ExecuteNonQueryHelper(db, cmd);
                return -1;
            }
        }
    }
}
