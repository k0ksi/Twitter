using System;
using Twitter.Data.UnitOfWork;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Twitter.App.Models.BindingModels;
using Twitter.Models;

namespace Twitter.App.Controllers
{
    public class TweetsController : BaseController
    {
        public TweetsController(ITwitterData data) : base(data)
        {
        }

        // POST
        [HttpPost]
        [Authorize]
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