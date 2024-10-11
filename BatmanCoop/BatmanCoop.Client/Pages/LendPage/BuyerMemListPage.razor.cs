using BatmanCoop.Client.Pages.LendPage.BuyerDialogPage;
using BatmanCoop.Client.Pages.ManpowerPage.DialogPage;
using BatmanCoopShared.Model.LendModel;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace BatmanCoop.Client.Pages.LendPage
{
    public partial class BuyerMemListPage : ComponentBase
    {
        IQueryable<BuyerDetailsModel>? IList_BuyerMem;
        public List<BuyerDetailsModel> BuyerMem_List = [];
        public BuyerDetailsModel Obj = new BuyerDetailsModel();


        PaginationState pagination = new PaginationState { ItemsPerPage = 10 };
        DataGridSelectMode Mode = DataGridSelectMode.Single;

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(1);
            BuyerMem_List = await _buyerDetailsService.GetMasterList();
            IList_BuyerMem = BuyerMem_List.AsQueryable();
        }

        private async Task OnSaveData()
        {
            await Task.Delay(1);
        }

        private async Task OnSelectItem(BuyerDetailsModel _obj)
        {
            await Task.Delay(1);
            var _dialog = await _dialogService.ShowDialogAsync<BuyerApprovePage>(_obj, new DialogParameters()
            {
                Modal = true,
                Width = "500px",
                Height = "auto",
                PreventDismissOnOverlayClick = true,
                TrapFocus = false,
                PrimaryActionEnabled = false,
                PrimaryAction = "",
                SecondaryAction = "",
                SecondaryActionEnabled = false

            });
        }
    }
}
