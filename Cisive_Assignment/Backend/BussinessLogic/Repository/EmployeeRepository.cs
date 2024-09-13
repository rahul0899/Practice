using BussinessObject.Models;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<EmployeeResponse> AddEmployee(EmployeeRequest employeeRequest)
        {
            var employee = new Employee
            {
                EmployeeId = Guid.NewGuid(),
                EmployeeName = employeeRequest.EmployeeName,
                CompanyName = employeeRequest.CompanyName,
            };
            var lastEmployee = await _context.Employee.OrderByDescending(e => e.EmployeeNumber).FirstOrDefaultAsync();
            var employeeNumber = (lastEmployee != null) ? lastEmployee.EmployeeNumber + 1 : 1;
            employee.EmployeeNumber = employeeNumber;
            await _context.Employee.AddAsync(employee);
            await _context.SaveChangesAsync();
            var employeeResponse = new EmployeeResponse
            {
                EmployeeId = employee.EmployeeId,
                EmployeeNumber = employee.EmployeeNumber,
                EmployeeName =employee.EmployeeName,
                CompanyName = employee.CompanyName,
            };

            return employeeResponse;
        }
        public async Task<string> CheckEmployee(EmployeeVerificationRequest employee)
        {
            var existingEmployee = await _context.Employee
                .FirstOrDefaultAsync(x => x.EmployeeNumber == employee.EmployeeNumber && x.CompanyName == employee.CompanyName);

            if (existingEmployee != null)
            {
                return "Verified";
            }

            return "Not Verified";
        }
    }
}
