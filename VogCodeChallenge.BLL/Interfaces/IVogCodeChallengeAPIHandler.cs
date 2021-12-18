using System.Collections.Generic;
using VogCodeChallenge.BLL.Objects;

namespace VogCodeChallenge.BLL.Interfaces
{
    public interface IVogCodeChallengeAPIHandler
    {
        IEnumerable<Employee> GetAll();
        IList<Employee> ListAll();

    }
}
