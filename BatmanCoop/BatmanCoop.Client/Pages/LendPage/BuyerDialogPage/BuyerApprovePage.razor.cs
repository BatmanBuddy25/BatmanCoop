using BatmanCoop.Client.Helper;
using BatmanCoopShared.Model.LendModel;
using BatmanCoopShared.Model.LogsModel;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace BatmanCoop.Client.Pages.LendPage.BuyerDialogPage
{
    public partial class BuyerApprovePage : ComponentBase
    {
        [CascadingParameter] public FluentDialog? Dialog { get; set; }
        [Parameter] public BuyerDetailsModel Content { get; set; } = default!;


        public BuyerModel ObjBuyer = new BuyerModel();
        public TransactionLogsModel ObjTrans = new TransactionLogsModel();
        private async Task OnSaveData()
        {
            await Task.Delay(1);

            Content.Buy_Status = "Approve";
            await _buyerDetailsService.UpdateBuyerDetails(Content);

            BuyerModel _objBuyer = new()
            {
                Buy_Code = Content.BuyM!.Buy_Code,
                Share_Capital = Content.BuyM.Share_Capital - Content.Share_Capital,
                Created_Date = Content.BuyM.Created_Date,
                Valid_Date = Content.BuyM.Valid_Date,
                Share_Status = Content.BuyM.Share_Status
            };

            await _buyerService.BuySharecap(_objBuyer);
            await OnTransaction(Content);
             await OnCloseDialog();
        }
        private async Task OnTransaction(BuyerDetailsModel _obj)
        {
            await Task.Delay(1);
            string _transCode = await _tokenHelpers.OnGetmasterno();
            ObjTrans.Trans_Code = _transCode;
            ObjTrans.MemMId = 10;
            ObjTrans.BuyMId = _obj.Id;
            ObjTrans.Buy_Amount = Content.Share_Capital;
            ObjTrans.Payment_Type = "GCash";
            ObjTrans.Trans_Status = "Approve";
            await _translogService.AddTransactionLogs(ObjTrans);


        }
        private async Task OnCloseDialog()
        {
            await Dialog!.CancelAsync();
        }
    }
}
