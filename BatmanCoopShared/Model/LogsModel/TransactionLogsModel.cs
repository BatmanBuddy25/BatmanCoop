using BatmanCoopShared.Model.ManpowerModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BatmanCoopShared.Model.LendModel;

namespace BatmanCoopShared.Model.LogsModel
{
    public class TransactionLogsModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Trans_Code { get; set; } = string.Empty;
        public MemberM? MemM { get; set; }
        public int MemMId { get; set; }
        public BuyerModel? BuyM { get; set; }
        public int BuyMId { get; set; }
        public decimal Buy_Amount { get; set; } = decimal.Zero;
        public string Payment_Type { get; set; } = string.Empty;
        public DateTime Created_Date { get; set; } = DateTime.Now;
        public string Trans_Status { get; set; } = string.Empty;

    }
}
