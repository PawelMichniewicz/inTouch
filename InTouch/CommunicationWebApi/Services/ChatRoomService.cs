using CommunicationWebApi.Data;
using CommunicationWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunicationWebApi.Services
{
    public class ChatRoomService
    {
        private readonly CommunicationDbContext dbContext;

        public ChatRoomService(CommunicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        
    }
}