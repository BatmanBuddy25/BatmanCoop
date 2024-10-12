using BatmanCoopShared.Model.ManpowerModel;
using BatmanCoopShared.Model.MasterDataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.FluentUI.AspNetCore.Components;

namespace BatmanCoop.Client.Pages.ManpowerPage.DialogPage
{
    public partial class MemberEditPage : ComponentBase
    {
        [CascadingParameter] public FluentDialog? Dialog { get; set; }
        FluentInputFile? attachments = default!;
        FluentTab? changedto;
        private FluentWizard MyWizard = default!;
        private int WizardIndex = 0;
        // 
        bool isTakeimg = false;
        bool isUploadimg = false;
        bool isCloseimg = false;
        bool isImgShow = true;
        bool isCaptureShow = true;
        bool isPhaseone = true;
        bool isPhasetwo = true;
        bool isBtnSave = false;
        bool isBtnCancel = false;
        bool isBtnNext = false;
        bool isBtnBack = false;

        private string ImgBase64 = "";
        [Parameter] public MemberM Content { get; set; } = default!;
        public CivilStatus SelectCivil { get; set; } = new();
        public string Referal_Mem { get; set; } = string.Empty;
        private List<MemberM> ReferalList { get; set; } = [];
        IEnumerable<MemberM> SelectReferal = Array.Empty<MemberM>();

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(1);
            Referal_Mem = $"{Content.ReferralId} - {Content.ReferralName}";
            ReferalList = await _memberService.GetMasterList();
            //Content.ReferralName = SelectReferal.ReferralName;
        }
        
        private async Task OnUpdateObj()
        {
            await _memberService.UpdateMember(Content);
            await Dialog!.CloseAsync(Content);
        }
        private async Task OnFileUploadedAsync(InputFileChangeEventArgs _file)
        {
            await Task.Delay(1);
        }

        private async Task OnTakeImg()
        {
            await Task.Delay(1);
        }

        private async Task OnCloseImg()
        {
            await Task.Delay(1);
        }

        private async Task OnCaptureImg()
        {
            await Task.Delay(1);
        }

        private async Task OnBackTab()
        {
            await Task.Delay(1);
        }

        private async Task OnSaveData()
        {
            await Task.Delay(1);
        }
        private void OnCalculateAge()
        {
            DateTime _todayDate = DateTime.Today;
            int _age = _todayDate.Year - Content.BirthDate!.Value.Year;

            if (Content.BirthDate > _todayDate.AddYears(-_age))
                _age--;

            Content.Age = _age;
        }

        private async Task OnNextTab()
        {
            await Task.Delay(1);
        }

        private void OnSearch(OptionsSearchEventArgs<MemberM> e)
        {
            e.Items = ReferalList.Where(i => i.LastName.StartsWith(e.Text, StringComparison.OrdinalIgnoreCase) || i.FirstName.StartsWith(e.Text, StringComparison.OrdinalIgnoreCase))
                                 .OrderBy(i => i.LastName);
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
