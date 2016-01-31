using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Jarvis.Database;
using Jarvis.Models;
using log4net;
using log4net.Core;

namespace Jarvis {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private static readonly ILog Log = LogManager.GetLogger(typeof (MainWindow));
        private ImageSource imageGreenSource = new BitmapImage(new Uri("pack://application:,,,/Resources/Continue_Green.ico"));
        public static string dbPath = "database.db";
       
        public MainWindow() {

            log4net.Config.XmlConfigurator.Configure();
            InitializeComponent();
            ConnectionStatusIcon.Source = imageGreenSource;
        }

        private void GitHub_OnClick(object sender, RoutedEventArgs e) {
            Process.Start("https://github.com/FaustoPayano/Jarvis");
        }
    }
}
