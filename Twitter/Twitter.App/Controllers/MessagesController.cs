using Twitter.Data.UnitOfWork;

namespace Twitter.App.Controllers
{
    public class MessagesController : BaseController
    {
        public MessagesController(ITwitterData data) : base(data)
        {
        }
    }
}