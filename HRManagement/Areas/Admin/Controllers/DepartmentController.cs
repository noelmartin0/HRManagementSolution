using HRManagement.Areas.Admin.Models;
using HRManagement.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRManagement.Areas.Admin.Controllers
{
    [Route("api/Admin/[controller]")]
    [ApiController]
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
        [HttpGet("{id}")]
        public DepartmentDetail Get(int id)
        {
            return _dep.GetDepartmentById(id);
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public void Post([FromBody] DepartmentDetail value)
        {
            _dep.AddDepartment(value);

        }

        // PUT api/<DepartmentController>/5
        [HttpPut("{id}")]
        public void Put(int id,DepartmentDetail department)
        {
            _dep.UpdateDepartment(id,department);
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _dep.DeleteDepartment(id);

        }
    }
}
