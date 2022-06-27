using CentralizedQrCodeApp.Data.DataModels;
using CentralizedQrCodeApp.Data.Repositories.Interfaces;
using CentralizedQrCodeApp.TL.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentralizedQrCodeApp.Data.AutoMapper;
using System;

namespace CentralizedQrCodeApp.Data.Repositories
{
   
    public class QrCodeRepository : Repository<QrCode>,IQrCodeRepository
    {
        
        public QrCodeRepository(QrCodeContext context)
            :base(context)
        { }

        public async Task<QrCodeDto> CreateQrCodeAsync(QrCodeDto qrCodeDto)
        {
            QrCode qrCodeToCreate = Mapping.Mapper.Map<QrCode>(qrCodeDto);

            await base.AddAsync(qrCodeToCreate);

            QrCodeDto createdQrCode = Mapping.Mapper.Map<QrCodeDto>(qrCodeToCreate);

            return createdQrCode;
        }
        public async Task<QrCodeDto> UpdateQrCodeAsync(QrCodeDto qrCodeDto)
        {
            QrCode qrCodeToUpdate = await base.GetAsync(qrCodeDto.Id);

            QrCodeDto qrCode = Mapping.Mapper.Map<QrCodeDto>(qrCodeToUpdate);

            _context.Entry(qrCodeToUpdate).CurrentValues.SetValues(qrCodeDto);

            await base.UpdateAsync(qrCodeToUpdate);
            QrCodeDto qrCodeUpdated = Mapping.Mapper.Map<QrCodeDto>(qrCodeToUpdate);
            return qrCodeUpdated;
        }
        public async Task<QrCodeDto> DeleteQrCodeAsync(int id)
        {
            int qrCodeId = Convert.ToInt32(id);
            QrCode qrCodeToBeDelete = await base.GetAsync(qrCodeId);
            await base.DeleteAsync(qrCodeToBeDelete);
            QrCodeDto qrCodeDeleted = Mapping.Mapper.Map<QrCodeDto>(qrCodeToBeDelete);
            return qrCodeDeleted;
        }
        public async Task<List<QrCodeDto>> GetQrCodesAsync()
        {
            IQueryable<QrCode> allQrCodes = GetAll();

            List<QrCode> qrCodes = await allQrCodes.ToListAsync();

            List<QrCodeDto> qrCodesToReturn = Mapping.Mapper.Map<List<QrCode>, List<QrCodeDto>>(qrCodes);
            return qrCodesToReturn;
        }

        public async Task<QrCodeDto> GetQrCodeByIdAsync(int? id)
        {
            int qrCodeId = Convert.ToInt32(id);

            QrCode qrCode = await base.GetAsync(qrCodeId);

            QrCodeDto qrCodeToReturn = Mapping.Mapper.Map<QrCodeDto>(qrCode);

            return qrCodeToReturn;
        }

        public async Task<QrCodeDto> GetQrCodeByNameAsync(string name=null)
        {
            QrCode qrCode=await _context.QrCodes.Where(e => e.Name.Equals(name)).FirstOrDefaultAsync();

            QrCodeDto qrCodeToReturn = Mapping.Mapper.Map<QrCodeDto>(qrCode);

            return qrCodeToReturn;
        }

        public async Task<QrCodeDto> GetQrCodeByUrlAsync(string url)
        {
            QrCode qrCode = await _context.QrCodes.Where(e => e.Url.Equals(url)).FirstOrDefaultAsync();

            QrCodeDto qrCodeToReturn = Mapping.Mapper.Map<QrCodeDto>(qrCode);

            return qrCodeToReturn;
        }

        public async Task<bool> CheckQrCodeIdExists(int qrCodeId)
        {
            return await _context.QrCodes.AnyAsync(x => x.Id.Equals(qrCodeId));
        }
        public async Task<bool> CheckQrCodeUrlExists(string url)
        {
            return await _context.QrCodes.AnyAsync(x => x.Url.Equals(url));
        }
    }
}
