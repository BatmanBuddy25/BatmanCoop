using BatmanCoopShared.Interfaces.LendInterface;
using BatmanCoopShared.Model.LendModel;
using BatmanCoopShared.Model.ManpowerModel;
using System.Net.Http.Json;

namespace BatmanCoop.Client.Services.LendService
{
    public class BuyerService(HttpClient httpClient) : IBuyerInt
    {
        private readonly HttpClient _httpClient = httpClient;
        public async Task AddBuyer(BuyerModel _obj)
        {
            await _httpClient.PostAsJsonAsync("api/Buyer/Postobj", _obj);
        }

        public async Task<List<BuyerModel>> GetMasterList()
        {
            var _response = await _httpClient.GetAsync("api/Buyer/Getmasterlist");
            var _masterlist = await _response.Content.ReadFromJsonAsync<List<BuyerModel>>();
            return _masterlist!;
        }

        public async Task<int> Getheadcount()
        {
            var _response = await _httpClient.GetAsync("api/Buyer/Getheadcount");
            var _headcount = await _response.Content.ReadFromJsonAsync<int>();
            return _headcount!;
        }

        public async Task BuySharecap(BuyerModel _obj)
        {
            await _httpClient.PutAsJsonAsync("api/Buyer/Buysharecap", _obj);
        }
    }
}
