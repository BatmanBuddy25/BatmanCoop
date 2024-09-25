using BatmanCoopShared.Model.ManpowerModel;
using BatmanCoopShared.Model.MasterDataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace BatmanCoop.Client.Pages.ManpowerPage.DialogPage
{
    public partial class MemberAddPage : ComponentBase
    {
        // [Parameter]
        public MemberM Obj { get; set; } = new();

        public CivilStatus SelectCivil { get; set; } = new();
        public MemberM SelectReferal { get; set; } = new();
        private List<MemberM> ReferalList { get; set; } = [];

        [CascadingParameter]
        public FluentDialog? Dialog { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(1);

            ReferalList = await _memberService.GetMasterList();
        }

        private async Task OnSaveData()
        {
            if (!string.IsNullOrEmpty(SelectReferal.MemberNo) || !string.IsNullOrWhiteSpace(SelectReferal.MemberNo))
            {
                Obj.ReferralId = SelectReferal.MemberNo;
                Obj.ReferralName = $"{SelectReferal.LastName}, {SelectReferal.FirstName} {SelectReferal.MiddleName}";
            }
            //else
            //{
            //    Obj.ReferralId = SelectReferal.MemberNo;
            //    Obj.ReferralName = $"{SelectReferal.LastName}, {SelectReferal.FirstName} {SelectReferal.MiddleName}";
            //}

            Obj.MemberNo = await OnGetmemberno();
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


        private async Task<string> OnGetmemberno()
        {
            await Task.Delay(1);
            string _returnString = string.Empty;
            int _headcount = await _memberService.Getheadcount();
            var _getLength = _headcount.ToString().Length;
            string _templateNo = $"MN000";

            if (_headcount == 0)
            {
                _returnString = "MN0000000";
                return _returnString;
            }

            else if (_headcount == 1)
            {
                _returnString = $"{_templateNo}000{_headcount}";
                return _returnString;
            }
            else
            {
                switch (_getLength)
                {
                    default:
                        var _defaulCal = _headcount + 1;
                        _returnString = $"{_templateNo}{_defaulCal}";
                        return _returnString;

                    case 1:
                        var _caseOne = _headcount + 1;
                        _returnString = $"{_templateNo}000{_caseOne}";
                        return _returnString;
                    case 2:
                        var _caseTwo = _headcount + 1;
                        _returnString = $"{_templateNo}00{_caseTwo}";
                        return _returnString;
                    case 3:
                        var _caseThree = _headcount + 1;
                        _returnString = $"{_templateNo}0{_caseThree}";
                        return _returnString;
                }
            }
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
