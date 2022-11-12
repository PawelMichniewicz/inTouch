using CommunicationWebApi.Data;
using CommunicationWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunicationWebApi.Services
{
    public class UserService : ServiceBase
    {
        public UserService(CommunicationDbContext dbContext) : base(dbContext)
        { }

        public async Task<ICollection<string?>> QueryChatRoomsByUserAsync(string name)
        {
            User temp = await dbContext.Users.FirstAsync(u => u.Name == name);
            var result = temp.ChatRooms.Select(c => c.Name).ToArray();
            return result;
        }
    }
}