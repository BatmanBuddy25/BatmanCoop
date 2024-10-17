using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BatmanCoopShared.Model.ManpowerModel;

namespace BatmanCoopShared.Model.AccountModel
{
    public class UserAccountM
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public MemberM? MemM { get; set; }
        public int MemMId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Account_Role { get; set; } = string.Empty;
        public string Def_Pass { get; set; } = "p@ssw0rd";
        public bool Acc_Status { get; set; }
        public string Reg_Status { get; set; } = string.Empty;        
        public DateTime Date_Create { get; set; } = DateTime.Now;
        public DateTime? Date_Renew { get; set; }
        public DateTime? Date_Expire { get; set; }
        public int Count_Update { get; set; } = 0;
    }
}
