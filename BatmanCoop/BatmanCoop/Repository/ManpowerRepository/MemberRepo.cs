using BatmanCoop.DatabaseContext;
using BatmanCoopShared.Interfaces.ManpowerInterface;
using BatmanCoopShared.Model.ManpowerModel;
using Microsoft.EntityFrameworkCore;

namespace BatmanCoop.Repository.ManpowerRepository
{
    public class MemberRepo(DataBaseConfiguration context) : IMemberInt
    {
        private readonly DataBaseConfiguration _context = context;

        public  async Task<int> Getheadcount()=> await _context.MemberTable.CountAsync();

        public async Task<List<MemberM>> GetMasterList() => await _context.MemberTable.ToListAsync();

        public async Task InsertMember(MemberM _obj)
        {
            _context.MemberTable.Add(_obj);
            await _context.SaveChangesAsync();
        }
    }
}
