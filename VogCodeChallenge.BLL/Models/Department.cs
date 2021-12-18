using System;
using System.Collections.Generic;
using System.Text;

namespace VogCodeChallenge.BLL.Models
{
    public class Department
    {
        public Department()
        {
            this.Employees = new List<Employee>();
        }
        public string Name { get; set; }

        public string Address { get; set; }

        public IList<Employee> Employees{ get; }
    }
}
