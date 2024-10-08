using BatmanCoopShared.Model.LendModel;
using BatmanCoopShared.Model.ManpowerModel;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace BatmanCoop.Client.Pages.LendPage.BuyerDialogPage
{
    public partial class BuyerAddPage : ComponentBase
    {
        public BuyerModel Obj { get; set; } = new();



        public List<MemberM> MemberList { get; set; } = new();
        IEnumerable<MemberM> SelectMember = Array.Empty<MemberM>();



        [CascadingParameter] public FluentDialog? Dialog { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(1);

            var _masterList = await _memberService.GetMasterList();
            MemberList = _masterList.ToList();
        }

        private void OnSearch(OptionsSearchEventArgs<MemberM> e)
        {
            e.Items = MemberList.Where(i => i.LastName.StartsWith(e.Text, StringComparison.OrdinalIgnoreCase) ||
                                             i.FirstName.StartsWith(e.Text, StringComparison.OrdinalIgnoreCase))
                                 .OrderBy(i => i.LastName);
        }

        private async Task OnSaveData()
        {
            await Task.Delay(1);
        }

        private async Task OnCloseDialog()
        {
            await Task.Delay(1);
        }
    }
}
