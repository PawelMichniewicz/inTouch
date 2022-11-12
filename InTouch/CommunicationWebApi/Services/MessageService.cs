using CommunicationWebApi.Data;
using CommunicationWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunicationWebApi.Services
{
    public class MessageService : ServiceBase
    {
        public MessageService(CommunicationDbContext dbContext) : base(dbContext)
        { }

        public async Task<Message?> GetMessageAsync(int id)
        {
            return await dbContext.Messages.FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
