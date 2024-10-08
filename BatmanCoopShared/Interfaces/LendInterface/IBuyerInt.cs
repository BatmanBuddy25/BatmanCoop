using BatmanCoopShared.Model.LendModel;

namespace BatmanCoopShared.Interfaces.LendInterface
{
    public interface IBuyerInt
    {
        Task AddBuyer(BuyerModel _obj);
        Task<List<BuyerModel>> GetMasterList();
    }
}
