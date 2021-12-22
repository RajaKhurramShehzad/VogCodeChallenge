using System;
using System.Collections.Generic;
using VogCodeChallenge.BLL.Interfaces;
using VogCodeChallenge.BLL.Models;

namespace VogCodeChallenge.BLL.Services
{
    public class EmployeeDataBaseService : IEmployeeService
    {
        public IEnumerable<Employee> GetAll()
        {
            throw new NotImplementedException("Database Access is not implemented as Entity Framework implementation is not required");
        }

        public IEnumerable<Employee> GetAll(int DepartmentId)
        {
            throw new NotImplementedException("Database Access is not implemented as Entity Framework implementation is not required");
        }

        public IList<Employee> ListAll()
        {
            throw new NotImplementedException("Database Access is not implemented as Entity Framework implementation is not required");
        }

        public IList<Employee> ListAll(int DepartmentId)
        {
            throw new NotImplementedException("Database Access is not implemented as Entity Framework implementation is not required");
        }
    }
}
