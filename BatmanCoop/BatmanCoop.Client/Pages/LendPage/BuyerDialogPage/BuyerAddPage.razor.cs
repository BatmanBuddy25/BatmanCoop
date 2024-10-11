using BatmanCoopShared.Model.LendModel;
using BatmanCoopShared.Model.ManpowerModel;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace BatmanCoop.Client.Pages.LendPage.BuyerDialogPage
{
    public partial class BuyerAddPage : ComponentBase
    {
        public BuyerModel Obj { get; set; } = new();



        //public List<MemberM> MemberList { get; set; } = new();
        //IEnumerable<MemberM> SelectMember = Array.Empty<MemberM>();



        [CascadingParameter] public FluentDialog? Dialog { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(1);

            //var _masterList = await _memberService.GetMasterList();
            //MemberList = _masterList.ToList();

            await OnGetmemberno();
        }

        //private void OnSearch(OptionsSearchEventArgs<MemberM> e)
        //{
        //    e.Items = MemberList.Where(i => i.LastName.StartsWith(e.Text, StringComparison.OrdinalIgnoreCase) || i.FirstName.StartsWith(e.Text, StringComparison.OrdinalIgnoreCase))
        //                         .OrderBy(i => i.LastName);
        //}

        private async Task OnSaveData()
        {

            Obj.Share_Status = "Open";
            await _buyerService.AddBuyer(Obj);
            await Dialog!.CloseAsync(Obj);
        }
        private async Task OnGetmemberno()
        {
            await Task.Delay(1);
            string _returnString = string.Empty;
            int _headcount = await _buyerService.Getheadcount() + 1;
            var _memNo = _headcount.ToString().PadLeft(4, '0');
            Obj.Buy_Code = $"SN{_memNo}";
        }
        private async Task OnCloseDialog()
        {
            await Dialog!.CancelAsync();
        }
    }
}
