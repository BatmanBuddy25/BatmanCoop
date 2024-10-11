using BatmanCoopShared.Interfaces.LendInterface;
using BatmanCoopShared.Interfaces.TransactionInterface;
using BatmanCoopShared.Model.LendModel;
using BatmanCoopShared.Model.LogsModel;
using System.Net.Http.Json;

namespace BatmanCoop.Client.Services.TransactionService
{
    public class TransactionLogsService(HttpClient httpClient) : ITransactionInt
    {
        private readonly HttpClient _httpClient = httpClient;
        public async Task AddTransactionLogs(TransactionLogsModel _obj)
        {
            await _httpClient.PostAsJsonAsync("api/TransactionLogs/Postobj", _obj);
        }

        public async Task<int> Getheadcount()
        {
            var _response = await _httpClient.GetAsync("api/TransactionLogs/Getheadcount");
            var _headcount = await _response.Content.ReadFromJsonAsync<int>();
            return _headcount!;
        }

        public async Task<List<TransactionLogsModel>> GetMasterList()
        {
            var _response = await _httpClient.GetAsync("api/TransactionLogs/Getmasterlist");
            var _masterlist = await _response.Content.ReadFromJsonAsync<List<TransactionLogsModel>>();
            return _masterlist!;
        }
    }
}
