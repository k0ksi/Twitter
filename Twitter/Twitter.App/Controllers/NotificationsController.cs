using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Twitter.App.Models.ViewModels;
using Twitter.Data.UnitOfWork;

namespace Twitter.App.Controllers
{
    public class NotificationsController : BaseController
    {
        public NotificationsController(ITwitterData data) : base(data)
        {
        }

        [Authorize]
        public ActionResult GetLastNotification()
        {
            var loggedUserId = this.User.Identity.GetUserId();
            var user = this.Data.Users.Find(loggedUserId);

            var notification = user
                .ReceivedNotifications
                .OrderByDescending(n => n.CreatedAt)
                .Take(1)
                .AsQueryable()
                .Select(NotificationViewModel.Create);

            return View(notification);
        }

        [Authorize]
        public ActionResult AllNotifications()
        {
            var loggedUserId = this.User.Identity.GetUserId();
            var user = this.Data.Users.Find(loggedUserId);

            var notifications = user
                .ReceivedNotifications
                .OrderByDescending(n => n.CreatedAt)
                .AsQueryable()
                .Select(NotificationViewModel.Create);

            return View(notifications);
        }
    }
}