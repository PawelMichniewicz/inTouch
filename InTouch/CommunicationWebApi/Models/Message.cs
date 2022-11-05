﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommunicationWebApi.Models
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string? Content { get; set; }
        
        public bool Edited { get; set; } = false;

        public bool Deleted { get; set; } = false;

        [Required]
        public DateTime Timestamp { get; set; } = DateTime.Now;

        [Required]
        public User? Sender { get; set; }

        [Required]
        public ChatRoom? ChatRoom { get; set; }
    }
}
