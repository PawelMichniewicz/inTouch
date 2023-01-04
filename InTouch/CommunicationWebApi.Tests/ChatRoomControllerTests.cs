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
        private readonly string userName = "Ross Geller";

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

        [Fact]
        public async Task Get_Chatrooms_GreenPath_Async()
        {
            // Arrange
            ICollection<string> expectedChatRooms = new[] { "Frinds", "Chandler", "Monica" };
            var serviceStub = new Mock<IChatRoomService>();
            serviceStub.Setup(m => m.QueryChatRoomsByUserAsync(It.IsAny<string>())).ReturnsAsync(expectedChatRooms);
            ChatRoomController UUT = new(loggerStub.Object, serviceStub.Object);

            // Act
            var response = await UUT.GetUserChatRoomsAsync(userName);

            // Assert
            response.Result.As<OkObjectResult>().Value.Should().BeEquivalentTo(expectedChatRooms);
        }

        [Fact]
        public async Task Get_Chatrooms_NotFound_Async()
        {
            // Arrange
            var serviceStub = new Mock<IChatRoomService>();
            serviceStub.Setup(m => m.QueryChatRoomsByUserAsync(It.IsAny<string>())).ReturnsAsync((ICollection<string>?)null);
            ChatRoomController UUT = new(loggerStub.Object, serviceStub.Object);

            // Act
            var response = await UUT.GetUserChatRoomsAsync(userName);

            // Assert
            response.Result.Should().BeOfType<NotFoundResult>();
        }
    }
}
