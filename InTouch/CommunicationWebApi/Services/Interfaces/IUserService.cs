namespace CommunicationWebApi.Services.Interfaces
{
    public interface IUserService
    {
        public Task<ICollection<string>?> QueryChatRoomsByUserAsync(string name);
    }
}