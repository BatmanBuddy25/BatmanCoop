using BatmanCoopShared.Interfaces.ManpowerInterface;
using BatmanCoopShared.Model.ManpowerModel;
using Microsoft.FluentUI.AspNetCore.Components;
using System.Net.Http.Json;

namespace BatmanCoop.Client.Services.ManpowerService
{
    public class MemberService(HttpClient httpClient) : IMemberInt
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<int> Getheadcount()
        {
            var _response = await _httpClient.GetAsync("api/MemberCs/Getheadcount");
            var _headcount = await _response.Content.ReadFromJsonAsync<int>();
            return _headcount!;
        }

        public async Task<List<MemberM>> GetMasterList()
        {
            var _response = await _httpClient.GetAsync("api/MemberCs/Getmasterlist");
            var _masterlist = await _response.Content.ReadFromJsonAsync<List<MemberM>>();
            return _masterlist!;
        }

        public async Task<List<MemberM>> GetSortreferal(string refCode)
        {
            var _response = await _httpClient.GetAsync($"api/MemberCs/Getsortreferal?referalcode={refCode}");
            var _masterlist = await _response.Content.ReadFromJsonAsync<List<MemberM>>();
            return _masterlist!;
        }

        public async Task<MemberM> Getspecmember(int memberId)
        {
            var _response = await _httpClient.GetAsync($"api/MemberCs/Getspecmember?referalcode={memberId}");
            var _masterlist = await _response.Content.ReadFromJsonAsync<MemberM>();
            return _masterlist!;
        }

        public async Task InsertMember(MemberM _obj)
        {
            await _httpClient.PostAsJsonAsync("api/MemberCs/Postobj", _obj);
        }

        public async Task UpdateMember(MemberM _obj)
        {
            await _httpClient.PutAsJsonAsync("api/MemberCs/Putobj", _obj);
        }

        public async Task<MemberM> GetReferalObj(string _referalId)
        {
            var _response = await _httpClient.GetAsync($"api/MemberCs/Getreferalmember?referalid={_referalId}");
            var _masterlist = await _response.Content.ReadFromJsonAsync<MemberM>();
            return _masterlist!;
        }

        public async Task<int> Getexistreferal(string _referalId)
        {
            var _response = await _httpClient.GetAsync($"api/MemberCs/Getexistreferal?referalid={_referalId}");
            var _headcount = await _response.Content.ReadFromJsonAsync<int>();
            return _headcount!;
        }
    }
}
