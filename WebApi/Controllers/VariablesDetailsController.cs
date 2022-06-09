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
    }
}
