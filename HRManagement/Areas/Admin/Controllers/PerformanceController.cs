using HRManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace HRManagement.Areas.Admin.Controllers
{
    [Route("api/Admin/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class PerformanceController : ControllerBase
    {

        IPerformanceRepo _emp;
        public PerformanceController(IPerformanceRepo repo)
        {
            _emp = repo;
        }

       
        // GET api/<PerformanceController>/5
        [HttpGet("{PerformanceId}")]
        public PerformanceDetail Get(int PerformanceId)
        {
            return _emp.GetPerformanceById(PerformanceId);
        }

        [HttpGet("Employee/{EmployeeId}")]
        public PerformanceDetail GetByEmpId(int EmployeeId)
        {
            return _emp.GetPerformanceByEmpID(EmployeeId);
        }





        // POST api/<PerformanceController>
        [HttpPost]
        public void Post([FromBody] PerformanceDetail value)
        {
            _emp.AddEmployeePerformance(value);
        }

        // PUT api/<PerformanceController>/5
        [HttpPut("{PerformanceId}")]
        public void Put(int PerformanceId, [FromBody] PerformanceDetail e)
        {
            _emp.UpdateEmployeePerformance(PerformanceId, e);

        }

        // DELETE api/<PerformanceController>/5
        [HttpDelete("{PerformanceId}")]
        public void Delete(int PerformanceId)
        {
            _emp.DeleteEmployeePerformance(PerformanceId);

        }
    }
}
