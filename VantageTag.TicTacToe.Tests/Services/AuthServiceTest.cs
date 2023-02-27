using Moq;
using NUnit.Framework;
using VantageTag.TicTacToe.Core.Services;
using Assert = NUnit.Framework.Assert;

namespace VantageTag.TicTacToe.Tests.Services
{
    [TestFixture]
    public class AuthServiceTest
    {
        private AuthService _authService;

        [SetUp]
        public void Init()
        { }

        public async Task LoginAsync_WhenCredentialsAreInvalid_ShouldReturnNull()
        {
            // Act
            var result = _authService.LoginAsync(It.IsAny<string>(), It.IsAny<string>());

            // Assert
            Assert.That(result, Is.Null);
        }

        public async Task LoginAsync_WhenCredentialsArevalid_ShouldReturnAccessToken()
        {
            // Act
            var result = _authService.LoginAsync(It.IsAny<string>(), It.IsAny<string>());

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Not.Empty);
        }
    }
}
