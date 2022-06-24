using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersCompaniesAccessController : ControllerBase
    {
        private readonly FattalDbContext _context;

        public UsersCompaniesAccessController(FattalDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<UserAccess>> Get()
        {
            return await _context.SYS_UsersAccess.ToListAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserAccess), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(int id)
        {
            var companies = (
                from p in _context.SYS_UsersAccess
                join pm in _context.SYS_VariableDetails on
                new { f1 = p.AccessVariable1, f2 = "CO01" } equals new { f1 = pm.SubVariableCode, f2 = pm.VariableCode }
                where p.AccessType == "UA0000"
                where p.UserID == id
                select new
                {
                    variableCode = pm.VariableCode,
                    compNo = pm.SubVariableCode,
                    description = pm.Description,
                    alt_description = pm.Alt_Description
                }).ToList();

            return companies == null ? NotFound() : Ok(companies);
        }
    }
}