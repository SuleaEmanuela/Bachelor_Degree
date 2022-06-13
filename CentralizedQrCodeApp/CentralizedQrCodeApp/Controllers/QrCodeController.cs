using CentralizedQrCodeApp.Service.Services.Interfaces;
using CentralizedQrCodeApp.TL.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System;


namespace CentralizedQrCodeApp.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class QrCodeController : ControllerBase
    {
        private readonly IQrCodeService _qrCodeService;

        public QrCodeController(IQrCodeService qrCodeService)
        {
            _qrCodeService = qrCodeService;
        }

        [HttpGet]
        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
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

        }

        [HttpPost]
        public async Task<ActionResult<QrCodeDto>> CreateQrCodesAsync([FromBody] QrCodeDto qrCodeDto)
        {
            QrCodeDto result = await _qrCodeService.PostQrCodesAsync(qrCodeDto);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<QrCodeDto>> UpdateQrCodesAsync([FromBody] QrCodeDto qrCodeDto)
        {
            QrCodeDto result = await _qrCodeService.PutQrCodeAsync(qrCodeDto);

            return Ok(result);
        }


        [HttpDelete]
        //: int -> it forces the route to accept only int type
        [Route("{id:int}")]
        public async Task<ActionResult<QrCodeDto>> DeleteQrCodeAsync( [FromRoute] int id)
        {
            QrCodeDto result = await _qrCodeService.DeleteQrCodeAsync(id);

            return Ok(result);
        }


    }
}
