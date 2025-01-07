using KoloroweWeb.Data.Entities;
using KoloroweWeb.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KoloroweWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        IRepository<Employee> employeeRepository;
        private const int DefaultGroupsId = 1;

        public EmployeesController(IRepository<Employee> employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Employee>> GetEmployees() => await employeeRepository.GetByIdAsync(DefaultGroupsId);

        [HttpPut("{groupName}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] string groupName, [FromBody] string groupContent)
        {
            List<string> validGroupNames = new List<string>
            {
                nameof(Employee.Principals),
                nameof(Employee.GroupRed),
                nameof(Employee.GroupYellow),
                nameof(Employee.GroupBlue),
                nameof(Employee.GroupGreen),
                nameof(Employee.Specialists),
            };

            if (!validGroupNames.Contains(groupName))
            {
                return BadRequest("Invalid group name.");
            }

            var existingEmployeeGroups = await employeeRepository.GetByIdAsync(DefaultGroupsId);
            switch (groupName)
            {
                case nameof(Employee.Principals):
                    existingEmployeeGroups.Principals = groupContent;
                    break;

                case nameof(Employee.GroupRed):
                    existingEmployeeGroups.GroupRed = groupContent;
                    break;

                case nameof(Employee.GroupYellow):
                    existingEmployeeGroups.GroupYellow = groupContent;
                    break;

                case nameof(Employee.GroupBlue):
                    existingEmployeeGroups.GroupBlue = groupContent;
                    break;

                case nameof(Employee.GroupGreen):
                    existingEmployeeGroups.GroupGreen = groupContent;
                    break;

                case nameof(Employee.Specialists):
                    existingEmployeeGroups.Specialists = groupContent;
                    break;

                default:
                    return BadRequest("Invalid group name.");
            }

            await employeeRepository.UpdateAsync(existingEmployeeGroups);
            return Ok("Group property updated successfully.");
        }
    }
}
