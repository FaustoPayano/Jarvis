using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using log4net;

namespace Jarvis.Database {
    abstract class Database {
        private static readonly ILog Log = LogManager.GetLogger(typeof (Database));

        /// <summary>
        /// General and more abstract Create Database method for multi-database use.
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="filePath"></param>
        public void CreateDatabase(Uri filePath) {
            if (!File.Exists(filePath.AbsolutePath)) {
                SQLiteConnection.CreateFile(Path.GetFileName(filePath.AbsolutePath));
                var databaseName = Path.GetFileName(filePath.AbsolutePath);
                Log.Info(string.Format("Database \"{0}\" did not exist, it has been created.", databaseName));
            }
        }

        /// <summary>
        /// General and more abstract Create Table method for multi-purpose use.
        /// </summary>
        /// <param name="dbPath"></param>
        /// <param name="tableName"></param>
        /// <param name="columnsDictionary"></param>
        public void CreateTable(Uri dbPath, string tableName, Dictionary<string, string> columnsDictionary ) {

            var queryString = new StringBuilder(string.Format("create table {0} (", tableName));
            bool pastInitialLoop = false;
           foreach (var column in columnsDictionary) {
               if (pastInitialLoop) {
                   queryString.Append(",");
               }
                queryString.Append(string.Format("{0} {1}", column.Key, column.Value));
               pastInitialLoop = true;
           }
            queryString.Append(")");
                
            try {
                using (var sqLiteCon = new SQLiteConnection(string.Format("Data Source={0};Version=3;", Path.GetFileName(dbPath.AbsolutePath)), true)) {
                    sqLiteCon.Open();
                    SQLiteCommand sqlCommand = new SQLiteCommand(queryString.ToString(), sqLiteCon);
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception databaseTableCreationException) {

                Log.Fatal(string.Format("Table creation query could not be executed: \n {0}",
                    databaseTableCreationException));
            }
            Log.Info(string.Format("Table {0} created in database located at: {1} - query used: {2}", tableName,
                dbPath.AbsolutePath, queryString));
        }

        public bool CheckIfExists(Uri dbPath) {
            return File.Exists(dbPath.AbsolutePath);
        }
    }
}
