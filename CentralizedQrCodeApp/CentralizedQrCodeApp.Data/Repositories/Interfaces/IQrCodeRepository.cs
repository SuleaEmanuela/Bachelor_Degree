using CentralizedQrCodeApp.Data.DataModels;
using CentralizedQrCodeApp.TL.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CentralizedQrCodeApp.Data.Repositories.Interfaces
{
    public interface IQrCodeRepository : IRepository<QrCode>
    {
        Task<List<QrCodeDto>> GetQrCodesAsync();

        Task<QrCodeDto> GetQrCodeByIdAsync(int? qrCodeId);

        Task<QrCodeDto> GetQrCodeByNameAsync(string name);

        Task<QrCodeDto> GetQrCodeByUrlAsync(string url);

        Task<QrCodeDto> CreateQrCodeAsync(QrCodeDto qrCodeDto);

        Task<QrCodeDto> UpdateQrCodeAsync(QrCodeDto qrCodeDto);

        Task<QrCodeDto> DeleteQrCodeAsync(int qrCodeId);

        Task<bool> CheckQrCodeIdExists(int qrCodeId);

        Task<bool> CheckQrCodeUrlExists(string url);


    }
}
