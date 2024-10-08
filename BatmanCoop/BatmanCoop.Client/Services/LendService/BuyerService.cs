using BatmanCoopShared.Interfaces.LendInterface;
using BatmanCoopShared.Model.LendModel;

namespace BatmanCoop.Client.Services.LendService
{
    public class BuyerService(HttpClient httpClient) : IBuyerInt
    {
        private readonly HttpClient _httpClient = httpClient;
        public Task AddBuyer(BuyerModel _obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<BuyerModel>> GetMasterList()
        {
            throw new NotImplementedException();
        }
    }
}
