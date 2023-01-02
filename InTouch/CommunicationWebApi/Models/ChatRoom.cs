using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommunicationWebApi.Models
{
    public class ChatRoom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "Chat room";

        public bool Archived { get; set; } = false;

        public bool Deleted { get; set; } = false;

        public ICollection<User> Members { get; set; } = new List<User>();

        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
