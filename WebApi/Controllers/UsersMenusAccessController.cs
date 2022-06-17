using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersMenusAccessController : ControllerBase
    {
        private readonly FattalDbContext _context;

        public UsersMenusAccessController(FattalDbContext context)
        {
            _context = context;
        }
        [HttpGet("main")]
        public async Task<IActionResult> getMain()
        {
            var menus = (
                from varDet in _context.SYS_VariableDetails
                where varDet.VariableCode == "MM01"
                select new
                {
                    varDet.SubVariableCode,
                    varDet.Description,
                    varDet.Alt_Description
                }
                ).ToList();
            return menus == null ? NotFound() : Ok(menus);
        }

        [HttpGet("{menuId}/{compNo}")]
        [ProducesResponseType(typeof(UserAccess), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(int menuId, int compNo)
        {
            var menus = (
                from ACC in _context.SYS_MenuAccess
                join NOD in _context.SYS_Nodes on ACC.NodeID equals NOD.NodeID
                join MN1 in _context.SYS_VariableDetails on 
                new { c1 = NOD.MainNodeID1.ToString(), c2 = "MN01" } equals new { c1 = MN1.SubVariableCode, c2 = MN1.VariableCode}
                into a 
                from MN1 in  a.DefaultIfEmpty()
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
                where ACC.MenuID == menuId
                where ACC.CompNo == compNo
                //select MN1
                select new
                {
                    description1 = MN1.Description,
                    description2 = MN2.Description,
                    description3 = MN3.Description,
                    description4 = MN4.Description,
                    description5 = MN5.Description,
                    nodeDescription = NOD.NodeDescription1,
                    nodeID = NOD.NodeID
                }
                ).ToList();



            return menus == null ? NotFound() : Ok(menus);
        }
    }
}
