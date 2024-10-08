using BatmanCoop.Client.Pages.ManpowerPage.DialogPage;
using BatmanCoopShared.Model.ManpowerModel;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace BatmanCoop.Client.Pages.ManpowerPage
{
    public partial class MemberListPage : ComponentBase
    {
        IQueryable<MemberM>? IList_Mem;
        public List<MemberM> Member_List = [];
        public MemberM Obj = new MemberM();
        private bool _trapFocus = true;
        private bool _modal = true;


        DataGridSelectMode Mode = DataGridSelectMode.Single;
        PaginationState pagination = new PaginationState { ItemsPerPage = 10 };
        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(1);
            Member_List = await _memberService.GetMasterList();
            IList_Mem = Member_List.AsQueryable();
        }

        private async Task OnAddMember()
        {
            var _dialog = await _dialogService.ShowDialogAsync<MemberAddPage>(null!, new DialogParameters()
            {
                Modal = true,
                Width = "1000px",
                Height = "auto",
                PreventDismissOnOverlayClick = true,
                TrapFocus = false
            });
            DialogResult? result = await _dialog.Result;

            if (result.Cancelled)
            {
                return;
            }

            if (result.Data is not null)
            {
                Member_List = await _memberService.GetMasterList();
                IList_Mem = Member_List.AsQueryable();
                _toastService.ShowSuccess("Added Successfully");
            }
        }

        private async Task OnAddPage()
        {
            await Task.Delay(1);
            _navigation.NavigateTo("/member-info");
        }

        private async Task OnSelectItem(MemberM _obj)
        {
            var _dialog = await _dialogService.ShowDialogAsync<MemberAddPage>(_obj, new DialogParameters()
            {
                Modal = true,
                Width = "1000px",
                Height = "auto",
                PreventDismissOnOverlayClick = true,
                TrapFocus = false,
                PrimaryActionEnabled = false,
                PrimaryAction = "",
                SecondaryAction = "",
                SecondaryActionEnabled = false

            });

            //DialogResult? result = await _dialog.Result;

            //if (result.Cancelled)
            //{
            //    return;
            //}
        }
    }
}
