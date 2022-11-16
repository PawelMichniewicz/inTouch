using CommunicationWebApi.Controllers;
using CommunicationWebApi.Models;
using CommunicationWebApi.Services.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace CommunicationWebApi.Tests
{
    public class ChatRoomControllerTests
    {
        private readonly Mock<ILogger<ChatRoomController>> loggerStub = new();

        [Fact]
        public async Task Get_GreenPath_Async()
        {
            // Arrange
            int chatRoomId = 1;
            var expectedChatRoom = new ChatRoom()
            {
                Id = chatRoomId,
                Name = "chat Room name"
            };
            var serviceStub = new Mock<IChatRoomService>();
            serviceStub.Setup(m => m.QueryChatRoomAsync(It.IsAny<int>())).ReturnsAsync(expectedChatRoom);
            var UUT = new ChatRoomController(loggerStub.Object, serviceStub.Object);

            // Act
            var response = await UUT.GetChatRoomAsync(chatRoomId);

            // Assert
            response?.Result.As<OkObjectResult>().Value.Should().BeEquivalentTo(expectedChatRoom);
        }

        [Fact]
        public async Task Get_NotFound_Async()
        {
            // Arrange
            int chatRoomId = 1;
            var serviceStub = new Mock<IChatRoomService>();
            serviceStub.Setup(m => m.QueryChatRoomAsync(It.IsAny<int>())).ReturnsAsync((ChatRoom?)null);
            var UUT = new ChatRoomController(loggerStub.Object, serviceStub.Object);

            // Act
            var response = await UUT.GetChatRoomAsync(chatRoomId);

            // Assert
            response?.Result.Should().BeOfType<NotFoundResult>();
        }
    }
}
