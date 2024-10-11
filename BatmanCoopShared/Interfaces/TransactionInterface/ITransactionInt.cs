using BatmanCoopShared.Model.LendModel;
using BatmanCoopShared.Model.LogsModel;

namespace BatmanCoopShared.Interfaces.TransactionInterface
{
    public interface ITransactionInt
    {
        Task AddTransactionLogs(TransactionLogsModel _obj);
        Task<List<TransactionLogsModel>> GetMasterList();
        Task<int> Getheadcount();
    }
}
