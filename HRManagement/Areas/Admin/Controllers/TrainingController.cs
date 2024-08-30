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
        [HttpGet("api/Admin/TrainingByTrainingId/{TrainingId}")]
        public TrainingDetail Get(int TrainingId)
        {
            return _tra.GetTrainingByTrainingId(TrainingId);
        }

        [HttpGet("api/Admin/EmployeesUnderSpecifiedTrainingCourse/{TrainingId}")]
        public List<EmployeeDetail> GetEmployees(int TrainingId)
        {
            return _tra.GetAllEmployeesByTrainingId(TrainingId);
        }

        [HttpGet("api/Admin/TrainingUnderwentBySpecifiedEmployee/{EmployeeId}")]
        public List<TrainingDetail> GetTrainings(int EmployeeId)
        {
            return _tra.GetTrainingsByEmployeeId(EmployeeId);
        }

        // POST api/<TrainingController>
        [HttpPost]
        public void Post([FromBody] TrainingDetail model)
        {
            _tra.AddTraining(model);
        }

        // PUT api/<TrainingController>/5
        [HttpPut("{TrainingId}")]
        public void Put(int TrainingId, [FromBody] TrainingDetail value)
        {
            _tra.UpdateTraining(TrainingId, value);
        }

        // DELETE api/<TrainingController>/5
        [HttpDelete("{TrainingId}")]
        public void Delete(int TrainingId)
        {
            _tra.DeleteTraining(TrainingId);
        }
    }
}
