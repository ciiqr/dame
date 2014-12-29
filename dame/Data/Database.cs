using System;
using System.IO;
using System.Runtime.CompilerServices;

using System.Data;
using Mono.Data.Sqlite;
using SQLConnectionStringBuilder = Mono.Data.Sqlite.SqliteConnectionStringBuilder;
using SQLConnection = Mono.Data.Sqlite.SqliteConnection;
using SQLCommand = Mono.Data.Sqlite.SqliteCommand;

using dame.Utilities;
using dame.Utilities.Extensions;

namespace dame.Data
{
    public partial class Database
    {
        // TODO: Potentially, eventually change so data access methods are actually part of an interface/abstract-class(DataStore)

        // TODO: Determine whether it is even worth storing them or if I should just create for each method call 
//        using (SqlConnection connection = new SqlConnection(connectionString))
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
        }

        public void initializeDatabase()
        {
            PerformOperation((conn, command) =>
            {
                using (var setupSqlReader = new StreamReader(Constants.INITIAL_DATABASE_PATH))
                {
                    try
                    {
                        command.CommandText = setupSqlReader.ReadToEnd();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // TODO: Handle error initializing database
                        Console.WriteLine(ex);
                    }
                }
            });
        }

        private IDbConnection createDatabaseConnection()
        {
            return new SQLConnection(connectionString);
        }

        private string connectionString
        {
            get
            {
                // TODO: Have builder as a lazy property?
                // TODO: Set builder properties that I actually need
                // http://www.mono-project.com/docs/database-access/providers/sqlite/#connection-string-format


                SQLConnectionStringBuilder builder = new SQLConnectionStringBuilder();
                builder.DataSource = DameUser.getDatabasePath();
                builder.FailIfMissing = false;
                builder.ReadOnly = false;

                return builder.ConnectionString;
            }
        }

        // Helpers
        private delegate void DatabaseOperationDelegate(IDbConnection conn, SQLCommand command);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool PerformOperation(DatabaseOperationDelegate handler)
        {
            // if the operation was successful
            var successful = false;
            var conn = dbConnectionPool.Get();
            SQLCommand command = (SQLCommand)conn.CreateCommand();
            try
            {
                handler(conn, command);
                successful = true;
            }
            catch (Exception ex)
            {
                #if DEBUG
                Console.WriteLine(ex);
                #endif
            }
            finally
            {
                StopOperation(conn, command);
            }
            return successful;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void StopOperation(IDbConnection conn, IDbCommand command)
        {
            command.Dispose();
            dbConnectionPool.Put(conn);
        }

        // Transactions
        public void beginBatchOperation()
        {
            PerformOperation((conn, command) =>
            {
                command.CommandText = "BEGIN TRANSACTION";
                command.ExecuteNonQuery();
            });
        }

        public void endBatchOperation()
        {
            PerformOperation((conn, command) =>
            {
                command.CommandText = "END TRANSACTION";
                command.ExecuteNonQuery();
            });
        }
    }
}

