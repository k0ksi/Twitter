﻿using System;
using System.Linq.Expressions;
using Twitter.Models;

namespace Twitter.App.Models.ViewModels
{
    public class TweetViewModel
    {
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public int LikesCount { get; set; }

        public string Username { get; set; }

        public static Expression<Func<Tweet, TweetViewModel>> Create
        {
            get
            {
                return t => new TweetViewModel()
                {
                    Content = t.Content,
                    CreatedAt = t.CreatedAt,
                    LikesCount = t.Likes.Count,
                    Username = t.User.UserName
                };
            }
        } 
    }
}