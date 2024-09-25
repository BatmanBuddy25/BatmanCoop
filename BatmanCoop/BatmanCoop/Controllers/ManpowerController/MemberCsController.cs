using BatmanCoop.DatabaseContext;
using BatmanCoopShared.Model.ManpowerModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BatmanCoop.Controllers.ManpowerController
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberCsController : ControllerBase
    {
        private readonly DataBaseConfiguration _context;
        public MemberCsController(DataBaseConfiguration context)
        {
            _context = context;
        }

        private async Task<List<MemberM>> ReturnObj()
        {
            return await _context.MemberTable.ToListAsync();
        }

        // GET: api/Members
        [HttpGet("Getmasterlist")]
        public async Task<ActionResult<IEnumerable<MemberM>>> GetMemberTable()
        {
            return await _context.MemberTable.ToListAsync();
        }

        [HttpGet("Getheadcount")]
        public async Task<ActionResult<int>> Getheadcount()
        {
            return await _context.MemberTable.CountAsync();
        }

        [HttpPost("Postobj")]
        public async Task<ActionResult<MemberM>> PostMemberModel(MemberM _obj)
        {
            _context.MemberTable.Add(_obj);
            await _context.SaveChangesAsync();
            return Ok(await ReturnObj());
        }
    }
}
