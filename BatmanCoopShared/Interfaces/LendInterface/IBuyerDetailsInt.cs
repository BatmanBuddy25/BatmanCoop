using BatmanCoopShared.Model.LendModel;
using BatmanCoopShared.Model.ManpowerModel;

namespace BatmanCoopShared.Interfaces.LendInterface
{
    public interface IBuyerDetailsInt
    {
        Task AddBuyerDetails(BuyerDetailsModel _obj);
        Task UpdateBuyerDetails(BuyerDetailsModel _obj);
        Task<List<BuyerDetailsModel>> GetMasterList();
        Task<int> Getheadcount();
    }
}
