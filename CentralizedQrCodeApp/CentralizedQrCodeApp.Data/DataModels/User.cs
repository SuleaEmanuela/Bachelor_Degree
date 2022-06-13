using Microsoft.AspNetCore.Identity;

namespace CentralizedQrCodeApp.Data.DataModels
{
   public partial class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
