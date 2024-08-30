using HRManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace HRManagement.Areas.Admin.Controllers
{
    [Route("api/Admin/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class LeaveController : ControllerBase
    {

        ILeaveRepo _emp;
        public LeaveController (ILeaveRepo repo)
        {
            _emp = repo;
        }


        // GET: api/<LeaveController>


        // GET api/<LeaveController>/5
        [HttpGet("{LeaveId}")]
        public LeaveDetail Get(int LeaveId)
        {
          return  _emp.GetLeaveByLeaveId(LeaveId);
        }


        [HttpGet("Employee/{EmployeeId}")]
        public LeaveDetail GetByEmpId(int EmployeeId)
        {
            return _emp.GetLeaveByEmployeeId(EmployeeId);
        }




        // POST api/<LeaveController>
        [HttpPost]
        public void Post([FromBody] LeaveDetail leave)
        {
            _emp.AddEmployeeLeave(leave);
        }

        // PUT api/<LeaveController>/5
        [HttpPut("{LeaveId}")]
        public void Put(int LeaveId, [FromBody] LeaveDetail value)
        {
            _emp.UpdateEmployeeLeaveDetail(LeaveId, value);
            
        }

        [HttpPut("Employee/{EmployeeId}")]
        public void PutByEmpID(int EmployeeId, [FromBody] LeaveDetail value)
        {
            _emp.UpdateByEmployeeId(EmployeeId, value);

        }

        // DELETE api/<LeaveController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{

        //}
    }
}
