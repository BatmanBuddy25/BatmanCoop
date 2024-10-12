using BatmanCoopShared.Interfaces.LendInterface;
using BatmanCoopShared.Model.LendModel;
using System.Net.Http.Json;

namespace BatmanCoop.Client.Services.LendService
{
    public class BuyerDetailsService(HttpClient httpClient) : IBuyerDetailsInt
    {
        private readonly HttpClient _httpClient = httpClient;
        public async Task AddBuyerDetails(BuyerDetailsModel _obj)
        {
            await _httpClient.PostAsJsonAsync("api/BuyerDetails/Postobj", _obj);
        }

        public async Task<List<BuyerDetailsModel>> GetMasterList()
        {
            var _response = await _httpClient.GetAsync("api/BuyerDetails/Getmasterlist");
            var _masterlist = await _response.Content.ReadFromJsonAsync<List<BuyerDetailsModel>>();
            return _masterlist!;
        }

        public async Task<int> Getheadcount()
        {
            var _response = await _httpClient.GetAsync("api/BuyerDetails/Getheadcount");
            var _headcount = await _response.Content.ReadFromJsonAsync<int>();
            return _headcount!;
        }

        public Task UpdateBuyerDetails(BuyerDetailsModel _obj)
        {
            throw new NotImplementedException();
        }
    }
}
