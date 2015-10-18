using System;
using System.ComponentModel.DataAnnotations;

namespace Twitter.App.Models.BindingModels
{
    public class EditProfileBindingModel
    {
        public string AvatarUrl { get; set; }

        [StringLength(50, ErrorMessage = "The {0} must be no more than {1} characters long.", MinimumLength = 2)]
        public string FullName { get; set; }

        public string Bio { get; set; }

        public string Location { get; set; }

        public string Website { get; set; }

        public DateTime? BirthDay { get; set; }
    }
}