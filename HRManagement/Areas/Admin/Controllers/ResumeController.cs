using HRManagement.Models;
using Microsoft.AspNetCore.Mvc;
using IResumeRepo = HRManagement.Areas.Admin.Models.IResumeRepo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRManagement.Areas.Admin.Controllers
{
    [Route("api/Admin/[controller]")]
    [ApiController]
    public class ResumeController : ControllerBase
    {

        IResumeRepo _emp;
        public ResumeController(IResumeRepo repo)
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
        [HttpGet("{id}")]
        public ResumeTrackingDetail Get(int id)
        {
            return _emp.GetResumeById(id);
        }

        // POST api/<ResumeController>
        [HttpPost]
        public void Post([FromBody] ResumeTrackingDetail repo)
        {
            _emp.AddResume(repo);
        }

        // PUT api/<ResumeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ResumeTrackingDetail resume)
        {
            _emp.UpdateResume(id, resume);
        }

        // DELETE api/<ResumeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _emp.DeleteResume(id);
        }
    }
}
