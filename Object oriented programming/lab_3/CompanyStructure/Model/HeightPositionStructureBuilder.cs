using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyStructure.Interfaces;

namespace CompanyStructure.Model
{
    public class HeightPositionStructureBuilder : IStrategy
    {
        private List<Employee> Employees { get; set; }

        public string Execute(IEnumerable<Employee> employees)
        {
            Employees = employees.Select(p => p).ToList();

            StringBuilder sb = new StringBuilder();

            var supervisors = Employees.Where(p => p.Supervisor == null).ToArray();

            WriteSubordinates(sb, "", supervisors);

            return sb.ToString();
        }

        private void WriteSubordinates(StringBuilder sb, string indent, Employee[] supervisors)
        {
            List<Employee> subordinates = new List<Employee>();
            foreach (var supervisor in supervisors)
            {
                sb.AppendLine($"{indent}{supervisor}");

                subordinates.AddRange(Employees.Where(p => p.Supervisor == supervisor));
            }
            if (subordinates.Count == 0) return;

            WriteSubordinates(sb, indent += "  ", subordinates.ToArray());
                
        }
    }
}
