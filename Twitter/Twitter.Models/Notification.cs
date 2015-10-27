using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Twitter.Models.Enums;

namespace Twitter.Models
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        
        public NotificationType Type { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public string SenderId { get; set; }

        [JsonIgnore]
        public virtual User Sender { get; set; }

        [Required]
        public string ReceiverId { get; set; }

        [JsonIgnore]
        public virtual User Receiver { get; set; }

        [Required]
        public bool Seen { get; set; }
    }
}