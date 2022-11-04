using CommunicationWebApi.Models;

namespace CommunicationWebApi.Data
{
    internal static class DBInitializer
    {
        internal static void Initialize(CommunicationDbContext context)
        {
            if (context.Messages.Any())
            {
                // DB already seeded
                return;
            }

            context.Messages.AddRange(
                new Message { ID = 1, Content = "hello", Timestamp = DateTime.Now },
                new Message { ID = 2, Content = "hi", Timestamp = DateTime.Now.AddSeconds(1) },
                new Message { ID = 3, Content = "how you doin'?", Timestamp = DateTime.Now.AddSeconds(2) },
                new Message { ID = 4, Content = "stop it Joey!", Timestamp = DateTime.Now.AddSeconds(3) });

            context.SaveChanges();
        }
    }
}