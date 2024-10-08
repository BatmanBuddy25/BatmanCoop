using BatmanCoop.DatabaseContext;
using BatmanCoopShared.Interfaces.LendInterface;
using BatmanCoopShared.Interfaces.ManpowerInterface;
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

        public async Task<List<BuyerModel>> GetMasterList() => await _context.BuyerTable.ToListAsync();
      
    }
}
