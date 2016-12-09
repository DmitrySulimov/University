using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompanyStructure.Interfaces;

namespace CompanyStructure.Model
{
    public class CompanyStructureBuilder
    {
        public List<string> Position { get; private set; }
        public List<Employee> EmployeesList { get; private set; }

        public CompanyStructureBuilder()
        {
            EmployeesList = new List<Employee>();
            Position = new List<string>();
        }


        public void AddPosition(string positionName)
        {
            if (Position.Contains(positionName)) return;
            Position.Add(positionName);
        }

        public void AddEmployee(Employee employee)
        {
            EmployeesList.Add(employee);
        }

        public Employee GetEmployeeById(string id)
        {
            return EmployeesList.FirstOrDefault(p => p.Id == id);
        }

        public void AddSupervisor(Employee employee, Employee supervisor)
        {
            employee.Supervisor = supervisor;
        }

        public List<Employee> GetEmployeeByWithMoreSalary(double salary)
        {
            return EmployeesList.Where(p => p.Salary > salary).ToList();
        }

        public List<Employee> GetEmployeeBySupervisor(Employee supervisor)
        {
            return EmployeesList.Where(p => p.Supervisor == supervisor).ToList();
        }

        public string GetCompanyStructure(StructureFormat format)
        {
            IStrategy structureBuilder;
            if (format == StructureFormat.OnDirectSubmission)
            {
                structureBuilder = new DirectSubmissionBuilder();
            }
            else
            {
                structureBuilder = new HeightPositionStructureBuilder();
            }

            return structureBuilder.Execute(EmployeesList);
        }
    }

    public enum StructureFormat
    {
        OnDirectSubmission,
        OnHeightPosition
    }
}