using System;
using SQLite;

namespace AJInspector
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection(string databaseName);
        long Getsize(string databaseName);
    }
}

