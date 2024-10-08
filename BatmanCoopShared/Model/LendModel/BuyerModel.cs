using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BatmanCoopShared.Model.ManpowerModel;

namespace BatmanCoopShared.Model.LendModel
{
    public class BuyerModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public MemberM? MemM { get; set; }
        public int MemMId { get; set; }
        public decimal Share_Capital { get; set; }
        public int Share_Points { get; set; }
        public decimal Points_Amount { get; set; }
        public DateTime Created_Date { get; set; } = DateTime.Now;
    }
}
