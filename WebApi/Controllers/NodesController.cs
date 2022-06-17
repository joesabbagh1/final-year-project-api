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

        [HttpGet("decriptions")]
        public async Task<IActionResult> GetDesc()
        {
            var nodes = (
               from NOD in _context.SYS_Nodes
               join MN1 in _context.SYS_VariableDetails on
               new { c1 = NOD.MainNodeID1.ToString(), c2 = "MN01" } equals new { c1 = MN1.SubVariableCode, c2 = MN1.VariableCode }
               into a
               from MN1 in a.DefaultIfEmpty()
               join MN2 in _context.SYS_VariableDetails on
               new { c1 = NOD.MainNodeID2.ToString(), c2 = "MN02" } equals new { c1 = MN2.SubVariableCode, c2 = MN2.VariableCode }
               into b
               from MN2 in b.DefaultIfEmpty()
               join MN3 in _context.SYS_VariableDetails on
               new { c1 = NOD.MainNodeID3.ToString(), c2 = "MN03" } equals new { c1 = MN3.SubVariableCode, c2 = MN3.VariableCode }
               into c
               from MN3 in c.DefaultIfEmpty()
               join MN4 in _context.SYS_VariableDetails on
               new { c1 = NOD.MainNodeID4.ToString(), c2 = "MN04" } equals new { c1 = MN4.SubVariableCode, c2 = MN4.VariableCode }
               into d
               from MN4 in d.DefaultIfEmpty()
               join MN5 in _context.SYS_VariableDetails on
               new { c1 = NOD.MainNodeID5.ToString(), c2 = "MN05" } equals new { c1 = MN5.SubVariableCode, c2 = MN5.VariableCode }
               into e
               from MN5 in e.DefaultIfEmpty()
               select new
               {
                   nodeID = NOD.NodeID,
                   nodeDescription1 = NOD.NodeDescription1,
                   nodeDescription2 = NOD.NodeDescription2,
                   MainNodeID1 = MN1.Description,
                   MainNodeID2 = MN2.Description,
                   MainNodeID3 = MN3.Description,
                   MainNodeID4 = MN4.Description,
                   MainNodeID5 = MN5.Description,
               }
               ).ToList();

            return nodes == null ? NotFound() : Ok(nodes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(string id)
        {
            var node = (
               from NOD in _context.SYS_Nodes
               join MN1 in _context.SYS_VariableDetails on
               new { c1 = NOD.MainNodeID1.ToString(), c2 = "MN01" } equals new { c1 = MN1.SubVariableCode, c2 = MN1.VariableCode }
               into a
               from MN1 in a.DefaultIfEmpty()
               join MN2 in _context.SYS_VariableDetails on
               new { c1 = NOD.MainNodeID2.ToString(), c2 = "MN02" } equals new { c1 = MN2.SubVariableCode, c2 = MN2.VariableCode }
               into b
               from MN2 in b.DefaultIfEmpty()
               join MN3 in _context.SYS_VariableDetails on
               new { c1 = NOD.MainNodeID3.ToString(), c2 = "MN03" } equals new { c1 = MN3.SubVariableCode, c2 = MN3.VariableCode }
               into c
               from MN3 in c.DefaultIfEmpty()
               join MN4 in _context.SYS_VariableDetails on
               new { c1 = NOD.MainNodeID4.ToString(), c2 = "MN04" } equals new { c1 = MN4.SubVariableCode, c2 = MN4.VariableCode }
               into d
               from MN4 in d.DefaultIfEmpty()
               join MN5 in _context.SYS_VariableDetails on
               new { c1 = NOD.MainNodeID5.ToString(), c2 = "MN05" } equals new { c1 = MN5.SubVariableCode, c2 = MN5.VariableCode }
               into e
               from MN5 in e.DefaultIfEmpty()
               where NOD.NodeID == id
               select new
               {
                   nodeID = NOD.NodeID,
                   nodeDescription1 = NOD.NodeDescription1,
                   nodeDescription2 = NOD.NodeDescription2,
                   crReportName = NOD.CRReportName,
                   reportName = NOD.FileName,
                   MainNodeID1 = MN1.Description,
                   MainNodeID2 = MN2.Description,
                   MainNodeID3 = MN3.Description,
                   MainNodeID4 = MN4.Description,
                   MainNodeID5 = MN5.Description,
               }
               ).First();

            return node == null ? NotFound() : Ok(node);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Node node)
        {


            await _context.SYS_Nodes.AddAsync(node);

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