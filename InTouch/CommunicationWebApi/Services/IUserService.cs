namespace CommunicationWebApi.Services
{
    public interface IUserService
    {
        public Task<ICollection<string?>> QueryChatRoomsByUserAsync(string name);
    }
}