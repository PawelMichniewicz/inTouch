namespace CommunicationWebApi.Models
{
    public class Massage
    {
        //[PrimaryKey]
        public int ID { get; set; }

        public string? Content { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.Now;

        public User? Sender { get; set; }
        
        public User? Receiver { get; set; }
    }
}
