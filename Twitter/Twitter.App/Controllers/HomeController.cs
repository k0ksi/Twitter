using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Twitter.App.Models.ViewModels;
using Twitter.Data.UnitOfWork;

namespace Twitter.App.Controllers
{
    public class HomeController : BaseController
    {
        private const int PageSize = 10;

        public HomeController(ITwitterData data) : base(data)
        {
        }

        public ActionResult Index(int? page)
        {
            IQueryable<TweetViewModel> tweets;
            int pageNumber = (page ?? 0);

            var loggedUserId = this.User.Identity.GetUserId();
            var user = this.Data.Users.Find(loggedUserId);
            if (user != null)
            {
                ViewBag.Title = "Profile";
                tweets = user
                    .FollowingUsers
                    .SelectMany(f => f.Tweets)
                    .OrderByDescending(t => t.CreatedAt)
                    .AsQueryable()
                    .Select(TweetViewModel.Create)
                    .Skip(pageNumber * PageSize);

                return View(tweets);
            }

            ViewBag.Title = "Home";
            tweets = this.Data.Tweets.All()
                .OrderByDescending(t => t.CreatedAt)
                .Select(TweetViewModel.Create)
                .Skip(pageNumber * PageSize);

            return View(tweets);
        }
    }
}