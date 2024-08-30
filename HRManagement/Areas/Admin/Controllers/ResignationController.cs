using HRManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRManagement.Areas.Admin.Controllers
{
    [Route("api/Admin/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ResignationController : ControllerBase
    {
        IResignationRepo _res;
        public ResignationController(IResignationRepo res)
        {
            _res = res; 
        }


   
        // GET api/<ResignationController>/5
        [HttpGet("{ResignationId}")]
        public ResignationDetail GetResignation(int ResignationId)
        {
           return _res.GetResignationById(ResignationId);

        }
         

        [HttpGet("Employee/{EmployeeId}")]
        public ResignationDetail GetByEmployeeId(int EmployeeId)
        {
            return _res.GetResignationByEmployeeId(EmployeeId);

        }

        // POST api/<ResignationController>
        [HttpPost]
        public void Post([FromBody] ResignationDetail res)
        {
            _res.AddEmployeeResignation(res);
        }

      

        // DELETE api/<ResignationController>/5
        [HttpDelete("{ResignationId}")]
        public void Delete(int ResignationId)
        {
            _res.DeleteEmployeeResignation(ResignationId);
        }


    }
}
