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

    }
}
