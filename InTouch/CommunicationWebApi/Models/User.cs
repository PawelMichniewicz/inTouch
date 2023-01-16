using System.ComponentModel;
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
        [EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;

        public string Login => EmailAddress;

        // TODO: important! add secure password handling.
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Nickname { get; set; } = string.Empty;

        [JsonIgnore]    // required to stop cyclic dependancy when sending JSON back over REST api
        public ICollection<Message> Messages { get; set; } = new List<Message>();

        [JsonIgnore]    // same as above
        public ICollection<ChatRoom> ChatRooms { get; set; } = new List<ChatRoom>();
    }
}
