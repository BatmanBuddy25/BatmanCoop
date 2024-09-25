using BatmanCoopShared.Model.ManpowerModel;
using Microsoft.AspNetCore.Components;

namespace BatmanCoop.Client.Pages.ManpowerPage
{
    public partial class MemberInfoPage : ComponentBase
    {
        public MemberM Obj { get; set; } = new();

        private async Task OnSaveData()
        {
            await Task.Delay(1000);
            await _memberService.InsertMember(Obj);
        }
    }

    
}
