using Microsoft.AspNetCore.Mvc;
using TestTask.Services.Interfaces;

namespace TestTask
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetEmployeeById([FromRoute] int id, [FromServices] IEmployeeService employeeService)
        {
            return Ok(employeeService.GetEmployeeById(id));
        }

        [HttpPatch("{id}/enabled")]
        public IActionResult SwitchEmployeesEnabledState(
            [FromRoute] int id, 
            [FromQuery] bool enabled, 
            [FromServices] IEmployeeService employeeService
        )
        {
            employeeService.SwitchEmployeesEnabled(id, enabled);

            return Ok();
        }
    }
}
