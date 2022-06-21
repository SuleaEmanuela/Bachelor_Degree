using System.ComponentModel.DataAnnotations;

namespace CentralizedQrCodeApp.TL.DTOs
{
    public partial class UserAuthentificationDto
    {
        [Required(ErrorMessage="Email is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

    }
}
