using HRManagement.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRManagement.Areas.Admin.Controllers
{
    [Route("api/Admin/[controller]")]
    [ApiController]
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
        [HttpGet("{id}")]
        public PayrollDetail Get(int id)
        {
            return _repo.GetPayrollByID(id);
        }

        [HttpGet("api/Admin/emp/{id}")]
        public PayrollDetail GetbyEmpId(int empid)
        {
            return _repo.GetPayrollByEmpID(empid);
        }

        // POST api/<PayrollController>
        [HttpPost]
        public void Post([FromBody] PayrollDetail p)
        {
            _repo.AddEmployeePayroll(p);
        }

        // PUT api/<PayrollController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PayrollDetail p)
        {
            _repo.UpdateEmployeePayroll(id, p);
        }

        // DELETE api/<PayrollController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.DeleteEmployeePayroll(id);

        }

        [HttpDelete("Employee/{id}")]
        public void DeleteByEmpID(int id)
        {
            _repo.DeletePayrollByEmpID(id);

        }

    }
}
