using BussinessLogic.Repository;
using BussinessObject.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeVerificationBackend.Controllers
{
    [ApiController]
    [Route("api/")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpPost("addemployee")]
        public async Task<IActionResult> AddEmployee(EmployeeRequest employee)
        {
            var result = await _employeeRepository.AddEmployee(employee);
            return Ok(result);
        }

        [HttpPost("verifyemployee")]
        public async Task<IActionResult> VerifyEmployee(EmployeeVerificationRequest employee)
        {
            var result = await _employeeRepository.CheckEmployee(employee);
            if(result == "Verified")
            {
                return Json(new {Status = "Verified"});
            }
            return Json(new {Status ="Not Verified"});
        }
    }
}
