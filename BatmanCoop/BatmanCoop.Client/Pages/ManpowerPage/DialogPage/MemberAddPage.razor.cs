using BatmanCoopShared.Model.ManpowerModel;
using BatmanCoopShared.Model.MasterDataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.FluentUI.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BatmanCoop.Client.Pages.ManpowerPage.DialogPage
{
    public partial class MemberAddPage : ComponentBase
    {
        // [Parameter]
        public MemberM Obj { get; set; } = new();

        public CivilStatus SelectCivil { get; set; } = new();
        public MemberM SelectReferal { get; set; } = new();
        private List<MemberM> ReferalList { get; set; } = [];

        [CascadingParameter] public FluentDialog? Dialog { get; set; }
        FluentInputFile? attachments = default!;
        FluentTab? changedto;
        //int? progressPercent;
        string? progressTitle;
        string? activeid = "tab-1";
        List<string> Files = new();

        bool isTakeimg = false;
        bool isUploadimg = false;
        bool isCloseimg = false;

        bool isPhaseone = true;
        bool isPhasetwo = true;

        private string ImgBase64 = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(1);
            ImgBase64 = "img/emptyimg.png";
            //isUploadimg = false;
            //isTakeimg = false;
            //isCloseimg = true;
            isPhaseone = false;
            isPhasetwo = true;

            ReferalList = await _memberService.GetMasterList();


        }

        private async Task OnSaveData()
        {
            if (SelectReferal != null)
            {
                Obj.ReferralId = SelectReferal.MemberNo;
                Obj.ReferralName = $"{SelectReferal.LastName}, {SelectReferal.FirstName} {SelectReferal.MiddleName}";
            }
            else
            {
                Obj.ReferralId = "SelectReferal.MemberNo";
                Obj.ReferralName = "Hello Coop";
            }

            await OnGetmemberno();
            Obj.MemStatus = "Application";
            await _memberService.InsertMember(Obj);
            await Dialog!.CloseAsync(Obj);
        }

        private async Task OnCloseDialog()
        {
            await Dialog!.CancelAsync();
        }

        private void OnCalculateAge()
        {
            DateTime _todayDate = DateTime.Today;
            int _age = _todayDate.Year - Obj.BirthDate!.Value.Year;

            if (Obj.BirthDate > _todayDate.AddYears(-_age))
                _age--;

            Obj.Age = _age;
        }

        private async Task OnGetmemberno()
        {
            await Task.Delay(1);
            string _returnString = string.Empty;
            int _headcount = await _memberService.Getheadcount() + 1;
            var _memNo = _headcount.ToString().PadLeft(6, '0');
            Obj.MemberNo = $"MN{_memNo}";
        }

        private async Task OnFileUploadedAsync(InputFileChangeEventArgs _file)
        {
            isPhaseone = false;
            isPhasetwo = true;

            long _imgsize = long.MaxValue;
            var _browsFile = _file.File;
            var _imgFilename = _file.File.Name;
            var _imgContent = _file.File.ContentType;
            byte[] _imgBuffer;
            string _imgUrl;
            MultipartFormDataContent _attachImg = [];

            using (var _stream = _browsFile.OpenReadStream(_imgsize))
            using (var _memoryStream = new MemoryStream())
            {
                await _stream.CopyToAsync(_memoryStream);
                _imgBuffer = _memoryStream.ToArray();
            }

            //_imgUrl = $"data:{_imgContent};base64,{Convert.ToBase64String(_imgBuffer)}";
            ImgBase64 = $"data:image/{_imgContent};base64,{Convert.ToBase64String(_imgBuffer)}";

        }

        private async Task OnTakeImg()
        {
            isPhaseone = true; isPhasetwo = false;
            await _jsrunTime.InvokeVoidAsync("startVideo", "videoFeed");
        }
        private async Task OnCloseImg()
        {
            isPhaseone = false; isPhasetwo = true;
            await _jsrunTime.InvokeVoidAsync("startVideo", "videoFeed");
        }
        private async Task OnCaptureImg()
        {
            isPhaseone = false; isPhasetwo = true;

            await _jsrunTime.InvokeAsync<string>("getFrame", "videoFeed", "currentFrame", DotNetObjectReference.Create(this));
            await OnCloseImg();
        }

        private void HandleOnTabChange(FluentTab tab)
        {
            changedto = tab;
        }

        [JSInvokable]
        public void ProcessImage(string imageString)
        {
            byte[] imageData = Convert.FromBase64String(imageString.Split(',')[1]);
            ImgBase64 = $"data:image/png;base64,{Convert.ToBase64String(imageData)}";
            //using (var image = Image.Load(imageData))
            //{
            //    image.Mutate(x => x
            //        .Flip(FlipMode.Horizontal) //To match mirrored webcam image
            //    );
            //    ImgBase64 = image.ToBase64String(JpegFormat.Instance);
            //}
        }
        private void OnCompleted(IEnumerable<FluentInputFileEventArgs> files)
        {
            //progressPercent = attachments!.ProgressPercent;
            //progressTitle = attachments!.ProgressTitle;

            //// For the demo, delete these files.
            //foreach (var file in Files)
            //{
            //    File.Delete(file);
            //}
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
