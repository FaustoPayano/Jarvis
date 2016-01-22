using System;
using System.Data.SQLite;
using System.IO;
using System.Windows;
using log4net;

namespace Jarvis.Database {
    class DatabaseManager {
        private static readonly ILog Log = LogManager.GetLogger(typeof(DatabaseManager));
        public DatabaseManager() {
            
        }
        /// <summary>
        /// Checks if Database exists at local directory, if it does not, a database file named "database.db" is created.
        /// </summary>
        public void CreateDatabase() {
            var dbConnection = "database.db";

            if (!File.Exists("database.db")) {
                var databasePath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "database.db");
                SQLiteConnection.CreateFile(databasePath);
                Log.Info("Database did not exist in local directory, new database file created.");
               CreateEmployeeTable(databasePath);
            }
        }

        /// <summary>
        /// Creates the employee table containing four columns, Name | Email | Completed | Current Assignment.
        /// </summary>
        /// <param name="databasePath"></param>
       private void CreateEmployeeTable(string databasePath) {
            try {
                using (var sqLiteCon = new SQLiteConnection(string.Format("Data Source={0}", databasePath))) {
                    sqLiteCon.Open();
                    string createQuery =
                        "create table Employees (name varchar(20), email varchar(20), completed int, currentassignment varchar(30)";
                    SQLiteCommand sqlCommand = new SQLiteCommand(createQuery, sqLiteCon);
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception databaseTableCreation) {
                Log.Fatal("Create EmployeeTable Exception Caught.");
                Log.Fatal(databaseTableCreation);
            }
        }
    }
}
