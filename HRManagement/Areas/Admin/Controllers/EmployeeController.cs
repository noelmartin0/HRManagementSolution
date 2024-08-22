﻿using HRManagement.Models;
using Microsoft.AspNetCore.Mvc;



namespace HRManagement.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        IEmployeeRepo _emp;
        public EmployeeController(IEmployeeRepo repo)
        {
            _emp = repo;
        }



        // GET: api/<AdminController>
        [HttpGet]//GetAll
        public List<EmployeeDetail> Get()
        {
            return _emp.GetAllEmployees();
        }

        // GET api/<AdminController>/5
        [HttpGet("{id}")]
        public EmployeeDetail Get(int id)
        {
            return _emp.GetEmployeeById(id);
        }

        // POST api/<AdminController>
        [HttpPost]
        public void Post([FromBody] EmployeeDetail e)
        {
            _emp.AddEmployee(e);

        }

        // PUT api/<AdminController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EmployeeDetail e)
        {
            _emp.UpdateEmployee(id, e);

        }

        // DELETE api/<AdminController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _emp.DeleteEmployee(id);
        }
    }
}
