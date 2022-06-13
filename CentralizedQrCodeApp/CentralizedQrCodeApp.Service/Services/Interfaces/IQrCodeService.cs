using System.Collections.Generic;
using System.Threading.Tasks;
using CentralizedQrCodeApp.TL.DTOs;

namespace CentralizedQrCodeApp.Service.Services.Interfaces
{
    
    public interface IQrCodeService
    {
        Task<List<QrCodeDto>> GetQrCodesAsync(int? qrCodeId,string qrCodeName);

        Task<QrCodeDto> PostQrCodesAsync(QrCodeDto qrCode);

        Task<QrCodeDto> PutQrCodeAsync(QrCodeDto qrCode);

        Task<QrCodeDto> DeleteQrCodeAsync(int qrCodeId);
        
    }
}
