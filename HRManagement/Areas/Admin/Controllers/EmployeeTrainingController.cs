
using HRManagement.Areas.Admin.Models;
using HRManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRManagement.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
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
        [HttpPut("{EmployeeId}/{TrainingId}")]
        public void Put(int EmployeeId, int TrainingId, [FromBody] EmployeeTrainingDetail value)
        {
            _repo.UpdateEmpTrainingDependancy(EmployeeId, TrainingId, value);
        }

        // DELETE api/<EmployeeTrainingController>/5
        [HttpDelete("{EmployeeId}/{TrainingId}")]
        public void Delete(int EmployeeId, int TrainingId)
        {
            _repo.DeleteEmpTrainingDependancyByEmployeeIdAndTrainingId(EmployeeId, TrainingId);
        }
    }
}
