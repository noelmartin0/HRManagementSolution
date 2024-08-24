using HRManagement.Areas.Admin.Models;
using HRManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRManagement.Areas.Admin.Controllers
{
    [Route("api/Admin/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class DepartmentController : ControllerBase
    {
        IDepartmentRepo _dep;
        public DepartmentController(IDepartmentRepo _dep)
        {
            this._dep = _dep;
        }



        // GET: api/<DepartmentController>
        [HttpGet]
        public List<DepartmentDetail> Get()
        {
            return _dep.GetAllDepartments();
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{DepartmentId}")]
        public DepartmentDetail Get(int DepartmentId)
        {
            return _dep.GetDepartmentById(DepartmentId);
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public void Post([FromBody] DepartmentDetail value)
        {
            _dep.AddDepartment(value);

        }

        // PUT api/<DepartmentController>/5
        [HttpPut("{DepartmentId}")]
        public void Put(int DepartmentId, DepartmentDetail department)
        {
            _dep.UpdateDepartment(DepartmentId, department);
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{DepartmentId}")]
        public void Delete(int DepartmentId)
        {
            _dep.DeleteDepartment(DepartmentId);

        }
    }
}
