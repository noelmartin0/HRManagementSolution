using HRManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRManagement.Areas.Admin.Controllers
{
    [Route("api/Admin/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class PayrollController : ControllerBase
    {
        IPayrollRepo _repo;
        public PayrollController(IPayrollRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public List<PayrollDetail> GetAll()
        {
            return _repo.GetAllPayrolls();
        }

        // GET api/<PayrollController>/5
        [HttpGet("{PayrollId}")]
        public PayrollDetail Get(int PayrollId)
        {
            return _repo.GetPayrollByID(PayrollId);
        }

        [HttpGet("/Employee/{EmployeeId}")]
        public PayrollDetail GetbyEmpId(int EmployeeId)
        {
            return _repo.GetPayrollByEmpID(EmployeeId);
        }

        // POST api/<PayrollController>
        [HttpPost]
        public void Post([FromBody] PayrollDetail p)
        {
            _repo.AddEmployeePayroll(p);
        }

        // PUT api/<PayrollController>/5
        [HttpPut("{EmployeeId}")]
        public void Put(int EmployeeId, [FromBody] PayrollDetail p)
        {
            _repo.UpdateEmployeePayroll(EmployeeId, p);
        }

        // DELETE api/<PayrollController>/5
        [HttpDelete("{PayrollId}")]
        public void Delete(int PayrollId)
        {
            _repo.DeleteEmployeePayroll(PayrollId);

        }

        [HttpDelete("Employee/{EmployeeId}")]
        public void DeleteByEmpID(int EmployeeId)
        {
            _repo.DeletePayrollByEmpID(EmployeeId);

        }

    }
}
