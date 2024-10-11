using BatmanCoop.DatabaseContext;
using BatmanCoopShared.Interfaces.TransactionInterface;
using BatmanCoopShared.Model.LogsModel;
using Microsoft.EntityFrameworkCore;

namespace BatmanCoop.Repository.TransactionRepository
{
    public class TransactionLogsRepo(DataBaseConfiguration context) : ITransactionInt
    {
        private readonly DataBaseConfiguration _context = context;
        public async Task AddTransactionLogs(TransactionLogsModel _obj)
        {
            _context.TransLogsTable.Add(_obj);
            await _context.SaveChangesAsync();
        }


        public async Task<int> Getheadcount() => await _context.TransLogsTable.CountAsync();
        public async Task<List<TransactionLogsModel>> GetMasterList() => await _context.TransLogsTable.Include(a => a.MemM).Include(b => b.BuyM).ToListAsync();

    }
}
