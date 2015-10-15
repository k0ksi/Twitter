using System.Data.Entity;
using Twitter.Models;

namespace Twitter.Data
{
    public interface ITwitterContext
    {
        IDbSet<Message> Messages { get; set; } 

        IDbSet<Tweet> Tweets { get; set; }

        IDbSet<Notification> Notifications { get; set; } 

        int SaveChanges();
    }
}