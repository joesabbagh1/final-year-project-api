using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuAccessController : ControllerBase
    {
        private readonly FattalDbContext _context;

        public MenuAccessController(FattalDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<MenuAccess>> Get()
        {
            return await _context.SYS_MenuAccess.ToListAsync();
        }
    }
}
