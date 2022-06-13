using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly FattalDbContext _context;

        public UsersController(FattalDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _context.SYS_Users.ToListAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _context.SYS_Users.FindAsync(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(User user)
        {
            //_context.SYS_Users.FromSqlRaw("SET IDENTITY_INSERT [dbo].[SYS_Users] ON");

            
            await _context.SYS_Users.AddAsync(new User()
            {
                UserID = user.UserID,
                fullname = user.fullname,
                username = user.username,
                password = user.password,
                email = user.email,
                MenuID = user.MenuID,
                IsActive = user.IsActive,
            });

            await _context.SaveChangesAsync();
            
            //_context.SYS_Users.FromSqlRaw("SET IDENTITY_INSERT [dbo].[SYS_Users] OFF");

            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if (id != user.UserID) return BadRequest();

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userToDelete = await _context.SYS_Users.FindAsync(id);
            if (userToDelete == null) return NotFound();
            
            _context.SYS_Users.Remove(userToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
