using Employee.Application.Interfaces;
using Employee.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employee.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeQueryService _employeeQueryService;

        public EmployeesController(IEmployeeQueryService employeeQueryService)
        {
            _employeeQueryService = employeeQueryService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetHierarchy(int id)
        {
            var hierarchy = await _employeeQueryService.GetEmployeeHierarchyAsync(id);
            if (hierarchy == null)
                return NotFound();
            return Ok(hierarchy);
        }
    }
}
