using System;
using System.Data;
using Mono.Data.Sqlite;
using dame.Utilities;

namespace dame.Data
{
    public class Database
    {
        private ConcurrentObjectPool<IDbConnection> dbConnectionPool;

        public Database()
        {
            // Database Connection Pool Usage
            dbConnectionPool = new ConcurrentObjectPool<IDbConnection>((pool) =>
            {
                IDbConnection connection = createDatabaseConnection();
                connection.Open();
                return connection;
            });

            // TODO: Database Example
            var conn = dbConnectionPool.Get();
            // ... conn.excute(...)
            dbConnectionPool.Put(conn);
        }

        private IDbConnection createDatabaseConnection()
        {
            return new SqliteConnection(connectionString());
        }

        private String connectionString()
        {
            // TODO: Have this as a lazy property?
            // TODO: Set properties that I actually need
            // http://www.mono-project.com/docs/database-access/providers/sqlite/#connection-string-format

            SqliteConnectionStringBuilder builder = new SqliteConnectionStringBuilder();
            builder["Data Source"] = "(local)";
            builder["integrated Security"] = true;
            builder["Initial Catalog"] = "AdventureWorks;NewValue=Bad";

            return builder.ConnectionString;
        }
    }
}

