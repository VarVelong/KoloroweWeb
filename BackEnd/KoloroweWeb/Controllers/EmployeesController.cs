using KoloroweWeb.Data;
using KoloroweWeb.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KoloroweWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly KolorowewebContext kolorowewebContext;

        public EmployeesController(KolorowewebContext context)
        {
            kolorowewebContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employees>>> GetEmployees()
        {
            return await kolorowewebContext.Employees.ToListAsync();
        }

        [HttpPut("{groupName}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] string groupName, [FromBody] string groupContent)
        {
            var validGroupNames = new List<string>
            {
                nameof(Employees.Principals),
                nameof(Employees.GroupRed),
                nameof(Employees.GroupYellow),
                nameof(Employees.GroupBlue),
                nameof(Employees.GroupGreen),
                nameof(Employees.Specialists),
            };

            if (!validGroupNames.Contains(groupName))
            {
                return BadRequest("Invalid group name.");
            }

            var sql = $"UPDATE employees SET {groupName} = @groupContent WHERE Id = 1";

            var rowsAffected = await kolorowewebContext.Database.ExecuteSqlRawAsync(sql, groupContent);             
            return rowsAffected == 0 ? NotFound() : Ok("Group property updated successfully.");
        }
    }
}
