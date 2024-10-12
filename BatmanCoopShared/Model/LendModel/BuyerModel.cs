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
        public string Buy_Code { get; set; } = string.Empty;
        public int Share_Points { get; set; }
        public decimal Share_Capital { get; set; }
        public DateTime Created_Date { get; set; } = DateTime.Now;
        public DateTime? Valid_Date {  get; set; }
        public string Share_Status { get; set; } = string.Empty;
    }
}
