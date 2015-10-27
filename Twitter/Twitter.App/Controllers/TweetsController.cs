using System;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Twitter.App.Models.BindingModels;
using Twitter.Data.UnitOfWork;
using Twitter.Models;
using Twitter.Models.Enums;

namespace Twitter.App.Controllers
{
    public class TweetsController : BaseController
    {
        public TweetsController(ITwitterData data) : base(data)
        {
        }

        [System.Web.Http.Authorize]
        public ActionResult ReportTweet()
        {
            return PartialView();
        }

        [System.Web.Http.Authorize]
        public ActionResult RetweetTweet(int tweetId)
        {
            var loggedUserId = this.User.Identity.GetUserId();
            var user = this.Data.Users.Find(loggedUserId);

            var retweetTweet = this.Data.Tweets.Find(tweetId);
            var tweet = new Tweet()
            {
                Content = retweetTweet.Content,
                CreatedAt = DateTime.Now,
                UserId = loggedUserId
            };

            var notification = new Notification()
            {
                CreatedAt = DateTime.Now,
                ReceiverId = retweetTweet.UserId,
                SenderId = loggedUserId,
                Seen = false,
                Type = NotificationType.Retweet
            };

            this.Data.Notifications.Add(notification);
            this.Data.Tweets.Add(tweet);
            this.Data.SaveChanges();
            
            return RedirectToAction("ShowProfile", "Users");
        }

        [System.Web.Http.Authorize]
        public ActionResult AddTweetToFavorite([FromUri] int tweetId)
        {
            var loggedUserId = this.User.Identity.GetUserId();
            var user = this.Data.Users.Find(loggedUserId);

            var favoriteTweet = this.Data.Tweets.Find(tweetId);
            var notification = new Notification()
            {
                CreatedAt = DateTime.Now,
                ReceiverId = favoriteTweet.UserId,
                SenderId = loggedUserId,
                Type = NotificationType.FavouriteTweet,
                Seen = false
            };

            this.Data.Notifications.Add(notification);
            user.FavouriteTweets.Add(favoriteTweet);

            this.Data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        // POST
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTweet(TweetBindingModel model)
        {
            var loggedUserId = this.User.Identity.GetUserId();
            User user = this.Data.Users.Find(loggedUserId);
            if (ModelState.IsValid)
            {
                if (model.Content == "")
                {
                    return RedirectToAction("Index", "Home");
                }
                var tweet = new Tweet()
                {
                    Content = model.Content,
                    CreatedAt = DateTime.Now,
                    UserId = loggedUserId
                };

                this.Data.Tweets.Add(tweet);
                this.Data.SaveChanges();

                return RedirectToAction("ShowProfile", "Users");
            }

            return View("Tweet/_CreateTweetPartial");
        }
    }
}