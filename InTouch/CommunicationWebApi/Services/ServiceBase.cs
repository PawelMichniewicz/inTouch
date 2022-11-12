using CommunicationWebApi.Data;

namespace CommunicationWebApi.Services
{
    public abstract class ServiceBase
    {
        protected readonly CommunicationDbContext dbContext;

        protected ServiceBase(CommunicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}