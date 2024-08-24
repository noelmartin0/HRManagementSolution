using HRManagement.Models;
using Microsoft.AspNetCore.Mvc;


namespace HRManagement.Areas.Admin.Controllers
{
    [Route("api/Admin/[controller]")]
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


        [HttpGet("Employee/{empid}")]
        public LeaveDetail GetByEmpId(int empid)
        {
            return _emp.GetLeaveByEmployeeId(empid);
        }




        // POST api/<LeaveController>
        [HttpPost]
        public void Post([FromBody] LeaveDetail leave)
        {
            _emp.AddEmployeeLeave(leave);
        }

        // PUT api/<LeaveController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] LeaveDetail value)
        {
            _emp.UpdateEmployeeLeaveDetail(id, value);
            
        }

        [HttpPut("Employee/{empid}")]
        public void PutByEmpID(int empid, [FromBody] LeaveDetail value)
        {
            _emp.UpdateByEmployeeId(empid, value);

        }

        // DELETE api/<LeaveController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{

        //}
    }
}
