using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VariablesDetailsController : ControllerBase
    {
        private readonly FattalDbContext _context;

        public VariablesDetailsController(FattalDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<VariableDetails>> Get()
        {
            return await _context.SYS_VariableDetails.ToListAsync();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(VariableDetails variable)
        {

            await _context.SYS_VariableDetails.AddAsync(variable);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{compNo}/{variableCode}/{subVariableCode}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int compNo, string variableCode, string subVariableCode, VariableDetails variable)
        {
            if (compNo != variable.CompNo && variableCode != variable.VariableCode && subVariableCode != variable.SubVariableCode) return BadRequest();

            _context.Entry(variable).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{compNo}/{variableCode}/{subVariableCode}")]
        public async Task<IActionResult> Delete(int compNo, string variableCode, string subVariableCode)
        {
            var variableToDelete = await _context.SYS_VariableDetails.FindAsync(compNo, variableCode, subVariableCode);
            if (variableToDelete == null) return NotFound();

            _context.SYS_VariableDetails.Remove(variableToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("nodes/{level}")]
        public async Task<IActionResult> GetLevels(int level)
        {
            var nodes = (
                from varDetails in _context.SYS_VariableDetails
                where varDetails.VariableCode == "MN0" + level
                select new { 
                    varDetails.Description,
                    SubVariableCode = Int32.Parse(varDetails.SubVariableCode)
                }).ToList();
            return nodes == null ? NotFound() : Ok(nodes);
        }

        [HttpGet("{company}/{code}")]
        public async Task<IActionResult> GetDetails(int company, string code)
        {
            var details = (
                from varDetails in _context.SYS_VariableDetails
                where varDetails.VariableCode == code
                where varDetails.CompNo == company
                select varDetails
                ).ToList();

            return details == null ? NotFound() : Ok(details);
        }
    }
}
