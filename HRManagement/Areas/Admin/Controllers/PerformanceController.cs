using HRManagement.Models;
using Microsoft.AspNetCore.Mvc;


namespace HRManagement.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceController : ControllerBase
    {

        IPerformanceRepo _emp;
        public PerformanceController(IPerformanceRepo repo)
        {
            _emp = repo;
        }

       
        // GET api/<PerformanceController>/5
        [HttpGet("{id}")]
        public PerformanceDetail Get(int id)
        {
            return _emp.GetPerformanceById(id);
        }

        // POST api/<PerformanceController>
        [HttpPost]
        public void Post([FromBody] PerformanceDetail value)
        {
            _emp.AddEmployeePerformance(value);
        }

        // PUT api/<PerformanceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PerformanceDetail e)
        {
            _emp.UpdateEmployeePerformance(id, e);

        }

        // DELETE api/<PerformanceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _emp.DeleteEmployeePerformance(id);

        }
    }
}
