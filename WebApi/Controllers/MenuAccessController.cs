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

        [HttpGet("{compNo}/{subVariableCode}")]
        public async Task<IActionResult> getAccess(int compNo, int subVariableCode)
        {
            var access = (
                from NOD in _context.SYS_Nodes
                join MenuAcc in _context.SYS_MenuAccess
                on new { a = NOD.NodeID, b = compNo, c = subVariableCode } equals new { a = MenuAcc.NodeID, b = MenuAcc.CompNo, c = MenuAcc.MenuID }
                into a
                from b in a.DefaultIfEmpty()
                select b.NodeID 
                ).ToList();

            return access == null ? NotFound() : Ok(access);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MenuAccess menuAccess)
        {
            //await _context.SYS_MenuAccess.AddAsync(menuAccess);
            await _context.SYS_MenuAccess.AddAsync(menuAccess);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{NodeID}/{MenuID}/{CompNo}")]
        public async Task<IActionResult> Delete(string NodeID, int MenuID, int CompNo)
        {
            var menuAccessToDelete = await _context.SYS_MenuAccess.FindAsync(NodeID, MenuID, CompNo);
            if (menuAccessToDelete == null) return NotFound();

            _context.SYS_MenuAccess.Remove(menuAccessToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
