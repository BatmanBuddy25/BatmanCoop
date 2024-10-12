using BatmanCoop.DatabaseContext;
using BatmanCoopShared.Model.LendModel;
using BatmanCoopShared.Model.ManpowerModel;
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
            return await _context.BuyerDetailsTable.Include(a=> a.MemM).Include(b => b.BuyM).ToListAsync();
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
            return Ok();
        }

        [HttpPut("Putobj")]
        public async Task<ActionResult<BuyerDetailsModel>> Putobj(BuyerDetailsModel _obj)
        {
            var _dbObj = await _context.BuyerDetailsTable.FirstOrDefaultAsync(a => a.Id == _obj.Id);
            if (_dbObj is null) return null!;

            _dbObj.Buy_Count = _obj.Buy_Count;
            _dbObj.Share_Capital = _obj.Share_Capital;
            _dbObj.Share_Points = _obj.Share_Points;
            _dbObj.Points_Amount = _obj.Points_Amount;
            _dbObj.Created_Date = _obj.Created_Date;
            _dbObj.Approve_Status = DateTime.Now;
            _dbObj.Reference_Code = _obj.Reference_Code;
            _dbObj.Buy_Status = _obj.Buy_Status;

            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
