using CommunicationWebApi.Models;

namespace CommunicationWebApi.Services.Interfaces
{
    public interface IUserService
    {
        public Task CreateUserAsync();
        public Task<User?> QueryUserProfileAsync(string name);
        public Task<bool> UpdateProfileAsync(User profile);
    }
}