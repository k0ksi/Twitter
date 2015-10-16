using System.Linq;
using System.Web.Http;
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

        public ActionResult ShowTweets([FromUri] PaginationBindingModel model)
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