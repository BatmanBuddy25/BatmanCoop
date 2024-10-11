using BatmanCoop.DatabaseContext;
using BatmanCoopShared.Model.LendModel;
using BatmanCoopShared.Model.LogsModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BatmanCoop.Controllers.LogsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionLogsController : ControllerBase
    {
        private readonly DataBaseConfiguration _context;
        public TransactionLogsController(DataBaseConfiguration context)
        {
            _context = context;
        }

        private async Task<List<TransactionLogsModel>> ReturnObj()
        {
            return await _context.TransLogsTable.Include(a => a.MemM).Include(b => b.BuyM).ToListAsync();
        }

        [HttpGet("Getmasterlist")]
        public async Task<ActionResult<IEnumerable<TransactionLogsModel>>> Getmasterlist()
        {
            return await _context.TransLogsTable.Include(a => a.MemM).Include(b => b.BuyM).ToListAsync();
        }

        [HttpGet("Getheadcount")]
        public async Task<ActionResult<int>> Getheadcount()
        {
            return await _context.TransLogsTable.CountAsync();
        }

        [HttpPost("Postobj")]
        public async Task<ActionResult<TransactionLogsModel>> Postobj(TransactionLogsModel _obj)
        {
            _context.TransLogsTable.Add(_obj);
            await _context.SaveChangesAsync();
            return Ok(await ReturnObj());
        }
    }
}
