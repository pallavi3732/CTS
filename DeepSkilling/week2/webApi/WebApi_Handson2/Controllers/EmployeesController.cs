using Microsoft.AspNetCore.Mvc;
using SwaggerWebApi.Models;

namespace SwaggerWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class EmployeesController : ControllerBase
    {
        private static readonly List<Employee> Employees = new()
        {
            new Employee { Id = 1, Name = "Sadwik", Department = "Engineering", Salary = 45000 },
            new Employee { Id = 2, Name = "Kranthi", Department = "QA", Salary = 40000 }
        };

        
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Employee>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Employee>> GetAll() => Ok(Employees);

      
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Employee> GetById(int id)
        {
            var employee = Employees.FirstOrDefault(e => e.Id == id);
            return employee is null ? NotFound() : Ok(employee);
        }

        
        [HttpPost]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status201Created)]
        public ActionResult<Employee> Create([FromBody] Employee employee)
        {
            employee.Id = Employees.Max(e => e.Id) + 1;
            Employees.Add(employee);
            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
        }
    }
}
