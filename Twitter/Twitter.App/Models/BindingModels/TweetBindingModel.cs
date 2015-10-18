using System.ComponentModel.DataAnnotations;

namespace Twitter.App.Models.BindingModels
{
    public class TweetBindingModel
    {
        [Required]
        [StringLength(140, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Content { get; set; }
    }
}