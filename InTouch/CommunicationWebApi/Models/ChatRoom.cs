namespace CommunicationWebApi.Models
{
    public class ChatRoom
    {
        public int ID { get; set; }

        public string? Name { get; set; } = "Chat room";

        public bool Archived { get; set; } = false;

        public bool Deleted { get; set; } = false;

        public IList<User>? Members { get; set; }

        public IList<Message>? Messages { get; set; }
    }
}
