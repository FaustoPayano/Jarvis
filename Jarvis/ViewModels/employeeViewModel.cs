using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jarvis.ViewModels {
    public class EmployeeViewModel {
        public EmployeeViewModel(string name, string email, int totalCases, bool completedDaily) {

            Name = name;
            Email = email;
            TotalCases = totalCases;
            CompletedDaily = completedDaily;
        }

        public string Name { get; }
        public string Email { get; }
        public int TotalCases { get; }
        public bool CompletedDaily { get; }
    }
}
