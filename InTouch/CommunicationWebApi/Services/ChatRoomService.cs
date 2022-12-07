using CommunicationWebApi.Data;
using CommunicationWebApi.Models;
using CommunicationWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CommunicationWebApi.Services
{
    public class ChatRoomService : ServiceBase, IChatRoomService
    {
        public ChatRoomService(CommunicationDbContext dbContext) : base(dbContext)
        { }


        public async Task<ChatRoom?> QueryChatRoomAsync(int id)
        {
            return await dbContext.ChatRooms
                .Include(c => c.Members)
                .Include(c => c.Messages)
                .FirstOrDefaultAsync(cr => cr.Id == id);
        }
        public async Task<int> AddChatRoomAsync(ChatRoom chatRoom)
        {
            _ = dbContext.ChatRooms.Add(chatRoom);
            return await dbContext.SaveChangesAsync();
        }
    }
}