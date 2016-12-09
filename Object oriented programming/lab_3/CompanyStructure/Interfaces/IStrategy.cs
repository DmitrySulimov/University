using System.Collections;
using System.Collections.Generic;
using CompanyStructure.Model;

namespace CompanyStructure.Interfaces
{
    public interface IStrategy
    {
        string Execute(IEnumerable<Employee> employees);
    }
}