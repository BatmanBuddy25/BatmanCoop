using BatmanCoop.DatabaseContext;
using BatmanCoopShared.Interfaces.LendInterface;
using BatmanCoopShared.Model.LendModel;
using Microsoft.EntityFrameworkCore;

namespace BatmanCoop.Repository.LendRepository
{
    public class BuyerRepo(DataBaseConfiguration context) : IBuyerInt
    {
        private readonly DataBaseConfiguration _context = context;
        public async Task AddBuyer(BuyerModel _obj)
        {
            _context.BuyerTable.Add(_obj);
            await _context.SaveChangesAsync();
        }

        public async Task BuySharecap(BuyerModel _obj)
        {
            var _dbObj = await _context.BuyerTable.FirstOrDefaultAsync(a => a.Buy_Code == _obj.Buy_Code);
            if (_dbObj is null) return;

            _dbObj.Share_Capital = _obj.Share_Capital;
            _dbObj.Created_Date = _obj.Created_Date;
            _dbObj.Valid_Date = _obj.Valid_Date;
            _dbObj.Share_Status = _obj.Share_Status;

            await _context.SaveChangesAsync();
        }

        public async Task<int> Getheadcount() => await _context.BuyerTable.CountAsync();
        public async Task<List<BuyerModel>> GetMasterList() => await _context.BuyerTable.ToListAsync();

    }
}
