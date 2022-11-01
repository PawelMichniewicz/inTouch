using CommunicationWebApi.Data;
using CommunicationWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunicationWebApi.Services
{
    public class MessageService
    {
        private readonly CommunicationDbContext dbContext;

        public MessageService(CommunicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Message?> GetMessageAsync(int id)
        {
            return await dbContext.Messages.FirstOrDefaultAsync(msg => msg.ID == id);
        }
    }
}
