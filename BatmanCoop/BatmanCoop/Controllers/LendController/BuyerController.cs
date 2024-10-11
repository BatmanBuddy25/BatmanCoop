using BatmanCoop.DatabaseContext;
using BatmanCoopShared.Model.LendModel;
using BatmanCoopShared.Model.ManpowerModel;
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

        [HttpGet("Getmasterlist")]
        public async Task<ActionResult<IEnumerable<BuyerModel>>> Getmasterlist()
        {
            return await _context.BuyerTable.ToListAsync();
        }

        [HttpGet("Getheadcount")]
        public async Task<ActionResult<int>> Getheadcount()
        {
            return await _context.BuyerTable.CountAsync();
        }

        [HttpPost("Postobj")]
        public async Task<ActionResult<BuyerModel>> Postobj(BuyerModel _obj)
        {
            _context.BuyerTable.Add(_obj);
            await _context.SaveChangesAsync();
            return Ok(await ReturnObj());
        }

        [HttpPut("Buysharecap")]
        public async Task<ActionResult<BuyerModel>> Buysharecap(BuyerModel _obj)
        {
            var _dbObj = await _context.BuyerTable.FirstOrDefaultAsync(a => a.Buy_Code == _obj.Buy_Code);
            if (_dbObj is null) return null!;

            _dbObj.Share_Capital = _obj.Share_Capital;
            _dbObj.Created_Date = _obj.Created_Date;
            _dbObj.Valid_Date = _obj.Valid_Date;
            _dbObj.Share_Status = _obj.Share_Status;

            await _context.SaveChangesAsync();
            return Ok(await ReturnObj());
        }
    }
}
