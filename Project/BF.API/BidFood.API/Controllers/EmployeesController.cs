using BF.API.Data;
using BF.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BF.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly APIDbContext _context;        

        public EmployeesController(APIDbContext aPIDbContext)
        {
            _context = aPIDbContext;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var employees = await _context.Employees.ToListAsync();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<ActionResult> AddEmployee([FromBody]Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return Ok(employee);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetEmployee([FromRoute]int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute]int id, [FromBody]Employee updateEmployeeRequest)
        {
            var employee = await _context.Employees.FindAsync(id);
            
            if (employee == null)
            {
                return NotFound();
            }
            else
            {                
                employee.Name= updateEmployeeRequest.Name;
                employee.Email= updateEmployeeRequest.Email;
                employee.Phone= updateEmployeeRequest.Phone;
                employee.Salary = updateEmployeeRequest.Salary;
                employee.Department= updateEmployeeRequest.Department;
                await _context.SaveChangesAsync();
                return Ok(employee);
            }            
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                return Ok(employee);
            }
        } 

    }
}
