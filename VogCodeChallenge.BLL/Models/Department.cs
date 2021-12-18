using System.Collections.Generic;

namespace VogCodeChallenge.BLL.Models
{
    public class Department
    {
        public Department()
        {
            this.Employees = new List<Employee>();
        }
        public string Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public IList<Employee> Employees{ get; }
    }
}
