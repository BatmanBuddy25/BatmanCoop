using BatmanCoopShared.Model.AccountModel;

namespace BatmanCoopShared.Interfaces.AccountInterface
{
    public interface IUserAccountInt
    {
        Task AddAccount(UserAccountM _obj);
        Task UpdateAccount(UserAccountM _obj);
        Task<List<UserAccountM>> GetMasterList();
        Task<int> Getheadcount();
    }
}
