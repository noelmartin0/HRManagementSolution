using HRManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace HRManagement.Areas.Admin.Controllers
{
    [Route("api/Admin/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class EmployeeController : ControllerBase
    {

        IEmployeeRepo _emp;
        public EmployeeController(IEmployeeRepo repo)
        {
            _emp = repo;
        }



        // GET: api/<AdminController>
        [HttpGet]//GetAll
        public List<EmployeeDetail> Get()
        {
            return _emp.GetAllEmployees();
        }

        // GET api/<AdminController>/5
        [HttpGet("{EmployeeId}")]
        public EmployeeDetail Get(int EmployeeId)
        {
            return _emp.GetEmployeeById(EmployeeId);
        }

        [HttpGet("EmployeeName/{EmployeeName}")]

        public List<EmployeeDetail> Get(string EmployeeName)
        {
            return _emp.GetEmployeeByName(EmployeeName);
        }

        [HttpGet("Department/{DeptID}")]
        public List<EmployeeDetail> GetByDeptID(int DeptID)
        {
            return _emp.GetEmployeeByDeptID(DeptID);
        }

        // POST api/<AdminController>
        [HttpPost]
        public void Post([FromBody] EmployeeDetail e)
        {

            _emp.AddEmployee(e);

        }

        // PUT api/<AdminController>/5
        [HttpPut("{EmployeeId}")]
        public void Put(int EmployeeId, [FromBody] EmployeeDetail e)
        {
            _emp.UpdateEmployee(EmployeeId, e);

        }


        // DELETE api/<AdminController>/5
        [HttpDelete("{EmployeeId}")]
        public void Delete(int EmployeeId)
        {
            _emp.DeleteEmployee(EmployeeId);
        }
    }
}
