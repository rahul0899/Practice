using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Models
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }

        public int EmployeeNumber { get; set; } 
        public string EmployeeName { get; set; }
        public string CompanyName { get; set; }
    }
    public class EmployeeRequest 
    {
        public string EmployeeName { get; set; }
        public string CompanyName { get; set; }

    }
    public class EmployeeResponse
    {
        public Guid EmployeeId { get; set; }
        public int EmployeeNumber { get; set; }
        public string EmployeeName { get; set; }
        public string CompanyName { get; set; }
    }

    public class EmployeeVerificationRequest
    {
        public int EmployeeNumber { get; set; }
        public string CompanyName { get; set; }

    }
}
