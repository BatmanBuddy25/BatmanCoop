using System.ComponentModel.DataAnnotations;

namespace BatmanCoopShared.Model.AccountModel
{
    public class UserDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide email")]
        public string? Username { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide password")]
        public string? Password { get; set; }
    }
}
