using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CentralizedQrCodeApp.Data.DataModels
{
   public partial class QrCodeContext : IdentityDbContext<User> 
    {
        public QrCodeContext()
        {

        }
        public QrCodeContext(DbContextOptions<QrCodeContext> options)
            :base(options)
        {

        }

        public virtual DbSet<QrCode> QrCodes { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
    }
}
