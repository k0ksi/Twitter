using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Twitter.App.Models.BindingModels
{
    [ValidateAntiForgeryToken]
    public class EditProfileBindingModel
    {
        public string AvatarUrl { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be no more than {1} characters long and at least 2 characters (not less).", MinimumLength = 2)]
        public string FullName { get; set; }

        public string Bio { get; set; }

        public string Location { get; set; }

        public string Website { get; set; }

        public DateTime? BirthDay { get; set; }
    }
}