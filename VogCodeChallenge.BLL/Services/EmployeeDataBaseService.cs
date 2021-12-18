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
            throw new NotImplementedException("Database Access is not implemented as it was not required");
        }

        public IList<Employee> ListAll()
        {
            throw new NotImplementedException("Database Access is not implemented as it was not required");
        }
    }
}
