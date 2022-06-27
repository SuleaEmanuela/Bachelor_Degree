using CentralizedQrCodeApp.Controllers;
using CentralizedQrCodeApp.Data.AutoMapper;
using CentralizedQrCodeApp.Service.Services.Interfaces;
using CentralizedQrCodeApp.TL.DTOs;
using Moq;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CentralizedQrCodeApp.Tests
{
   internal class QrControllerTests

    {
        private QrCodeController qrCodeController;
        private int _qrCodeId = 5;

        private Mock<IQrCodeService> _iQrCodeServiceMock;
        [SetUp]
        public void Setup()
        {
            _iQrCodeServiceMock = new Mock<IQrCodeService>();    
        }

        [Test]
        public async Task DeletetQrCode_ShouldDeleteQrCode()
        {
            //Arrange 
            int qrCodeId = 5;
            QrCodeDto qrCodeToBeDeleted = new()
            {
                Id = 5,
                Name= " google site1",
                Url = "www.google.com",
                Status = "active"
            };
            _iQrCodeServiceMock.Setup(x => x.DeleteQrCodeAsync(qrCodeId)).ReturnsAsync(qrCodeToBeDeleted);

            //Act
            ActionResult<QrCodeDto> result = await qrCodeController.DeleteQrCodeAsync(qrCodeId);

            //Assert
            Assert.AreEqual(qrCodeToBeDeleted, (result.Result as OkObjectResult).Value);
        }

        [Test]
        public async Task CreateQrCode_ShouldCreateQrCode()
        {
            //Arrange 
            QrCodeDto qrCodeToBeCreated = new()
            {
                Id = 5,
                Name = " google site1",
                Url = "www.google.com",
                Status = "active"
            };
            _iQrCodeServiceMock.Setup(x => x.PostQrCodesAsync(qrCodeToBeCreated)).ReturnsAsync(qrCodeToBeCreated);

            //Act
            ActionResult<QrCodeDto> result = await qrCodeController.CreateQrCodesAsync(qrCodeToBeCreated);

            //Assert
            Assert.AreEqual(qrCodeToBeCreated, (result.Result as OkObjectResult).Value);
        }

        [Test]
        [TestCase("inactive")]
        public async Task EditQrCode_ShouldEditQrCode(string status)
        {
            //Arrange 
            string statusToEdit = "inactive";
            QrCodeDto qrCodeBeforeEdite = new()
            {
                Id = 5,
                Name = " google site",
                Url = "www.google.com",
                Status = statusToEdit
            };

            QrCodeDto qrCodeAfterEdited = new()
            {
                Id = 5,
                Name = " google site",
                Url = "www.google.com",
                Status = status
            };


            _iQrCodeServiceMock.Setup(x => x.PutQrCodeAsync(qrCodeBeforeEdite)).ReturnsAsync(qrCodeAfterEdited);

            //Act
            ActionResult<QrCodeDto> result = await qrCodeController.UpdateQrCodesAsync(qrCodeBeforeEdite);

            //Assert
            Assert.AreEqual(qrCodeAfterEdited, (result.Result as OkObjectResult).Value);
        }








    }
}