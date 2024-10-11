using BatmanCoopShared.Model.LendModel;
using BatmanCoopShared.Model.LogsModel;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace BatmanCoop.Client.Pages.TransactionPage
{
    public partial class TransactionLogsListPage : ComponentBase
    {
        IQueryable<TransactionLogsModel>? IList_TransLogs;
        public List<TransactionLogsModel> TransLogs_List = [];
        public TransactionLogsModel Obj = new TransactionLogsModel();

        PaginationState pagination = new PaginationState { ItemsPerPage = 10 };
        DataGridSelectMode Mode = DataGridSelectMode.Single;


        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(1);
            TransLogs_List = await _translogService.GetMasterList();
            IList_TransLogs = TransLogs_List.AsQueryable();
        }
    }
}
