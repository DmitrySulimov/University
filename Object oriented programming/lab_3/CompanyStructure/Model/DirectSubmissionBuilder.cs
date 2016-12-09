using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompanyStructure.Interfaces;

namespace CompanyStructure.Model
{
    public class DirectSubmissionBuilder : IStrategy
    {
        private List<Employee> Employees { get; set; }

        public string Execute(IEnumerable<Employee> employees)
        {
            Employees = employees.Select(p => p).ToList();

            StringBuilder sb = new StringBuilder();

            var supervisors = Employees.Where(p => p.Supervisor == null);

            foreach (var superviser in supervisors)
            {
                WriteSubordinates(sb, "", superviser);
            }

            return sb.ToString();
        }

        public void WriteSubordinates(StringBuilder sb, string indent, Employee superviser)
        {
            sb.AppendLine($"{indent}{superviser}");
            var employees = Employees.Where(p => p.Supervisor == superviser);
            foreach (var employee in employees)
            {
                WriteSubordinates(sb, indent + "  ", employee);
            }
        }
    }
}
