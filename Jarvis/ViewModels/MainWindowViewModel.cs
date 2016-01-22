using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Jarvis.Models;

namespace Jarvis.ViewModels {
    class MainWindowViewModel : INotifyPropertyChanged {

        private readonly ObservableCollection<EmployeeViewModel> _employeesInternal = new ObservableCollection<EmployeeViewModel>(); 

        public MainWindowViewModel() {
            
        }

        public ReadOnlyObservableCollection<EmployeeViewModel> EmployeesList { get; set; }
        public ReadOnlyObservableCollection<Case> CaseList { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

       /* protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }*/

        private void PopulateEmployeeList() {
            
        }
    }
}
