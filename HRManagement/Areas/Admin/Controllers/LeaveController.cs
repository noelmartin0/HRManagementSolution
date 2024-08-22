using HRManagement.Models;
using Microsoft.AspNetCore.Mvc;


namespace HRManagement.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {

        ILeaveRepo _emp;
        public LeaveController (ILeaveRepo repo)
        {
            _emp = repo;
        }


        // GET: api/<LeaveController>


        // GET api/<LeaveController>/5
        [HttpGet("{id}")]
        public LeaveDetail Get(int id)
        {
          return  _emp.GetLeaveByLeaveId(id);
        }


        [HttpGet("Employee/{id}")]
        public LeaveDetail GetByEmpId(int id)
        {
            return _emp.GetLeaveByEmployeeId(id);
        }




        // POST api/<LeaveController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LeaveController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] LeaveDetail value)
        {
            _emp.UpdateEmployeeLeaveDetail(id, value);
            
        }

        // DELETE api/<LeaveController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
