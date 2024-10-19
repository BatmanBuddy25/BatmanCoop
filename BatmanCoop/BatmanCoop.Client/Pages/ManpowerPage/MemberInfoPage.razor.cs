using BatmanCoopShared.Model.LendModel;
using BatmanCoopShared.Model.ManpowerModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.FluentUI.AspNetCore.Components;

namespace BatmanCoop.Client.Pages.ManpowerPage
{
    public partial class MemberInfoPage : ComponentBase
    {
        public MemberM Obj { get; set; } = new();
        IQueryable<BuyerDetailsModel>? IList_BuyerMem;
        public List<BuyerDetailsModel> BuyerMem_List = [];
        public BuyerDetailsModel ObjBDM= new BuyerDetailsModel();

        PaginationState pagination = new PaginationState { ItemsPerPage = 10 };
        private string ImgProfile = "";
        private async Task OnSaveData()
        {
            await Task.Delay(1000);
            await _memberService.InsertMember(Obj);
        }


        private async Task OnFileUploadedAsync(InputFileChangeEventArgs _file)
        {
            await Task.Delay(1);
        }
        private  string ImgBorderStatus(int status)
        {
            return status switch
            {
                1 => "statusRegular",
                2 => "statusProbationary",
                3 => "statusCasual",
                4 => "statusFixedTerm",
                5 => "statusProjectBased",
                _ => "",
            };
        }
    }
}
