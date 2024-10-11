using BatmanCoop.DatabaseContext;
using BatmanCoopShared.Model.LendModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BatmanCoop.Controllers.LendController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerDetailsController : ControllerBase
    {
        private readonly DataBaseConfiguration _context;
        public BuyerDetailsController(DataBaseConfiguration context)
        {
            _context = context;
        }

        private async Task<List<BuyerDetailsModel>> ReturnObj()
        {
            return await _context.BuyerDetailsTable.Include(a => a.MemM).ToListAsync();
        }

        [HttpGet("Getmasterlist")]
        public async Task<ActionResult<IEnumerable<BuyerDetailsModel>>> Getmasterlist()
        {
            return await _context.BuyerDetailsTable.Include(a=> a.MemM).ToListAsync();
        }

        [HttpGet("Getheadcount")]
        public async Task<ActionResult<int>> Getheadcount()
        {
            return await _context.BuyerDetailsTable.CountAsync();
        }

        [HttpPost("Postobj")]
        public async Task<ActionResult<BuyerDetailsModel>> Postobj(BuyerDetailsModel _obj)
        {
            _context.BuyerDetailsTable.Add(_obj);
            await _context.SaveChangesAsync();
            return Ok(await ReturnObj());
        }
    }
}
