using BookStoreApp.Context;
using BookStoreApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public EmployeeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] Employee employeeObj)
        {
            if (employeeObj == null)
                return BadRequest();
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Username == employeeObj.Username && x.Password == employeeObj.Password);
            if (employee == null)
                return NotFound(new {Message = "Employee Not Found"});
            return Ok(new
            {
                Message = "Login Successful!"
            });
            
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _dbContext.Employees.ToListAsync();
            return employees;
        }

        // POST: api/employees
        [HttpPost("Register")]
        public async Task<ActionResult<Employee>> RegisterEmployee(Employee employeeObj)
        {
            if (employeeObj == null)
                return BadRequest();

            await _dbContext.Employees.AddAsync(employeeObj);
            await _dbContext.SaveChangesAsync();

            return Ok("Employee created Successfully");
        }

        // GET: api/employees/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }
    }
}
