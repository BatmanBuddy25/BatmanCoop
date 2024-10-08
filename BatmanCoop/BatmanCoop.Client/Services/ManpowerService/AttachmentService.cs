using BatmanCoopShared.Interfaces.ManpowerInterface;
using BatmanCoopShared.Model.ManpowerModel;
using System.Net.Http.Json;

namespace BatmanCoop.Client.Services.ManpowerService
{
    public class AttachmentService(HttpClient httpClient) : IAttachmentInt
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<string> InsertAttachment(MemberAttachM _obj)
        {
            var _response = await _httpClient.PostAsJsonAsync("api/AttachmentMem/Postattachment", _obj);
            var _returns = await _response.Content.ReadFromJsonAsync<string>();
            return _returns!;
        }
    }
}
