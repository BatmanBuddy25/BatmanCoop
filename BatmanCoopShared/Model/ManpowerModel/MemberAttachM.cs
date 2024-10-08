using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BatmanCoopShared.Model.ManpowerModel
{
    public class MemberAttachM
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Img_Filename { get; set; } = string.Empty;
        public string Img_Contenttype { get; set; } = string.Empty;
        public string Img_URL { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public byte[]? Img_Data { get; set; }
        public DateTime Img_Date { get; set; } = DateTime.Now;
        public string Member_No { get; set; } = string.Empty;
    }
}
