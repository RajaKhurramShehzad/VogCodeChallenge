using System.Collections.Generic;
using System.Linq;
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
            return GenerateData();
        }

        public IEnumerable<Employee> GetAll(int DepartmentId)
        {
            var employees = GenerateData();
            var ret = employees
                        .Where(item => item.DepartmentId == DepartmentId).ToArray();
            return ret;

        }

        public IList<Employee> ListAll()
        {
            var employees = GenerateData().ToList();
            return employees;
        }

        public IList<Employee> ListAll(int DepartmentId)
        {
            var employees = GenerateData().ToList();
            var ret = employees
                        .Where(item => item.DepartmentId == DepartmentId).ToList();
            return ret;
        }
        private Employee[] GenerateData()
        {
            Employee[] employees = new Employee[]
          {

                    new Employee {FirstName="James Wadje", LastName="Butt", JobTitle = "technician" , Address = "6649 N Blue Gum St,New Orleans, LA, 70116",  DepartmentId = 1},
                    new Employee {FirstName="Nickolas", LastName="Juvera", JobTitle = "supervisor" , Address = "62 W Austin St,Syosset, NY, 11791",  DepartmentId = 2},
                    new Employee {FirstName="Gilma", LastName="Liukko", JobTitle = "Engineer" , Address = "6 Ridgewood Center Dr, PA, 18518",  DepartmentId = 3},
                    new Employee {FirstName="Lili", LastName="Paskin", JobTitle = "supervisor" , Address = "38773 Gravois Ave, FL, 32750",  DepartmentId = 2}
          };
            return employees;
        }
    }
}
