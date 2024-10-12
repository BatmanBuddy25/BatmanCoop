using BatmanCoop.DatabaseContext;
using BatmanCoopShared.Interfaces.LendInterface;
using BatmanCoopShared.Model.LendModel;
using Microsoft.EntityFrameworkCore;

namespace BatmanCoop.Repository.LendRepository
{
    public class BuyerDetailsRepo(DataBaseConfiguration context) : IBuyerDetailsInt
    {
        private readonly DataBaseConfiguration _context = context;
        public async Task AddBuyerDetails(BuyerDetailsModel _obj)
        {
            _context.BuyerDetailsTable.Add(_obj);
            await _context.SaveChangesAsync();
        }

        public async Task<int> Getheadcount() => await _context.BuyerDetailsTable.CountAsync();
        public async Task<List<BuyerDetailsModel>> GetMasterList() => await _context.BuyerDetailsTable.Include(a => a.MemM).Include(b => b.BuyM).ToListAsync();

        public async Task UpdateBuyerDetails(BuyerDetailsModel _obj)
        {
            var _dbObj = await _context.BuyerDetailsTable.FirstOrDefaultAsync(a => a.Id == _obj.Id);
            if (_dbObj is null) return;

            _dbObj.Buy_Count = _obj.Buy_Count;
            _dbObj.Share_Capital = _obj.Share_Capital;
            _dbObj.Share_Points = _obj.Share_Points;
            _dbObj.Points_Amount = _obj.Points_Amount;
            _dbObj.Created_Date = _obj.Created_Date;
            _dbObj.Approve_Status = DateTime.Now;
            _dbObj.Reference_Code = _obj.Reference_Code;
            _dbObj.Buy_Status = _obj.Buy_Status;

            await _context.SaveChangesAsync();
        }
    }
}
