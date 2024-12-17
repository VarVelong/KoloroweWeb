using KoloroweWeb.Data.Entities;
using KoloroweWeb.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.RegularExpressions;

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

            if (rowsAffected == 0)
            {
                return NotFound();
            }
                
            return Ok("Group property updated successfully.");
        }
    }
}
