using HRManagement.Areas.Admin.Models;
using HRManagement.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRManagement.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTrainingController : ControllerBase
    {
        IEmployeeTrainingRepo _repo;
        public EmployeeTrainingController(IEmployeeTrainingRepo _repo)
        {
            this._repo = _repo;
        }

        // GET: api/<EmployeeTrainingController>
        [HttpGet]
        public List<EmployeeTrainingDetail> Get()
        {
            return _repo.GetAllRecords();
        }

        //// GET api/<EmployeeTrainingController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<EmployeeTrainingController>
        [HttpPost]
        public void Post([FromBody] EmployeeTrainingDetail value)
        {
            _repo.AddEmpTrainingDependancy(value);
        }

        // PUT api/<EmployeeTrainingController>/5
        [HttpPut("{empid}/{traid}")]
        public void Put(int empid,int traid, [FromBody] EmployeeTrainingDetail value)
        {
            _repo.UpdateEmpTrainingDependancy(empid, traid, value);
        }

        // DELETE api/<EmployeeTrainingController>/5
        [HttpDelete("{empid}/{traid}")]
        public void Delete(int empid,int traid)
        {
            _repo.DeleteEmpTrainingDependancyByEmployeeIdAndTrainingId(empid, traid);
        }
    }
}
