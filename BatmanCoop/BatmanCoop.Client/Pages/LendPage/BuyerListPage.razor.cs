using BatmanCoop.Client.Pages.LendPage.BuyerDialogPage;
using BatmanCoopShared.Model.LendModel;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace BatmanCoop.Client.Pages.LendPage
{
    public partial class BuyerListPage : ComponentBase
    {

        IQueryable<BuyerModel>? IList_Buyer;
        public List<BuyerModel> Buyer_List = [];
        public BuyerModel Obj = new BuyerModel();

        private bool _trapFocus = true;
        private bool _modal = true;
        int TotalPoints = 0;
        decimal TotalCapital = 0;

        PaginationState pagination = new PaginationState { ItemsPerPage = 10 };
        DataGridSelectMode Mode = DataGridSelectMode.Single;

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(1);
            Buyer_List = await _buyerService.GetMasterList();
            IList_Buyer = Buyer_List.AsQueryable();
            
            TotalPoints = GetTotalPoints();
            TotalCapital = GetTotalCapital();
            //await OpenPanelRightAsync();
        }

        private async Task OnAddBuyer()
        {
            var _dialog = await _dialogService.ShowDialogAsync<BuyerAddPage>(null!, new DialogParameters()
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
                Buyer_List = await _buyerService.GetMasterList();
                IList_Buyer = Buyer_List.AsQueryable();
                _toastService.ShowSuccess("Added Successfully");
            }
        }

        private decimal GetTotalCapital() 
        {
            decimal _returnCapital = 0;
            foreach(var _item in Buyer_List)
            {
                _returnCapital += _item.Share_Capital;
            }

            return _returnCapital;
        }

        private int GetTotalPoints()
        {
            int _returnPoints = 0;
            foreach (var _item in Buyer_List)
            {
                _returnPoints += _item.Share_Points;
            }

            return _returnPoints;
        }
    }
}
