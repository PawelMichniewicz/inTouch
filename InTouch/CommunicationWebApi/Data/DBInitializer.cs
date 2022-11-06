using CommunicationWebApi.Models;

namespace CommunicationWebApi.Data
{
    internal static class DBInitializer
    {
        internal static void Initialize(CommunicationDbContext context)
        {
            if (context.Messages.Any() || context.Users.Any() || context.ChatRooms.Any())
            {
                // DB already seeded
                return;
            }

            // seed Users
            var joey = new User { Name = "Joey Tribbiani", Login = "JT", Password = "passwd" };
            var rachel = new User { Name = "Rachel Green ", Login = "RG", Password = "passwd" };
            var chandler = new User { Name = "Chandler Bing", Login = "CB", Password = "passwd" };
            var ross = new User { Name = "Ross Geller", Login = "RG", Password = "passwd" };
            var monica = new User { Name = "Monica Geller", Login = "MG", Password = "passwd" };
            var phoebe = new User { Name = "Phoebe Buffay", Login = "PB", Password = "passwd" };
            context.Users.AddRange(joey, rachel, chandler, ross, monica, phoebe);

            // seed ChatRooms
            var cr = new ChatRoom {
                Name = "Friends",
                Members = new List<User> { joey, rachel, chandler, ross, monica, phoebe } };
            context.ChatRooms.Add(cr);

            context.Messages.AddRange(
                new Message { ChatRoom = cr, Sender = ross, Content = "hello", Timestamp = DateTime.Now },
                new Message { ChatRoom = cr, Sender = chandler, Content = "hi", Timestamp = DateTime.Now.AddSeconds(1) },
                new Message { ChatRoom = cr, Sender = joey, Content = "how you doin'?", Timestamp = DateTime.Now.AddSeconds(2) },
                new Message { ChatRoom = cr, Sender = monica, Content = "stop it Joey!", Timestamp = DateTime.Now.AddSeconds(3) });

            context.SaveChanges();
        }
    }
}