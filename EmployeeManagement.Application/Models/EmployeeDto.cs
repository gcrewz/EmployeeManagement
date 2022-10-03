using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.Models
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
    }
}
