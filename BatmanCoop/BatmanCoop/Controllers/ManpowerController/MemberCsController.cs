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

        [HttpGet("Getsortreferal")]
        public async Task<ActionResult<IEnumerable<MemberM>>> Getsortreferal([FromQuery] string referalcode)
        {
            return await _context.MemberTable.Where(a => a.ReferralId != referalcode).ToListAsync();            
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

        [HttpPut("Putobj")]
        public async Task<ActionResult<MemberM>> Putobj(MemberM _obj)
        {
            var _dbObj = await _context.MemberTable.FirstOrDefaultAsync(a => a.MemberNo == _obj.MemberNo);
            if (_dbObj is null) return null!;

            _dbObj.LastName = _obj.LastName;
            _dbObj.FirstName = _obj.FirstName;
            _dbObj.MiddleName = _obj.MiddleName;
            _dbObj.FullAddress = _obj.FullAddress;
            _dbObj.Contact = _obj.Contact;
            _dbObj.Bank_Number = _obj.Bank_Number;

            await _context.SaveChangesAsync();
            return Ok(await ReturnObj());
        }
    }
}
