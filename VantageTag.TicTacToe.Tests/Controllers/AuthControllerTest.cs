using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using VantageTag.TicTacToe.API.Controllers.V1;
using VantageTag.TicTacToe.Core.Contracts.Requests;
using VantageTag.TicTacToe.Core.Interfaces;
using Assert = NUnit.Framework.Assert;

namespace VantageTag.TicTacToe.Tests.Controllers
{
    [TestFixture]
    public class AuthControllerTest
    {
        private Mock<IAuthService> _authServiceMock;
        private AuthController _authController;
        private LoginModel _loginModel;

        [SetUp]
        public void Init()
        {
            _authServiceMock = new Mock<IAuthService>();
            _authController = new AuthController(_authServiceMock.Object);
        }

        [Test]
        public async Task Login_WhenModelIsInvalid_ShouldReturnError()
        {
            // Act
            var result = await _authController.Login(_loginModel);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(400, ((ObjectResult)result).StatusCode);
        }

        [Test]
        public async Task Login_WhenModelIsValid_ShouldReturnSuccess()
        {
            // Arrange 
            _authServiceMock.Setup(a => a.LoginAsync(It.IsAny<string>(),It.IsAny<string>())).ReturnsAsync(() => It.IsAny<string>());

            // Act
            var result = await _authController.Login(_loginModel);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, ((ObjectResult)result).StatusCode);
        }
    }
}
