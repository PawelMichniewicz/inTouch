using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CommunicationWebApi.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Login { get; set; }

        [Required]
        public string? Password { get; set; }

        [JsonIgnore]    // required to stop cyclic dependancy when sending back with REST api as JSON
        public ICollection<Message>? Messages { get; set; }

        [JsonIgnore]    // same as above
        public ICollection<ChatRoom>? ChatRooms { get; set; }
    }
}
