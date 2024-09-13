using BussinessObject.Models;

namespace BussinessLogic.Repository
{
    public interface IEmployeeRepository
    {
        Task<EmployeeResponse> AddEmployee(EmployeeRequest employeeRequest);
        Task<string> CheckEmployee(EmployeeVerificationRequest employee);
    }
}