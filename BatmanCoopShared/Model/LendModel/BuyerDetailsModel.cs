using BatmanCoopShared.Model.ManpowerModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BatmanCoopShared.Model.LendModel
{
    public class BuyerDetailsModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int Buy_Count { get; set; }
        public MemberM? MemM { get; set; }
        public int MemMId { get; set; }
        public decimal Share_Capital { get; set; }
        public int Share_Points { get; set; }
        public decimal? Points_Amount { get; set; }
        public DateTime Created_Date { get; set; } = DateTime.Now;
        public DateTime? Approve_Status { get; set; }
        public string Reference_Code { get; set; } = string.Empty;
        public string Buy_Status { get; set; } = string.Empty;
        
    }
}
