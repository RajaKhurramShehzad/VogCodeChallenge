using System.Collections.Generic;
using VogCodeChallenge.BLL.Interfaces;
using VogCodeChallenge.BLL.Models;

namespace VogCodeChallenge.BLL.Services
{
    public class EmployeeMemoryService : IEmployeeService
    {
        public EmployeeMemoryService()
        {
        }

        public IEnumerable<Employee> GetAll()
        {
            Employee[] Employees = new Employee[]
              {

                    new Employee {FirstName="James Wadje", LastName="Butt", JobTitle = "technician" , Address = "6649 N Blue Gum St,New Orleans, LA, 70116"},
                    new Employee {FirstName="Nickolas", LastName="Juvera", JobTitle = "supervisor " , Address = "62 W Austin St,Syosset, NY, 11791"}
              };
            return Employees;
        }

        public IList<Employee> ListAll()
        {
            IList<Employee> employees = new List<Employee>();
            employees.Add(new Employee { FirstName = "James Wadje", LastName = "Butt", JobTitle = "technician", Address = "6649 N Blue Gum St,New Orleans, LA, 70116" });
            employees.Add(new Employee { FirstName = "Nickolas", LastName = "Juvera", JobTitle = "supervisor ", Address = "62 W Austin St,Syosset, NY, 11791" });
            return employees;
        }
    }
}
