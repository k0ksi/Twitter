using System.ComponentModel.DataAnnotations;

namespace Twitter.App.Models.BindingModels
{
    public class PaginationBindingModel
    {
        [Required]
        public int StartPage { get; set; }
    }
}