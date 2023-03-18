using CoreDemoAPI.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetListEmployees()
        {
            using Context c = new Context();

            var values = c.Employees.ToList();

            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            using Context c = new Context();
            c.Add(employee);
            c.SaveChanges();
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetFindById(int? id)
        {
            using Context c = new Context();
            var employee = c.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employee);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            using Context context = new Context();
            var employee = context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
                return Ok();
            }
        }
        [HttpPut]
        public IActionResult UpdateEmployee(Employee employee)
        {
            using var c = new Context();
            var updatedemployee = c.Employees.Find(employee.EmployeeID);
            if(updatedemployee == null)
            {
                return NotFound();
            }
            else
            {
                updatedemployee.EmployeeName = employee.EmployeeName;
                c.Employees.Update(updatedemployee);
                c.SaveChanges();
                return Ok();
            }
        }
    }
}
