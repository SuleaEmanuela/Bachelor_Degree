using CentralizedQrCodeApp.Data.DataModels;
using CentralizedQrCodeApp.Data.Repositories.Interfaces;
using CentralizedQrCodeApp.Service.Services.Interfaces;
using CentralizedQrCodeApp.TL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralizedQrCodeApp.Service.Services
{
   
    public class QrCodeService : IQrCodeService
    {
        private readonly IQrCodeRepository _qrCodeRepository;

        public QrCodeService (IQrCodeRepository qrCodeRepository)
        {
            _qrCodeRepository = qrCodeRepository;
        }
        public async Task<QrCodeDto> DeleteQrCodeAsync(int qrCodeId)
        {
            QrCodeDto qrCodeToDelete = new QrCodeDto();
          
            if (qrCodeId == 0)
            {
                throw new NullReferenceException();
            }
            else
            {
                bool checkId = await _qrCodeRepository.CheckQrCodeIdExists(qrCodeId);
                if ((qrCodeId != 0 || qrCodeId == 0) && checkId == false)
                {
                    throw new Exception($"The provided id {qrCodeId} doesn't match any qr code. Cannot delete object.");
                }
                else
                {

                    qrCodeToDelete = await _qrCodeRepository.DeleteQrCodeAsync(qrCodeId);
                    return qrCodeToDelete;
                    
                }

            }
           
        }

        public async Task<List<QrCodeDto>> GetQrCodesAsync(int? qrCodeId, string qrCodeName=null)
        {
            List<QrCodeDto> qrCodeToReturn = null;

            if(qrCodeId == null && qrCodeName == null)
            {
                qrCodeToReturn = await _qrCodeRepository.GetQrCodesAsync();
                return qrCodeToReturn;
            }

            if(qrCodeId != null)
            {
                bool isNegativeOrZero = qrCodeId <= 0;
                if (isNegativeOrZero)
                    throw new Exception();


                QrCodeDto qrCode = await _qrCodeRepository.GetQrCodeByIdAsync(qrCodeId);

                if (qrCode is null)
                    throw new Exception();

                qrCodeToReturn = new List<QrCodeDto>();
                qrCodeToReturn.Add(qrCode);

                return qrCodeToReturn;
            }
            if(qrCodeName != null)
            {
                bool isAlphabetic = qrCodeName.All(Char.IsLetter);
                if (!isAlphabetic)
                    throw new Exception();

                QrCodeDto qrCode = await _qrCodeRepository.GetQrCodeByNameAsync(qrCodeName);

                if (qrCode == null)
                    throw new Exception();

                qrCodeToReturn = new List<QrCodeDto>();
                qrCodeToReturn.Add(qrCode);

                return qrCodeToReturn;

            }
            return qrCodeToReturn;

        }

        public async Task<QrCodeDto> PostQrCodesAsync(QrCodeDto qrCodeDto)
        {
           QrCodeDto qrCodeToReturn = new();
            if (qrCodeDto == null)
            {
                throw new NullReferenceException("The provided parameter is empty. ");
            }
            if (qrCodeDto.Id != 0)
            {
                  throw new Exception("Cannot create qr code.");
            }
            else
            {
                bool checkUrl = await _qrCodeRepository.CheckQrCodeUrlExists(qrCodeDto.Url);
                if (checkUrl == true)
                {
                    throw new Exception($"The provided url {qrCodeDto.Url}  match another qr code. Cannot create object.");
                }
                else
                {
                    await _qrCodeRepository.CreateQrCodeAsync(qrCodeDto);
                    qrCodeToReturn = qrCodeDto;
                }
            }
            
            return qrCodeToReturn;
        }

        public async Task<QrCodeDto> PutQrCodeAsync(QrCodeDto qrCodeDto)
        {
            QrCodeDto qrCodeToReturn = new();
            if (qrCodeDto == null)
            {
                throw new NullReferenceException("The provided parameter is empty. ");
            }
            if (qrCodeDto.Id == 0)
            {
                throw new Exception("Cannot update qr code.");
            }
            else
            {
               await _qrCodeRepository.UpdateQrCodeAsync(qrCodeDto);
                qrCodeToReturn = qrCodeDto;
            }
            return qrCodeToReturn;
        }
    }
}
