using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Jarvis.Database;
using Jarvis.Models;

namespace Jarvis.ViewModels {
   public class MainWindowViewModel : INotifyPropertyChanged {

        private readonly ObservableCollection<EmployeeViewModel> _employeesInternal = new ObservableCollection<EmployeeViewModel>(); 

        public MainWindowViewModel() {
            Employees = new ReadOnlyObservableCollection<EmployeeViewModel>(_employeesInternal);
            PopulateList = new ActionCommand(PopulateEmployeeList);
            PopulateEmployeeList();

        }
       // public ReadOnlyObservableCollection<Case> CaseList { get;}
        public event PropertyChangedEventHandler PropertyChanged;
        public ReadOnlyObservableCollection<EmployeeViewModel> Employees { get; }
        public ICommand PopulateList { get; }

        private void PopulateEmployeeList() {
            _employeesInternal.Clear();
            var sqlDb = new SqlLiteDatabase();
            foreach (var employeeViewModel in sqlDb.SelectEmployees()) {
                _employeesInternal.Add(employeeViewModel);
            }
        }
    }
}
