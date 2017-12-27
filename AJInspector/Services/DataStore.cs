using System;
using SQLite;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;


namespace AJInspector
{
    public class DataStore
    {
        static readonly object locker = new object();


        private readonly SQLiteConnection _connection;
        private string DatabaseName;


        ISQLite SQLite
        {
            get { return DependencyService.Get<ISQLite>(); }
        }

        public DataStore(string databaseName)
        {
            DatabaseName = databaseName;
            _connection = SQLite.GetConnection(DatabaseName);

        }

        public void CreateTable<T>()
        {
            lock (locker) { _connection.CreateTable<T>(); }
        }

        public long GetSize()
        {
            return SQLite.Getsize(DatabaseName);
        }

        public int SaveItem<T>(T item, int ID) //where T : ITableModel
        {

            lock (locker)
            {
                //var id = ((BaseItem)(object)item).ID;
                var id = ID;
                if (id != 0)
                {
                    _connection.Update(item);
                    return id;
                }
                else
                {
                    return _connection.Insert(item);

                }
            }


        }

        public void ExecuteQuery(string query, object[] args)
        {
            lock (locker) { _connection.Execute(query, args); }
        }

        public List<T> Query<T>(string query, object[] args) where T : new()
        {
            lock (locker)
            {
                return _connection.Query<T>(query, args);
            }
        }

        public IEnumerable<T> GetItems<T>() where T : new()
        {
            lock (locker) { return (from i in _connection.Table<T>() select i).ToList(); }
        }

        public int DeleteItem<T>(int id)
        {
            lock (locker) { return _connection.Delete<T>(id); }
        }

        public int DeleteAll<T>()
        {
            lock (locker) { return _connection.DeleteAll<T>(); }
        }


        //__+++===== Far more Useful methods ============================================================+++++


        public int FindNumberRecords()
        {
            try
            {
                var count = _connection.ExecuteScalar<int>("SELECT Count (*) FROM Vehicle");
                return count;
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("error on count: " + ex);
                return -1;

            }
        }

        public int CountDetails()
        {
            try
            {
                var count = _connection.ExecuteScalar<int>("SELECT Count (*) FROM Details");
                return count;
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("error on count: " + ex);
                return -1;

            }
        }

        public int GetLastid()
        {
            try
            {
                var rID = _connection.ExecuteScalar<int>("Select last_insert_rowid()");
                return rID;
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("error on getting id: " + ex);
                return -1;
            }
        }

        public List<Vehicle> GetAllVehicles()
        {
            try
            {
                return _connection.Query<Vehicle>("Select * From [Vehicle] Order By [VehicleID] Desc Limit 7");
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("error on getting Vehicle List: " + ex);
                return null;
            }
        }
        public List<Detail> GetAllDetails(int ID)
        {
            try
            {
                return _connection.Query<Detail>("Select * From [Detail] Where [VID] = ? Order By [DetailID]", ID);
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("error on getting Detail List: " + ex);
                return null;
            }
        }

        public List<Mechanical> GetAllMechanicals(int ID)
        {
            try
            {
                return _connection.Query<Mechanical>("Select * From [Mechanical] Where [VID] = ?", ID);
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("error on getting Detail List: " + ex);
                return null;
            }
        }

        public List<Vehicle> GetVehicle(int ID)
        {
            try
            {
                return _connection.Query<Vehicle>("Select * From [Vehicle] Where [VehicleID] = ?", ID);
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("error on getting Vehicle item:" + ex);
                return null;
            }
        }
    }
}

