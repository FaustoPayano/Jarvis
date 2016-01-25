using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using Jarvis.Database;

namespace Jarvis {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        private void App_OnStartup(object sender, StartupEventArgs e) {
            BackgroundWorker backgroundThread = new BackgroundWorker();
            backgroundThread.DoWork += new DoWorkEventHandler(startUpDoWork);
            backgroundThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(runWorkerCompleted);
            backgroundThread.RunWorkerAsync();
        }
        private void startUpDoWork(object sender, DoWorkEventArgs e) {
            DatabaseManager dbManager = new DatabaseManager();
            var dbPath = new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.db"));
            if (!dbManager.CheckIfExists(dbPath)) {
                dbManager.CreateDatabase(dbPath);
                var columnDictionary = new Dictionary<string, string>() {
                    {"name", "varchar(20)"},
                    {"email", "varchar(20)"},
                    {"completed", "int"},
                    {"currentassignment", "varchar(30)"}
                };
                dbManager.CreateTable(dbPath, "employee", columnDictionary);
            }
        }
        private void runWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            MessageBox.Show("Created Database.");
        }
    }
}
