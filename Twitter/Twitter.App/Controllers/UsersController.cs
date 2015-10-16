using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Twitter.App.Models.BindingModels;
using Twitter.App.Models.ViewModels;
using Twitter.Data.UnitOfWork;

namespace Twitter.App.Controllers
{
    public class UsersController : BaseController
    {
        private const int PageSize = 10;

        public UsersController(ITwitterData data) : base(data)
        {
        }

        [Authorize]
        public ActionResult EditProfile()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile(EditProfileBindingModel model)
        {
            var loggedUserId = this.User.Identity.GetUserId();
            var user = this.Data.Users.Find(loggedUserId);

            if (model.FullName != null)
            {
                user.ScreenName = model.FullName;
            }

            if (model.AvatarUrl != null)
            {
                user.AvatarUrl = model.AvatarUrl;
            }

            if (model.Bio != null)
            {
                user.Bio = model.Bio;
            }

            if (model.BirthDay != null)
            {
                user.BirthDay = model.BirthDay;
            }

            if (model.Website != null)
            {
                user.Website = model.Website;
            }

            if (model.Location != null)
            {
                user.Location = model.Location;
            }

            this.Data.SaveChanges();

            return RedirectToAction("ShowProfile", "Users");
        }

        [System.Web.Mvc.Authorize]
        public ActionResult ShowProfile()
        {
            var loggedUserId = User.Identity.GetUserId();
            var user = this.Data.Users.Find(loggedUserId);
            var tweets = user.Tweets
                .OrderByDescending(t => t.CreatedAt)
                .AsQueryable()
                .Select(UserTweetViewModel.Create);

            ViewBag.TweetsCount = (decimal)tweets.Count();
            return View(tweets);
        }

        public ActionResult ShowTweets(PaginationBindingModel model)
        {
            IQueryable<TweetViewModel> tweets;

            var loggedUserId = this.User.Identity.GetUserId();
            var user = this.Data.Users.Find(loggedUserId);
        
            ViewBag.Title = "Profile";
            tweets = user
                .Tweets
                .OrderByDescending(t => t.CreatedAt)
                .AsQueryable()
                .Skip(model.StartPage*PageSize)
                .Take(PageSize)
                .Select(TweetViewModel.Create);

            ViewBag.TweetsCount = (decimal)tweets.Count();

            return View(tweets);
        }
    }
}