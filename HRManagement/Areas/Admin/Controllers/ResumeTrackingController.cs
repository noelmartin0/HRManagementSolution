using HRManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IResumeRepo = HRManagement.Areas.Admin.Models.IResumeRepo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRManagement.Areas.Admin.Controllers
{
    [Route("api/Admin/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ResumeTrackingController : ControllerBase
    {

        IResumeRepo _emp;
        public ResumeTrackingController(IResumeRepo repo)
        {
            _emp= repo;
        }


        // GET: api/<ResumeController>
        [HttpGet]
        public List<ResumeTrackingDetail> Get()
        {
            return _emp.GetAllResumes();
        }

        // GET api/<ResumeController>/5
        [HttpGet("{ResumeId}")]
        public ResumeTrackingDetail Get(int ResumeId)
        {
            return _emp.GetResumeById(ResumeId);
        }

        // POST api/<ResumeController>
        [HttpPost]
        public void Post([FromBody] ResumeTrackingDetail repo)
        {
            _emp.AddResume(repo);
        }

        // PUT api/<ResumeController>/5
        [HttpPut("{ResumeId}")]
        public void Put(int ResumeId, [FromBody] ResumeTrackingDetail resume)
        {
            _emp.UpdateResume(ResumeId, resume);
        }

        // DELETE api/<ResumeController>/5
        [HttpDelete("{ResumeId}")]
        public void Delete(int ResumeId)
        {
            _emp.DeleteResume(ResumeId);
        }

        [HttpPost("HireApplicant/{ResumeId}")]
        public void Hire(int ResumeId, [FromBody] EmployeeDetail emp)
        {
            _emp.HireEmployee(ResumeId, emp);
        }
    }
}
