using System.ComponentModel.DataAnnotations;

namespace Twitter.App.Models.BindingModels
{
    public class TweetBindingModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(140)]
        public string Content { get; set; }
    }
}