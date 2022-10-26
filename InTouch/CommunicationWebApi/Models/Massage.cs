namespace CommunicationWebApi.Models
{
    public class Massage
    {
        public string? Content { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.Now;

        public User? Sender { get; set; }
        
        public User? Receiver { get; set; }
    }
}
