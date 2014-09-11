using System;
using System.Runtime.CompilerServices;

using Mono.Data.Sqlite;

namespace dame.Utilities.Extensions
{
    public static class SqliteDataReaderExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T TryGetValue<T>(this SqliteDataReader reader, string field)
        {
            return reader[field] is DBNull ? default(T) : (T)reader[field];
        }
    }
}

