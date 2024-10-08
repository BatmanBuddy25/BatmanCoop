using BatmanCoopShared.Model.ManpowerModel;
using BatmanCoopShared.Model.MasterDataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace BatmanCoop.Client.Pages.ManpowerPage.DialogPage
{
    public partial class MemberEditPage : ComponentBase
    {
        [CascadingParameter] public FluentDialog? Dialog { get; set; }

        // 
        [Parameter] public MemberM Content { get; set; } = default!;

        public CivilStatus SelectCivil { get; set; } = new();
        public string Referal_Mem { get; set; } = string.Empty;

        private List<MemberM> ReferalList { get; set; } = [];
        public MemberM SelectReferal { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(1);
            Referal_Mem = $"{Content.ReferralId} - {Content.ReferralName}";
        }
        
        private async Task OnUpdateObj()
        {
            await _memberService.UpdateMember(Content);
            await Dialog!.CloseAsync(Content);
        }

        private async Task OnCloseDialog()
        {
            await Dialog!.CancelAsync();
        }

        private List<CivilStatus> CivilStatus_List = new()
        {
            { new CivilStatus { Id = 1, Description = "Single" } },
            { new CivilStatus { Id = 2, Description = "Married"} },
            { new CivilStatus { Id = 3, Description = "Separated" } },
            { new CivilStatus { Id = 4, Description = "Divorced" } },
            { new CivilStatus { Id = 5, Description = "Widowed" } },
            { new CivilStatus { Id = 6, Description = "Six" } },
            { new CivilStatus { Id = 7, Description = "Engaged" } }
        };
    }
}
