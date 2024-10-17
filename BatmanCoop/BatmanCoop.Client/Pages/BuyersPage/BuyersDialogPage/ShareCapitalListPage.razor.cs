using BatmanCoop.Client.Pages.ManpowerPage.DialogPage;
using BatmanCoopShared.Model.LendModel;
using BatmanCoopShared.Model.LogsModel;
using BatmanCoopShared.Model.ManpowerModel;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace BatmanCoop.Client.Pages.BuyersPage.BuyersDialogPage
{
    public partial class ShareCapitalListPage : ComponentBase
    {

        [CascadingParameter] public FluentDialog? Dialog { get; set; }

        IQueryable<BuyerModel>? IList_Buyer;
        public List<BuyerModel> Buyer_List = [];
        public BuyerModel Obj = new BuyerModel();
        public BuyerModel ObjSelected = new BuyerModel();
        public TransactionLogsModel ObjTrans = new TransactionLogsModel();
        public BuyerDetailsModel ObjDetails = new BuyerDetailsModel();
                
        private bool isEntryShare;


        PaginationState pagination = new PaginationState { ItemsPerPage = 10 };
        DataGridSelectMode Mode = DataGridSelectMode.Single;

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(1);
            isEntryShare = true;

            Buyer_List = await _buyerService.GetMasterList();
            IList_Buyer = Buyer_List.AsQueryable();
        }

        private async Task OnSaveData()
        {
            await Task.Delay(1);
            if(Obj.Share_Capital > ObjDetails.Share_Capital)
            {
                _toastService.ShowError("Sorry, the capital is lacking ");
                return;
            }

            await OnBuyerDetails(ObjSelected);
            await OnTransaction(ObjSelected);

            await OnCloseDialog();
        }

        private async Task OnSelectItem(BuyerModel _obj)
        {
            await Task.Delay(1);
            isEntryShare = false;
            ObjSelected = _obj;
        }

        private async Task OnBuyerDetails(BuyerModel _obj)
        {
            var _listMem = await _memberService.GetMasterList();
            var _objMem = _listMem.FirstOrDefault();

            ObjDetails.Buy_Count += 1;
            ObjDetails.MemMId = _objMem!.Id;
            ObjDetails.BuyMId = _obj.Id;
            var _points = ObjDetails.Share_Capital / 1000;
            ObjDetails.Share_Points = Convert.ToInt32(_points);
            ObjDetails.Buy_Status = "Apply";
            await _buyerDetailsService.AddBuyerDetails(ObjDetails);
        }

        private async Task OnTransaction(BuyerModel _obj)
        {
            await OnGetmasterno();
            ObjTrans.MemMId = 10;
            ObjTrans.BuyMId = _obj.Id;
            ObjTrans.Buy_Amount = ObjDetails.Share_Capital;
            ObjTrans.Payment_Type = "GCash";
            ObjTrans.Trans_Status = "Apply";

            await _translogService.AddTransactionLogs(ObjTrans);
        }

        private async Task OnGetmasterno()
        {            
            string _returnString = string.Empty;
            int _headcount = await _translogService.Getheadcount() + 1;
            var _memNo = _headcount.ToString().PadLeft(2, '0');
            ObjTrans.Trans_Code = $"TN{_memNo}";
        }

        private async Task OnCloseDialog()
        {
            await Dialog!.CancelAsync();
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
