using CommunicationWebApi.Data;
using CommunicationWebApi.Models;
using CommunicationWebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CommunicationWebApi.Services
{
    public class UserService : ServiceBase, IUserService
    {
        public UserService(CommunicationDbContext dbContext) : base(dbContext)
        { }

        public async Task<ICollection<string>?> QueryChatRoomsByUserAsync(string name)
        {
            User user = await dbContext.Users.FirstAsync(u => u.Name == name);
            ICollection<string>? result = user.ChatRooms?.Select(c => c.Name).ToArray();
            return result;
        }

        public async Task<User?> QueryUserProfileAsync(string name)
        {
            var profile = await dbContext.Users.FirstOrDefaultAsync(u => u.Name == name);
            return profile;
        }
    }
}