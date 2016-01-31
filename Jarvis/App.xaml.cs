using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using Jarvis.Database;
using Jarvis.ViewModels;

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
            var mainWindow = new MainWindow {
                DataContext = new MainWindowViewModel()
            };
            mainWindow.Show();
        }
        private void startUpDoWork(object sender, DoWorkEventArgs e) {
            SqlLiteDatabase dbManager = new SqlLiteDatabase();
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
        }
    }
}
