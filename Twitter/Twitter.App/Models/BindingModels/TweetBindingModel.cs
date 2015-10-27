using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Twitter.App.Models.BindingModels
{
    [ValidateAntiForgeryToken]
    public class TweetBindingModel
    {
        [Required]
        [StringLength(140, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Content { get; set; }
    }
}