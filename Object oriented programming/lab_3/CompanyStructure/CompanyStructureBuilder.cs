using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyStructure
{
    public class CompanyStructureBuilder
    {

        public List<String> Position { get; set; }
        public List<Employee> EmployeesList { get; set; }

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

   
   public void CreateEmployee(Employee employee)
        {
            EmployeesList.Add(employee);
        }

   public Employee GetEmployeeById(int Id)
        {
            return EmployeesList.FirstOrDefault(p => p.Id == Id);
        }
    public void AddSupervisor(Employee employee, Employee supervisor)
        {
            employee.Supervisor = supervisor;
        }
    public List<Employee> GetEmployeeBySalary(int Salary)
        {
            return EmployeesList.Where(p => p.Salary > Salary).ToList();
        }

        public List<Employee> GetEmployeeByWithSupervisor(Employee employee)
        {
            return EmployeesList.Where(p => p.Supervisor == employee).ToList();
        }
    }
}
