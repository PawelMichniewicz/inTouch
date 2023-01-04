using CommunicationWebApi.Controllers;
using CommunicationWebApi.Models;
using CommunicationWebApi.Services.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace CommunicationWebApi.Tests
{
    public class UserControllerTests
    {
        private readonly string userName = "Ross Geller";
        private readonly Mock<ILogger<UserController>> loggerStub = new();

        [Fact]
        public async Task Get_Profile_GreenPath_Async()
        {
            // Arrange
            var serviceStub = new Mock<IUserService>();
            var expectedUser = new User
            {
                Id = 1,
                Name = userName,
                Nickname = "R.G."
            };
            serviceStub.Setup(m => m.QueryUserProfileAsync(It.IsAny<string>())).ReturnsAsync(expectedUser);
            UserController UUT = new(loggerStub.Object, serviceStub.Object);

            // Act
            var response = await UUT.GetUserProfileAsync(userName);

            // Assert
            response.Result.As<OkObjectResult>().Value.Should().BeEquivalentTo(expectedUser);
        }

        [Fact]
        public async Task Get_Profile_NotFound_Async()
        {
            // Arrange
            var serviceStub = new Mock<IUserService>();
            serviceStub.Setup(m => m.QueryUserProfileAsync(It.IsAny<string>())).ReturnsAsync((User?)null);
            UserController UUT = new(loggerStub.Object, serviceStub.Object);

            // Act
            var response = await UUT.GetUserProfileAsync(userName);

            // Assert
            response.Result.Should().BeOfType<NotFoundResult>();
        }
    }
}