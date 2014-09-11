using System;
using System.IO;
using System.Runtime.CompilerServices;

using System.Data;

using Mono.Data.Sqlite;
using SQLConnectionStringBuilder = Mono.Data.Sqlite.SqliteConnectionStringBuilder;
using SQLConnection = Mono.Data.Sqlite.SqliteConnection;
//using SQLConnectionStringBuilder = System.Data.SqlClient.SqlConnectionStringBuilder;
//using SQLConnection = System.Data.SqlClient.SqlConnection;

using Evernote.EDAM.Type;

using dame.Utilities;
using dame.Utilities.Extensions;

namespace dame.Data
{
    public class Database
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
                //builder.SyncMode = SynchronizationModes.Off;
                //builder.JournalMode = SQLiteJournalModeEnum.Memory;
                //builder.JournalMode = SQLiteJournalModeEnum.Wal;
                builder.FailIfMissing = false;
                builder.ReadOnly = false;

                return builder.ConnectionString;
            }
        }

        // Helpers

        private delegate void DatabaseOperationDelegate(IDbConnection conn, SqliteCommand command);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void PerformOperation(DatabaseOperationDelegate handler)
        {
            var conn = dbConnectionPool.Get();
            SqliteCommand command = (SqliteCommand)conn.CreateCommand();
            try
            {
                handler(conn, command);
            }
            #if DEBUG
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            #endif
            finally
            {
                StopOperation(conn, command);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void StopOperation(IDbConnection conn, IDbCommand command)
        {
            command.Dispose();
            dbConnectionPool.Put(conn);
        }


        // Data Access

        public void addUser(User user)
        {
            PerformOperation((conn, command) =>
            {
                var comm = (SqliteCommand)command;


                command.CommandText = "INSERT INTO " + Tables.Users + "(" + Fields.Join(Fields.Users.Id,
                                                                                        Fields.Users.Username,
                                                                                        Fields.Users.Name,
                                                                                        Fields.Users.Timezone,
                                                                                        Fields.Users.Privilege,
                                                                                        Fields.Users.Created,
                                                                                        Fields.Users.Updated,
                                                                                        Fields.Users.Deleted,
                                                                                        Fields.Users.Active) +
                                                         ") VALUES(" + FieldParams.Join(FieldParams.Users.Id,
                                                                                        FieldParams.Users.Username,
                                                                                        FieldParams.Users.Name,
                                                                                        FieldParams.Users.Timezone,
                                                                                        FieldParams.Users.Privilege,
                                                                                        FieldParams.Users.Created,
                                                                                        FieldParams.Users.Updated,
                                                                                        FieldParams.Users.Deleted,
                                                                                        FieldParams.Users.Active) + ")";

                comm.Parameters.AddWithValue(FieldParams.Users.Id, user.Id);
                comm.Parameters.AddWithValue(FieldParams.Users.Username, user.Username);
                comm.Parameters.AddWithValue(FieldParams.Users.Name, user.Name);
                comm.Parameters.AddWithValue(FieldParams.Users.Timezone, user.Timezone);
                comm.Parameters.AddWithValue(FieldParams.Users.Privilege, user.Privilege);
                comm.Parameters.AddWithValue(FieldParams.Users.Created, user.Created);
                comm.Parameters.AddWithValue(FieldParams.Users.Updated, user.Updated);
                comm.Parameters.AddWithValue(FieldParams.Users.Deleted, user.Deleted);
                comm.Parameters.AddWithValue(FieldParams.Users.Active, user.Active);

                try // TODO: Handle errors
                {
                    int affectedRowCount = command.ExecuteNonQuery();
                    if (affectedRowCount > 0)
                    {
                        // TODO: Added x rows
                    }
                    else
                    {
                        // TODO: Didn't change any rows
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });
        }

        public User getUser(string username)
        {
            User user = null;
            PerformOperation((conn, command) =>
            {
                try
                {
                    command.CommandText = "SELECT * FROM " + Tables.Users + " WHERE " + Fields.Users.Username + "=" + FieldParams.Users.Username;
                    command.Parameters.AddWithValue(FieldParams.Users.Username, username);

                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User();
                            user.Id = (int)reader.TryGetValue<Int64>(Fields.Users.Id);
                            user.Username = reader.TryGetValue<string>(Fields.Users.Username);
                            user.Name = reader.TryGetValue<string>(Fields.Users.Name);
                            user.Timezone = reader.TryGetValue<string>(Fields.Users.Timezone);
                            user.Privilege = reader.TryGetValue<PrivilegeLevel>(Fields.Users.Privilege);
                            user.Created = reader.TryGetValue<Int32>(Fields.Users.Created);
                            user.Updated = reader.TryGetValue<Int32>(Fields.Users.Updated);
                            user.Deleted = reader.TryGetValue<Int32>(Fields.Users.Deleted);
                            user.Active = reader.TryGetValue<bool>(Fields.Users.Active);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine('\n');
                    Console.WriteLine(ex);
                }
            });
            return user;
        }
    }
}

