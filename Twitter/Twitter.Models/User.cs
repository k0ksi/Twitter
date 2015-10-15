using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Twitter.Models
{
    public class User : IdentityUser
    {
        [MaxLength(50)]
        public string ScreenName { get; set; }

        private ICollection<User> followingUsers;
        private ICollection<User> followers;
        private ICollection<Tweet> tweets;
        private ICollection<Tweet> favouriteTweets;
        private ICollection<Message> sentMessages;
        private ICollection<Message> receivedMessages;
        private ICollection<Notification> receivedNotifications;
        private ICollection<Notification> involvedNotifications;  

        public User()
        {
            this.followingUsers = new HashSet<User>();
            this.followers = new HashSet<User>();
            this.tweets = new HashSet<Tweet>();
            this.favouriteTweets = new HashSet<Tweet>();
            this.sentMessages = new HashSet<Message>();
            this.receivedMessages = new HashSet<Message>();
            this.involvedNotifications = new HashSet<Notification>();
            this.receivedNotifications = new HashSet<Notification>();
        }

        public virtual ICollection<User> FollowingUsers
        {
            get { return this.followingUsers; }
            set { this.followingUsers = value; }
        }

        public virtual ICollection<User> Followers
        {
            get { return this.followers; }
            set { this.followers = value; }
        }

        public virtual ICollection<Tweet> Tweets
        {
            get { return this.tweets; }
            set { this.tweets = value; }
        }

        public virtual ICollection<Tweet> FavouriteTweets
        {
            get { return this.favouriteTweets; }
            set { this.favouriteTweets = value; }
        }

        public virtual ICollection<Message> SentMessages
        {
            get { return this.sentMessages; }
            set { this.sentMessages = value; }
        }

        public virtual ICollection<Message> ReceivedMessages
        {
            get { return this.receivedMessages; }
            set { this.receivedMessages = value; }
        }

        public virtual ICollection<Notification> ReceivedNotifications
        {
            get { return this.receivedNotifications; }
            set { this.receivedNotifications = value; }
        }

        public virtual ICollection<Notification> InvolvedNotifications
        {
            get { return this.involvedNotifications; }
            set { this.involvedNotifications = value; }
        } 

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}