using BatmanCoopShared.Interfaces.AccountInterface;
using BatmanCoopShared.Interfaces.LendInterface;
using BatmanCoopShared.Model.AccountModel;
using BatmanCoopShared.Model.LendModel;
using System.Net.Http.Json;

namespace BatmanCoop.Client.Services.AccountService
{
    public class UserAccountService(HttpClient httpClient) : IUserAccountInt
    {
        private readonly HttpClient _httpClient = httpClient;
        public async Task AddAccount(UserAccountM _obj)
        {
            await _httpClient.PostAsJsonAsync("api/UserAccounts/Postobj", _obj);
        }

        public async Task<int> Getheadcount()
        {
            var _response = await _httpClient.GetAsync("api/UserAccounts/Getheadcount");
            var _headcount = await _response.Content.ReadFromJsonAsync<int>();
            return _headcount!;
        }

        public async Task<List<UserAccountM>> GetMasterList()
        {
            var _response = await _httpClient.GetAsync("api/UserAccounts/Getmasterlist");
            var _masterlist = await _response.Content.ReadFromJsonAsync<List<UserAccountM>>();
            return _masterlist!;
        }

        public async Task UpdateAccount(UserAccountM _obj)
        {
            await _httpClient.PutAsJsonAsync("api/UserAccounts/Putuseraccount", _obj);
        }
    }
}
