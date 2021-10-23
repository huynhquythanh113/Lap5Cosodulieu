using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lap5Cosodulieu
{
    public class Department
    {
        public int DNumber { get; set; }
    public string DName { get; set; }
        public List<string> Locations { get; set; }
        public List<Employee> Employees { get; set; }
        public Employee Manager { get; set; }
        public List<Project> Projects { get; set; }// one-to-many relationship (manager) attribute
        public string MgrStartDate { get; set; }
    }
}
