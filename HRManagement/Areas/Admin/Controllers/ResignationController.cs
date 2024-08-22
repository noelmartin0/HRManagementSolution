using HRManagement.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRManagement.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResignationController : ControllerBase
    {
        IResignationRepo _res;
        public ResignationController(IResignationRepo res)
        {
            _res = res; 
        }


   
        // GET api/<ResignationController>/5
        [HttpGet("{id}")]
        public ResignationDetail GetByPayroll(int id)
        {
           return _res.GetResignationById(id);

        }
         

        [HttpGet("emp/{id}")]
        public ResignationDetail GetByEmployeeId(int id)
        {
            return _res.GetResignationByEmployeeId(id);

        }

        // POST api/<ResignationController>
        [HttpPost]
        public void Post([FromBody] ResignationDetail res)
        {
            _res.AddEmployeeResignation(res);
        }

      

        // DELETE api/<ResignationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _res.DeleteEmployeeResignation(id);
        }


    }
}
