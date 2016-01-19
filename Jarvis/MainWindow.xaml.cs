using System.Diagnostics;
using System.Windows;

namespace Jarvis {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void GitHub_OnClick(object sender, RoutedEventArgs e) {
            Process.Start("https://github.com/FaustoPayano/Jarvis");
        }
    }
}
