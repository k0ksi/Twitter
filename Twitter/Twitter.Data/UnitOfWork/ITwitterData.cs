using Twitter.Data.Repositories;
using Twitter.Models;

namespace Twitter.Data.UnitOfWork
{
    public interface ITwitterData
    {
        IRepository<User> Users { get; }

        IRepository<Message> Messages { get; }

        IRepository<Tweet> Tweets { get; }

        IRepository<Notification> Notifications { get; } 

        void SaveChanges();
    }
}