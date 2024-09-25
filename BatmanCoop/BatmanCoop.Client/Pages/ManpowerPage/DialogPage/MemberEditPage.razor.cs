using BatmanCoopShared.Model.ManpowerModel;
using Microsoft.AspNetCore.Components;

namespace BatmanCoop.Client.Pages.ManpowerPage.DialogPage
{
    public partial class MemberEditPage : ComponentBase
    {
        // 
        [Parameter] public MemberM Obj { get; set; } = default!;
    }
}
