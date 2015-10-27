using System;
using System.Linq.Expressions;
using Twitter.Models;

namespace Twitter.App.Models.ViewModels
{
    public class TweetViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public int LikesCount { get; set; }

        public string Username { get; set; }

        public string UserId { get; set; }

        public string Avatar { get; set; }

        public decimal? TweetsCount { get; set; }

        public static Expression<Func<Tweet, TweetViewModel>> Create
        {
            get
            {
                return t => new TweetViewModel()
                {
                    Id = t.Id,
                    Content = t.Content,
                    CreatedAt = t.CreatedAt,
                    LikesCount = t.Likes.Count,
                    Username = t.User.UserName,
                    Avatar = t.User.AvatarUrl,
                    UserId = t.UserId
                };
            }
        } 
    }
}