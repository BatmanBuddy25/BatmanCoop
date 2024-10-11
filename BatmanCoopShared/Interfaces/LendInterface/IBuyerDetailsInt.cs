using BatmanCoopShared.Model.LendModel;

namespace BatmanCoopShared.Interfaces.LendInterface
{
    public interface IBuyerDetailsInt
    {
        Task AddBuyerDetails(BuyerDetailsModel _obj);
        Task<List<BuyerDetailsModel>> GetMasterList();
        Task<int> Getheadcount();
    }
}
