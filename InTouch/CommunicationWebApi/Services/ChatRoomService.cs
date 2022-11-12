using CommunicationWebApi.Data;
using CommunicationWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunicationWebApi.Services
{
    public class ChatRoomService : ServiceBase
    {
        public ChatRoomService(CommunicationDbContext dbContext) : base(dbContext) 
        { }
        
    }
}