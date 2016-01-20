using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jarvis.Utilities {
    class DatabaseManager {
        public void CreateDatabase() {
            var dbConnection = "database.db";

            if (!File.Exists("database.db")) {
                var databasePath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "database.db");
                SQLiteConnection.CreateFile(databasePath);
                CreateEmployeeTable(databasePath);
            }
        }

        private void CreateEmployeeTable(string databasePath) {
            using(var sqLiteCon = new SQLiteConnection($"Data Source={databasePath}"))
            {
                sqLiteCon.Open();
                string createQuery =
                    "create table Employees (name varchar(20), email varchar(20), completed int, currentassignment varchar(30)";
            }
            
        }
    }
}
