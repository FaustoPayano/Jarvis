﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jarvis.Models {
    class Case {
        public Case(string name, string updateInformation, int accountNumber) {
            AccountNumber = accountNumber;
            Name = name;
            UpdateInformation = updateInformation;
        }

        public int AccountNumber { get; private set; }
        public string Name { get; private set; }
        public string UpdateInformation { get; private set; }
    }
}
