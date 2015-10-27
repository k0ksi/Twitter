using System;
using System.Linq.Expressions;
using Twitter.Models;

namespace Twitter.App.Models.ViewModels
{
    public class UserTweetViewModel
    {
        public string Content { get; set; }

        public string Bio { get; set; }

        public string Location { get; set; }

        public DateTime? BirthDay { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UserFullName { get; set; }

        public string UserAvatarUrl { get; set; }

        public int LikesCount { get; set; }
        
        public int FollowersCount { get; set; }

        public int FollowingCount { get; set; }

        public int FavouritesCount { get; set; }

        public string Website { get; set; }

        public int TweetsCount { get; set; }

        public decimal? TweetsCountAll { get; set; }

        public static Expression<Func<Tweet, UserTweetViewModel>> Create
        {
            get
            {
                return tweet => new UserTweetViewModel()
                {
                    Content = tweet.Content,
                    CreatedAt = tweet.CreatedAt,
                    UserAvatarUrl = tweet.User.AvatarUrl,
                    LikesCount = tweet.Likes.Count,
                    FollowersCount = tweet.User.Followers.Count,
                    FollowingCount = tweet.User.FollowedUsers.Count,
                    FavouritesCount = tweet.User.FavouriteTweets.Count,
                    Bio = tweet.User.Bio,
                    Website = tweet.User.Website,
                    Location = tweet.User.Location,
                    BirthDay = tweet.User.BirthDay,
                    TweetsCount = tweet.User.Tweets.Count,
                    UserFullName = tweet.User.ScreenName ?? tweet.User.UserName
                };
            }
        }
    }
}