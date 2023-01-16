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

        public async Task CreateUserAsync()
        {
            var temp = new User();
            var entity = await dbContext.Users.AddAsync(temp);
            dbContext.SaveChanges();
            throw new NotImplementedException();
        }

        public async Task<User?> QueryUserProfileAsync(string name)
        {
            var profile = await dbContext.Users.FirstOrDefaultAsync(u => u.Name == name);
            return profile;
        }

        public async Task<bool> UpdateProfileAsync(User profile)
        {
            if (await dbContext.Users.AnyAsync(u => u.Id == profile.Id))
            {
                dbContext.Entry(profile).State = EntityState.Modified;
            }

            var count = await dbContext.SaveChangesAsync();

            return count > 0;
        }
    }
}