
namespace CentralizedQrCodeApp.TL.DTOs
{
    public partial class AuthentificationResponseDto
    {
        public bool IsAuthSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
    }
}
