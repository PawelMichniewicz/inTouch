using CommunicationWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommunicationWebApi.Services.Interfaces
{
    public interface IChatRoomService
    {
        public Task<ChatRoom?> QueryChatRoomAsync(int id);
        public Task<ICollection<string>?> QueryChatRoomsByUserAsync(string name);
        public Task<int> AddChatRoomAsync(ChatRoom chatRoom);
    }
}