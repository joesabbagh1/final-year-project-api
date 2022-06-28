using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VariableHeadersController : ControllerBase
    {
        private readonly FattalDbContext _context;

        public VariableHeadersController(FattalDbContext context)
        {
            _context = context;
        }

        [HttpGet("titles/{company}")]
        public async Task<IActionResult> GetTitles(int company)
        {
            var titles = (
                from varHeaders in _context.SYS_VariableHeaders
                where varHeaders.CompNo == company
                select new { varHeaders.VariableCode, varHeaders.Description }
                ).ToList();

            return titles == null ? NotFound() : Ok(titles);
        }
    }
}
