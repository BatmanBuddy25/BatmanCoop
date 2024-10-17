using BatmanCoop.DatabaseContext;
using BatmanCoopShared.Interfaces.AccountInterface;
using BatmanCoopShared.Model.AccountModel;
using Microsoft.EntityFrameworkCore;

namespace BatmanCoop.Repository.AccountRepository
{
    public class UserAccountRepo(DataBaseConfiguration context) : IUserAccountInt
    {

        private readonly DataBaseConfiguration _context = context;
        public async Task AddAccount(UserAccountM _obj)
        {
            _context.UserAccountTable.Add(_obj);
            await _context.SaveChangesAsync();
        }

        public async Task<int> Getheadcount() => await _context.UserAccountTable.CountAsync();

        public async Task<List<UserAccountM>> GetMasterList() => await _context.UserAccountTable.ToListAsync();

        public async Task UpdateAccount(UserAccountM _obj)
        {
            var _objUser = await _context.UserAccountTable.FirstOrDefaultAsync(a => a.Id == _obj.Id);
            if (_objUser is null) return;

            _objUser.Acc_Status = _obj.Acc_Status;
            await _context.SaveChangesAsync();
        }
    }
}
