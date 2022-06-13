using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodesController : ControllerBase
    {
        private readonly FattalDbContext _context;

        public NodesController(FattalDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Node>> Get()
        {
            return await _context.SYS_Nodes.ToListAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(string id)
        {
            var node = await _context.SYS_Nodes.FindAsync(id);
            return node == null ? NotFound() : Ok(node);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Node node)
        {


            await _context.SYS_Nodes.AddAsync(new Node()
            {
                
            });

            await _context.SaveChangesAsync();


            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateNode(string id, Node node)
        {
            if (id != node.NodeID) return BadRequest();

            _context.Entry(node).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var nodeToDelete = await _context.SYS_Nodes.FindAsync(id);
            if (nodeToDelete == null) return NotFound();

            _context.SYS_Nodes.Remove(nodeToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}