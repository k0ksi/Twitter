using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using Twitter.Models;

namespace Twitter.Data
{
    public class TwitterContext : IdentityDbContext<User>, ITwitterContext
    {
        public TwitterContext()
            : base("TwitterContext", throwIfV1Schema: false)
        {
        }

        public static TwitterContext Create()
        {
            return new TwitterContext();
        }

        public virtual IDbSet<Message> Messages { get; set; }

        public virtual IDbSet<Tweet> Tweets { get; set; }

        public virtual IDbSet<Notification> Notifications { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions
                .Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<User>()
                .HasMany(u => u.Followers)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("FollowerId");
                    m.ToTable("UsersFollowers");
                });

            modelBuilder.Entity<User>()
                .HasMany(u => u.FollowedUsers)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("FollowedUserId");
                    m.ToTable("FollowedUsers");
                });

            modelBuilder.Entity<User>()
                .HasMany(u => u.SentMessages)
                .WithRequired(m => m.Receiver)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(u => u.ReceivedMessages)
                .WithRequired(m => m.Sender)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(u => u.InvolvedNotifications)
                .WithRequired(m => m.Sender)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(u => u.ReceivedNotifications)
                .WithRequired(u => u.Receiver)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tweet>()
                .HasRequired<User>(t => t.User)
                .WithMany(t => t.Tweets)
                .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Tweets);

            modelBuilder.Entity<Tweet>()
                .HasMany(t => t.Likes)
                .WithMany(t => t.FavouriteTweets)
                .Map(m =>
                {
                    m.MapLeftKey("TweetId");
                    m.MapRightKey("UserId");
                    m.ToTable("FavouriteTweets");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}