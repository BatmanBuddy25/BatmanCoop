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
        public async Task<List<BuyerDetailsModel>> GetMasterList() => await _context.BuyerDetailsTable.Include(a => a.MemM).ToListAsync();

    }
}
