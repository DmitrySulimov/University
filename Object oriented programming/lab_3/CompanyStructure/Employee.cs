using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyStructure
{
    public class Employee : Human
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
        public Employee Supervisor { get; set; }

        public Employee(string Name, string Surname, int Id, string Position, int Salary)
            : base(Name, Surname) { }

        public Employee(string Name, string Surname, int Id, string Position, int Salary, Employee Supervisor)
           : base(Name, Surname) { }


        

    }
}
