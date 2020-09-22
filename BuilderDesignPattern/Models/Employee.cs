using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace BuilderDesignPattern.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string ComputerDetails  { get; set; }
        public string ComputerSystemConfiguration { get; set; }

    }
}
