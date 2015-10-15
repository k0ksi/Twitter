using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Twitter.Models
{
    public class Tweet
    {
        private ICollection<User> likes;

        public Tweet()
        {
            this.likes = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(140)]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<User> Likes
        {
            get { return this.likes; }
            set { this.likes = value; }
        }
    }
}