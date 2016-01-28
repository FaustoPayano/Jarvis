using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jarvis.Models {
    class Employee {
        public Employee(string name, string email, int totalCasesReviewed) {
            Name = name;
            Email = email;
            TotalCasesReviewed = totalCasesReviewed;
            CompletedDaily = false;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public int TotalCasesReviewed { get; set; }
        public bool CompletedDaily { get; set; }
    }

}
