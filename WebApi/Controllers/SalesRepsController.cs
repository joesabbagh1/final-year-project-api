using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesRepsController : ControllerBase
    {
        private readonly FattalDbContext _context;

        public SalesRepsController(FattalDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IEnumerable<SalesRep>> get()
        {
            return await _context.SalesReps.ToListAsync();
        }
    }
}
