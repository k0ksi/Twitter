using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Twitter.Models
{
    public class Notification
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(500)]
        public string Content { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        public string SenderId { get; set; }

        [JsonIgnore]
        public virtual User Sender { get; set; }

        [Required]
        public string ReceiverId { get; set; }

        [JsonIgnore]
        public virtual User Receiver { get; set; }
    }
}