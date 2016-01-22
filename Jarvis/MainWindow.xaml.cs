using System.Diagnostics;
using System.Windows;
using Jarvis.Models;
using log4net;
using log4net.Core;

namespace Jarvis {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private static readonly ILog Log = LogManager.GetLogger(typeof (MainWindow));
        public MainWindow() {
            log4net.Config.XmlConfigurator.Configure();
            InitializeComponent();
        }

        private void GitHub_OnClick(object sender, RoutedEventArgs e) {
            Process.Start("https://github.com/FaustoPayano/Jarvis");
        }
    }
}
