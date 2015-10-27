using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Twitter.App.Models.BindingModels
{
    [ValidateAntiForgeryToken]
    public class PaginationBindingModel
    {
        [Required]
        public int StartPage { get; set; }
    }
}