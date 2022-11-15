using CommunicationWebApi.Controllers;
using CommunicationWebApi.Services.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Xml.Linq;

namespace CommunicationWebApi.Tests
{
    public class UserControllerTests
    {
        private readonly Mock<ILogger<UserController>> loggerStub = new();

        [Fact]
        public async Task Get_GreenPath_Async()
        {
            // Arrange
            string name = "Ross Geller";
            ICollection<string> expectedChatRooms = new[] { "Frinds", "Chandler", "Monica" };
            var serviceStub = new Mock<IUserService>();
            serviceStub.Setup(m => m.QueryChatRoomsByUserAsync(It.IsAny<string>())).ReturnsAsync(expectedChatRooms);
            UserController UUT = new(loggerStub.Object, serviceStub.Object);

            // Act
            var response = await UUT.GetUsersChatRoomsAsync(name);

            // Assert
            response.Result.As<OkObjectResult>().Value.Should().BeEquivalentTo(expectedChatRooms);
        }

        [Fact]
        public async Task Get_NotFound_Async()
        {
            // Arrange
            string name = "Ross Geller";
            var serviceStub = new Mock<IUserService>();
            serviceStub.Setup(m => m.QueryChatRoomsByUserAsync(It.IsAny<string>())).ReturnsAsync((ICollection<string>?)null);
            UserController UUT = new(loggerStub.Object, serviceStub.Object);

            // Act
            var response = await UUT.GetUsersChatRoomsAsync(name);
            
            // Assert
            response.Result.Should().BeOfType<NotFoundResult>();
        }
    }
}