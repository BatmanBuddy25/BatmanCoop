using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BatmanCoopShared.Model.ManpowerModel
{
    public class MemberM
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string MemberNo { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
        public int? Age { get; set; }
        public string FullAddress { get; set; } = string.Empty;
        public string CivilStatus { get; set; } = string.Empty;
        public string Contact { get; set; } = string.Empty;
        public string MemStatus { get; set; } = string.Empty;
        public string ReferralId { get; set; } = string.Empty;
        public string ReferralName { get; set; } = string.Empty;
        public DateTime RegisterDate { get; set; } = DateTime.Now;
    }
}
