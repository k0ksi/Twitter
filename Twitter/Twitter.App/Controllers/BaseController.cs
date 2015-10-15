using System.Web.Mvc;
using Twitter.Data;
using Twitter.Data.UnitOfWork;

namespace Twitter.App.Controllers
{
    public class BaseController : Controller
    {
        private ITwitterData data;

        protected ITwitterData Data { get; }

        public BaseController()
            : this(new TwitterData(new TwitterContext()))
        {
        }

        public BaseController(ITwitterData data)
        {
            this.Data = data;
        }
    }
}