using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommunicationWebApi.Models
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string? Content { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.Now;

        //public User? Sender { get; set; }
        
        //public User? Receiver { get; set; }
    }
}
