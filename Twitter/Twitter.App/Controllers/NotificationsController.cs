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

        public ActionResult MarkAsRead(int notificationId)
        {
            var notification = this.Data.Notifications.Find(notificationId);

            notification.Seen = true;
            this.Data.SaveChanges();

            return RedirectToAction("AllNotifications");
        }

        public ActionResult GetUnread()
        {
            var loggedUserId = this.User.Identity.GetUserId();

            var count = this.Data.Notifications.All()
                .Count(n => n.ReceiverId == loggedUserId &&
                            !n.Seen && (n.SenderId != loggedUserId));

            return PartialView(count);
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