using CommunicationWebApi.Models;

namespace CommunicationWebApi.Services.Interfaces
{
    public interface IChatRoomService
    {
        public Task<ChatRoom?> QueryChatRoomAsync(int id);
    }
}