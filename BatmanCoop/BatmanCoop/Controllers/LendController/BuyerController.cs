using BatmanCoop.DatabaseContext;
using BatmanCoopShared.Model.LendModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BatmanCoop.Controllers.LendController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        private readonly DataBaseConfiguration _context;
        public BuyerController(DataBaseConfiguration context)
        {
            _context = context;
        }

        private async Task<List<BuyerModel>> ReturnObj()
        {
            return await _context.BuyerTable.ToListAsync();
        }

        [HttpPost("Postobj")]
        public async Task<ActionResult<BuyerModel>> PostMemberModel(BuyerModel _obj)
        {
            _context.BuyerTable.Add(_obj);
            await _context.SaveChangesAsync();
            return Ok(await ReturnObj());
        }
    }
}
