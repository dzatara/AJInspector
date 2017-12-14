using System;
using System.IO;
using Xamarin.Forms;
using SQLite;

using AJInspector.Droid;

[assembly: Dependency(typeof(AJInspector.Droid.SQLite_Android))]

namespace AJInspector.Droid
{
    public class SQLite_Android : ISQLite
    {
        string GetPath(string databaseName)
        {
            if (string.IsNullOrWhiteSpace(databaseName))
            {
                throw new ArgumentException("Wrong Database name", nameof(databaseName));
            }
            var sqliteFilename = $"{databaseName}.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);

            return path;
        }

        public SQLiteConnection GetConnection(string databaseName)
        {
            return new SQLiteConnection(GetPath(databaseName));
        }

        public long Getsize(string databaseName)
        {
            var fileInfo = new FileInfo(GetPath(databaseName));
            return fileInfo != null ? fileInfo.Length : 0;
        }

    }
}
