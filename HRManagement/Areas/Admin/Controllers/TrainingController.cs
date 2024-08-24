using HRManagement.Areas.Admin.Models;
using HRManagement.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRManagement.Areas.Admin.Controllers
{
    [Route("api/Admin/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        ITrainingRepo _tra;
        public TrainingController(ITrainingRepo tra)
        {
            _tra=tra;
        }

        // GET: api/<TrainingController>
        [HttpGet]
        public List<TrainingDetail> Get()
        {
            return _tra.GetAllTrainings();
        }

        // GET api/<TrainingController>/5
        [HttpGet("api/Admin/TrainingByTrainingId/{id}")]
        public TrainingDetail Get(int id)
        {
            return _tra.GetTrainingByTrainingId(id);
        }

        [HttpGet("api/Admin/EmployeesUnderSpecifiedTrainingCourse/{id}")]
        public List<EmployeeDetail> GetEmployees(int id)
        {
            return _tra.GetAllEmployeesByTrainingId(id);
        }

        [HttpGet("api/Admin/TrainingUnderwentBySpecifiedEmployee/{id}")]
        public List<TrainingDetail> GetTrainings(int id)
        {
            return _tra.GetTrainingsByEmployeeId(id);
        }

        // POST api/<TrainingController>
        [HttpPost]
        public void Post([FromBody] TrainingDetail model)
        {
            _tra.AddTraining(model);
        }

        // PUT api/<TrainingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TrainingDetail value)
        {
            _tra.UpdateTraining(id, value);
        }

        // DELETE api/<TrainingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _tra.DeleteTraining(id);
        }
    }
}
