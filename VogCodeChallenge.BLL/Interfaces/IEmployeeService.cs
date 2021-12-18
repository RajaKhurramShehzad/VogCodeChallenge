using System.Collections.Generic;
using VogCodeChallenge.BLL.Models;

namespace VogCodeChallenge.BLL.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        IList<Employee> ListAll();

    }
}
