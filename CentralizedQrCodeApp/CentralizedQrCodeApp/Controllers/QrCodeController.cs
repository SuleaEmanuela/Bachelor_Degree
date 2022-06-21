using CentralizedQrCodeApp.Service.Services.Interfaces;
using CentralizedQrCodeApp.TL.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System;
using Microsoft.Extensions.Logging;

namespace CentralizedQrCodeApp.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class QrCodeController : ControllerBase
    {
        private readonly IQrCodeService _qrCodeService;
        private readonly ILogger _logger;

        public QrCodeController(IQrCodeService qrCodeService, ILogger<QrCodeController> logger)
        {
            _qrCodeService = qrCodeService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<QrCodeDto>>> GetQrCodesAsync(int? id, string name = null)
        {
            try
            {
                var claims = User.Claims;
                List<QrCodeDto> result = await _qrCodeService.GetQrCodesAsync(id, name);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error.");
            }
            _logger.LogInformation("Log message in the GetQrCodeAsync() method");

        }

        [HttpPost]
        public async Task<ActionResult<QrCodeDto>> CreateQrCodesAsync([FromBody] QrCodeDto qrCodeDto)
        {
            QrCodeDto result = await _qrCodeService.PostQrCodesAsync(qrCodeDto);
            _logger.LogInformation("Log message in the CreateQrCodesAsyncs() method");
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<QrCodeDto>> UpdateQrCodesAsync([FromBody] QrCodeDto qrCodeDto)
        {
            QrCodeDto result = await _qrCodeService.PutQrCodeAsync(qrCodeDto);
            _logger.LogInformation("Log message in the UpdateQrCodesAsync() method");
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<QrCodeDto>> DeleteQrCodeAsync( [FromRoute] int id)
        {
            QrCodeDto result = await _qrCodeService.DeleteQrCodeAsync(id);
            _logger.LogInformation("Log message in the DeleteQrCodeAsync() method");
            return Ok(result);
        }


    }
}
