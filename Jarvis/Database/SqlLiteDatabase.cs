using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using Jarvis.Models;
using Jarvis.ViewModels;
using log4net;

namespace Jarvis.Database {
   public class SqlLiteDatabase : Database {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SqlLiteDatabase));
       private SQLiteConnection sqlite;

        public SqlLiteDatabase() {
            sqlite = new SQLiteConnection(string.Format("Data Source={0}", MainWindow.dbPath));

        }

       public List<EmployeeViewModel> SelectEmployees() {
           List<Employee> employeeList = new List<Employee>();
           using (SQLiteConnection connection = sqlite) {
               connection.Open();
               using (SQLiteCommand selectCommand = connection.CreateCommand()) {
                   selectCommand.CommandText = "SELECT * FROM employee";
                   selectCommand.CommandType = CommandType.Text;
                   SQLiteDataReader reply = selectCommand.ExecuteReader();
                   while (reply.Read()) {
                        employeeList.Add(new Employee(Convert.ToString(reply["name"]), Convert.ToString(reply["email"]), Convert.ToInt32(reply["completed"])));
                   }
               }
           }
           var employeeViewModels = new List<EmployeeViewModel>();
           foreach (var entry in employeeList) {
               employeeViewModels.Add(new EmployeeViewModel(entry.Name, entry.Email, entry.TotalCasesReviewed,
                   entry.CompletedDaily));
           }
           return employeeViewModels;
       }
    }
}
