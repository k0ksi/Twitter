using System;

namespace Twitter.App.Models.BindingModels
{
    public class EditProfileBindingModel
    {
        public string AvatarUrl { get; set; }

        public string FullName { get; set; }

        public string Bio { get; set; }

        public string Location { get; set; }

        public string Website { get; set; }

        public DateTime? BirthDay { get; set; }
    }
}