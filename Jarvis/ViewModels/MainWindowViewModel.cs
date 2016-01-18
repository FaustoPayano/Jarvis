﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Jarvis.Models;

namespace Jarvis.ViewModels {
    class MainWindowViewModel : INotifyPropertyChanged {

        public MainWindowViewModel() {
            
        }

        public ReadOnlyObservableCollection<Employee> EmployeesList { get; }
        public ReadOnlyObservableCollection<Case> CaseList { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
