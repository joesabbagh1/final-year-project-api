using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersAccessController : ControllerBase
    {
        private readonly FattalDbContext _context;

        public UsersAccessController(FattalDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<UserAccess>> get()
        {
            return await _context.SYS_UsersAccess.ToListAsync();

        }

        [HttpGet("{accessType}")]
        public async Task<IActionResult> getAccessType(string accessType)
        {
            var usersAccess = (
                from userAccess in _context.SYS_UsersAccess
                where userAccess.AccessType == accessType
                select userAccess
                ).ToList();
            return usersAccess == null ? NotFound() : Ok(usersAccess);
        }

        [HttpGet("{accessType}/{accessVariable}")]
        public async Task<IActionResult> getAccessVariables(string accessType, string accessVariable)
        {
            var usersAccess = (
                from userAccess in _context.SYS_UsersAccess
                where userAccess.AccessType == accessType
                where userAccess.AccessVariable1 == accessVariable
                select userAccess
                ).ToList();
            return usersAccess == null ? NotFound() : Ok(usersAccess);
        }


        [HttpPost]
        public async Task<IActionResult> Create(UserAccess userAccess)
        {
            await _context.SYS_UsersAccess.AddAsync(userAccess);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{userID}/{accessType}/{accessVariable}/{compNo}")]
        public async Task<IActionResult> Delete(int userID, string accessType, string accessVariable, int compNo)
        {
            var menuAccessToDelete = await _context.SYS_UsersAccess.FindAsync(userID, accessType, accessVariable, compNo);
            if (menuAccessToDelete == null) return NotFound();

            _context.SYS_UsersAccess.Remove(menuAccessToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
