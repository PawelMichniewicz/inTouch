using CommunicationWebApi.Models;

namespace CommunicationWebApi.Services.Interfaces
{
    public interface IMessageService
    {
        public Task<Message?> GetMessageAsync(int id);
    }
}