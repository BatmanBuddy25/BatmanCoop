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

        public async Task<List<MemberM>> GetSortreferal(string _refCode)
        {
            return await _context.MemberTable.Where(a => a.ReferralId != _refCode).ToListAsync();
        }

        public async Task InsertMember(MemberM _obj)
        {
            _context.MemberTable.Add(_obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMember(MemberM _obj)
        {
            var _dbObj = await _context.MemberTable.FirstOrDefaultAsync(a => a.MemberNo == _obj.MemberNo);
            if (_dbObj is null) return;

            _dbObj.LastName = _obj.LastName;
            _dbObj.FirstName = _obj.FirstName;
            _dbObj.MiddleName = _obj.MiddleName;
            _dbObj.FullAddress = _obj.FullAddress;
            _dbObj.Contact = _obj.Contact;
            _dbObj.Bank_Number = _obj.Bank_Number;

            await _context.SaveChangesAsync();
        }
    }
}
