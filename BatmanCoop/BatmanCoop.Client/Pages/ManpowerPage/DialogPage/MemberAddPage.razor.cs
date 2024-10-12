using BatmanCoopShared.Model.ManpowerModel;
using BatmanCoopShared.Model.MasterDataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.FluentUI.AspNetCore.Components;
using Microsoft.JSInterop;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;


namespace BatmanCoop.Client.Pages.ManpowerPage.DialogPage
{
    public partial class MemberAddPage : ComponentBase
    {
        // [Parameter]
        public MemberM Obj { get; set; } = new();
        public MemberM ObjUser { get; set; } = new();
        public MemberM ObjReferal { get; set; } = new();

        public CivilStatus SelectCivil { get; set; } = new();
        private List<MemberAttachM> AttachList { get; set; } = [];

        [CascadingParameter] public FluentDialog? Dialog { get; set; }
        FluentInputFile? attachments = default!;
        FluentTab? changedto;
        private FluentWizard MyWizard = default!;


        //int? progressPercent;
        private int WizardIndex = 0;
        string AttachCode = string.Empty;
        string? progressTitle;
        string? activeid = "tab-1";
        List<string> Files = new();

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
        bool isEntReferal = false;
        bool isViewFields = true;
        bool isPayType1 = true;
        bool isPayType2 = true;

        private string ImgBase64 = "";

        protected override async Task OnInitializedAsync()
        {
            ObjUser = _tokenHelpers.GetModel();
            await Task.Delay(1);
            ImgBase64 = "img/emptyimg.png";
            isPhaseone = false;
            isPhasetwo = true;
            isImgShow = false;
            isCaptureShow = true;
            isBtnBack = true;
            isBtnSave = true;

            Obj.ReferralId = "MN000001";
        }

        private async Task OnSaveData()
        {
            await OnGetmemberno();
            if (ObjReferal != null)
            {
                Obj.ReferralId = ObjReferal.MemberNo;
                Obj.ReferralName = $"{ObjReferal.LastName}, {ObjReferal.FirstName} {ObjReferal.MiddleName}";
            }
            else
            {
                Obj.ReferralId = ObjUser.MemberNo;
                Obj.ReferralName = $"{ObjUser.LastName}, {ObjUser.FirstName} {ObjUser.MiddleName}";
            }

            Obj.MemStatus = "Application";

            //TokenHelpers.ConvertStringsToUpperCase(Obj);
            await _memberService.InsertMember(Obj);

            foreach (var _item in AttachList)
            {
                _item.Member_No = ObjUser.MemberNo;
                await _attachService.InsertAttachment(_item);
            }
            await Dialog!.CloseAsync(Obj);
        }

        private async Task OnCloseDialog()
        {
            await Dialog!.CancelAsync();
        }
        private async Task OnNextTab()
        {
            isBtnBack = false;
            isBtnSave = false;
            isBtnNext = true;
            isBtnCancel = true;


            await MyWizard.GoToStepAsync(WizardIndex + 1);
        }
        private void OnBackTab()
        {
            isBtnBack = true;
            isBtnSave = true;
            isBtnNext = false;
            isBtnCancel = false;
            MyWizard.GoToStepAsync(WizardIndex - 1);
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
        private async Task OnGetattachcode()
        {
            await Task.Delay(1);
            string _returnString = string.Empty;
            int _headcount = await _attachService.Getheadcount() + 1;
            var _memNo = _headcount.ToString().PadLeft(4, '0');
            AttachCode = $"AC{_memNo}";
        }
        private async Task OnFileUploadedAsync(InputFileChangeEventArgs _file)
        {
            isPhaseone = false;
            isPhasetwo = true;
            ImgBase64 = "img/emptyimg.png";
            AttachList.Clear();
            await OnGetattachcode();

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

            _imgUrl = $"data:image/{_imgContent};base64,{Convert.ToBase64String(_imgBuffer)}";
            if (_file.File.Name is null)
            {
                ImgBase64 = "img/emptyimg.png";
                return;
            }
            else
            {
                using var _contents = new MultipartFormDataContent();
                var _fileContents = new ByteArrayContent(_imgBuffer);
                _fileContents.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(_imgContent);

                _attachImg.Add(content: _fileContents, name: "\"files\"", fileName: _imgFilename);

                MemberAttachM _obj = new()
                {
                    Img_Code = AttachCode,
                    Img_Filename = _imgFilename,
                    Img_URL = _imgUrl,
                    Img_Contenttype = _imgContent,
                    LastName = Obj.LastName,
                    Img_Data = _imgBuffer,
                    Img_Date = DateTime.Now,
                    Member_No = Obj.MemberNo
                };

                AttachList.Add(_obj);
                ImgBase64 = $"data:image/{_imgContent};base64,{Convert.ToBase64String(_imgBuffer)}";

                _contents.Dispose();
                _fileContents.Dispose();
            }
        }

        private async Task OnTakeImg()
        {
            isPhaseone = true; isPhasetwo = false; isImgShow = true; isCaptureShow = false;
            ImgBase64 = "img/emptyimg.png";
            await _jsrunTime.InvokeVoidAsync("startVideo", "videoFeed");
        }
        private async Task OnCloseImg()
        {
            isPhaseone = false; isPhasetwo = true; isImgShow = false; isCaptureShow = true;
            await _jsrunTime.InvokeVoidAsync("stopVideo", "videoFeed");
        }
        private async Task OnCaptureImg()
        {
            isPhaseone = false; isPhasetwo = true;
            AttachList.Clear();
            await OnGetattachcode();
            await _jsrunTime.InvokeAsync<String>("getFrame", "videoFeed", "currentFrame", DotNetObjectReference.Create(this));
            await OnCloseImg();
        }

        private void HandleOnTabChange(FluentTab tab)
        {
            changedto = tab;
        }

        [JSInvokable]
        public void ProcessImage(string imageString)
        {
            string _imgUrl;
            string _contents = "jpeg";
            byte[] imageData = Convert.FromBase64String(imageString.Split(',')[1]);
            using (var image = Image.Load(imageData))
            {
                image.Mutate(x => x.Flip(FlipMode.Horizontal)); //To match mirrored webcam image
                _imgUrl = image.ToBase64String(JpegFormat.Instance);
            }

            MemberAttachM _obj = new()
            {
                Img_Code = AttachCode,
                Img_Filename = $"{AttachCode}.jpeg",
                Img_URL = string.Empty,
                Img_Contenttype = _contents,
                LastName = Obj.LastName,
                Img_Data = imageData,
                Img_Date = DateTime.Now,
                Member_No = Obj.MemberNo
            };

            AttachList.Add(_obj);
            ImgBase64 = _imgUrl;
        }

        private async Task OnInquireref()
        {
            if(Obj.ReferralId == "MN000000")
            {
                ObjReferal.ReferralId = "MN000000";
                ObjReferal.ReferralName = "Coop, Admin";
                isEntReferal = true;
                isViewFields = false;
            }
            else
            {
                ObjReferal = await _memberService.GetReferalObj(Obj.ReferralId!);
                if (ObjReferal == null)
                {
                    _toastService.ShowError("No data found");
                    return;
                }

                isEntReferal = true;
                isViewFields = false;

                ObjReferal = await _memberService.GetReferalObj(Obj.ReferralId!);
            }
        }

        private async Task OnChangePayType()
        {
            await Task.Delay(1);
            if(Obj.PayTypeMId == 1)
            {

            }
            else if (Obj.PayTypeMId == 2)
            {
                isPayType1 = true;
                isPayType2 = false;
            }
            else if (Obj.PayTypeMId == 3)
            {

            }
        }

        private List<CivilStatus> CivilStatus_List = new()
        {
            { new CivilStatus { Id = 1, Description = "Single" } },
            { new CivilStatus { Id = 2, Description = "Married"} },
            { new CivilStatus { Id = 3, Description = "Separated" } },
            { new CivilStatus { Id = 4, Description = "Divorced" } },
            { new CivilStatus { Id = 5, Description = "Widowed" } },
            { new CivilStatus { Id = 6, Description = "Engaged" } }
        };

        private List<PaymentTypeM> PaymentType_List = new()
        {
            { new PaymentTypeM { Id = 1, Description = "Cash" } },
            { new PaymentTypeM { Id = 2, Description = "GCash / Maya"} },
            { new PaymentTypeM { Id = 3, Description = "Bank Transfer" } }
        };
    }
}
