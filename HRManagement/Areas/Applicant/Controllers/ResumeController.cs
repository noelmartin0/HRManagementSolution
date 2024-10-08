﻿
using HRManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRManagement.Areas.Applicant.Controllers
{
    [Route("api/Applicant/[controller]")]
    [ApiController]
    //[AllowAnonymous]
    public class ResumeController : ControllerBase
    {
        IResumeRepo _repo;
        public ResumeController(IResumeRepo repo)
        {
            _repo = repo;
        }
       
        // POST api/<ResumeController>
        [HttpPost]
        public void Post([FromBody] ResumeTrackingDetail resume)
        {
            _repo.AddResume(resume);
        }

    }
}
