using System.Collections.Generic;

namespace CentralizedQrCodeApp.TL.DTOs
{
    public partial  class RegistrationResponseDto
    {
        public bool IsSuccessfulRegistration { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
