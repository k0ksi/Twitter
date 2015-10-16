using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Twitter.App.Models.BindingModels;
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

        public ActionResult Index([FromUri] PaginationBindingModel model)
        {
            IQueryable<TweetViewModel> tweets;
            
            var loggedUserId = this.User.Identity.GetUserId();
            var user = this.Data.Users.Find(loggedUserId);
            if (user != null)
            {
                ViewBag.Title = "Home";
                tweets = user
                    .FollowedUsers
                    .SelectMany(f => f.Tweets)
                    .OrderByDescending(t => t.CreatedAt)
                    .AsQueryable()
                    .Skip(model.StartPage * PageSize)
                    .Take(PageSize)
                    .Select(TweetViewModel.Create);

                ViewBag.TweetsCount = (decimal)tweets.Count();

                return View(tweets);
            }

            ViewBag.Title = "Home";
            tweets = this.Data.Tweets.All()
                .OrderByDescending(t => t.CreatedAt)
                .Skip(model.StartPage * PageSize)
                .Take(PageSize)
                .Select(TweetViewModel.Create);

            ViewBag.TweetsCount = (decimal) this.Data.Tweets.All().Count();

            return View(tweets);
        }
    }
}