using BatmanCoop.Client.Pages.BuyersPage.BuyersDialogPage;
using BatmanCoop.Client.Pages.LendPage.BuyerDialogPage;
using BatmanCoop.Client.Pages.ManpowerPage.DialogPage;
using BatmanCoopShared.Model.LendModel;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace BatmanCoop.Client.Pages.BuyersPage
{
    public partial class BuyersInfoPage : ComponentBase
    {
        IQueryable<BuyerDetailsModel>? IList_BuyerMem;
        public List<BuyerDetailsModel> BuyerMem_List = [];
        public BuyerDetailsModel Obj = new BuyerDetailsModel();


        PaginationState pagination = new PaginationState { ItemsPerPage = 10 };
        DataGridSelectMode Mode = DataGridSelectMode.Single;

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(1);
            BuyerMem_List.Clear();
            BuyerMem_List = await _buyerDetailsService.GetMasterList();
            IList_BuyerMem = BuyerMem_List.AsQueryable();
        }

        private async Task OnAddBuyerShare()
        {
            var _dialog = await _dialogService.ShowDialogAsync<ShareCapitalListPage>(null!, new DialogParameters()
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
                BuyerMem_List = await _buyerDetailsService.GetMasterList();
                IList_BuyerMem = BuyerMem_List.AsQueryable();
                _toastService.ShowSuccess("Added Successfully");
            }
        }

        private async Task OnNewMember()
        {
            var _dialog = await _dialogService.ShowDialogAsync<MemberAddPage>(null!, new DialogParameters()
            {
                Modal = true,
                Width = "1000px",
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
                BuyerMem_List = await _buyerDetailsService.GetMasterList();
                IList_BuyerMem = BuyerMem_List.AsQueryable();
                _toastService.ShowSuccess("Added Successfully");
            }
        }
    }
}
