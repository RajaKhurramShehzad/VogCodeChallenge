using System.Collections.Generic;
using VogCodeChallenge.BLL.Models;

namespace VogCodeChallenge.BLL.Interfaces
{
    public interface IVogCodeChallengeAPIHandler
    {
        IEnumerable<Employee> GetAll();

        IList<Employee> ListAll();

        IEnumerable<Employee> GetAll(int departmentId);

        IList<Employee> ListAll(int departmentId);

    }
}
