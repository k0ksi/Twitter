using System;
using System.Data.Entity.Migrations;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Twitter.Models;

namespace Twitter.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<TwitterContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TwitterContext context)
        {
            //if (!context.Users.Any())
            //{
            //    SeedUsers(context);
            //}

            //context.SaveChanges();
        }

        private void SeedUsers(TwitterContext context)
        {
            var store = new UserStore<User>(context);
            var manager = new UserManager<User>(store);
            var user = new User()
            {
                UserName = "lucho",
                Email = "lucho@abv.bg",
                PhoneNumber = "+359897564793",
                AvatarUrl = "data:image/jpeg;base64,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"
            };

            manager.Create(user, "a");
        }

        //    if (!context.Users.Any())
        //    {
        //        SeedUsers(context);

        //        var gencho = context.Users.Find("1a626967-4c37-4a49-8b39-c999bb5d531b");

        //        var courage = context.Users.Find("2617f522-237d-4b2c-b9f5-4b5c45fd2e26");

        //        var ginka = context.Users.Find("8d56b767-9fc0-45f9-9914-c0fe1e3e18e3");

        //        var tonko = context.Users.Find("cad32582-693b-40f8-bdd4-aa48cb73d62e");

        //        var toshko = context.Users.Find("cc20d976-b000-4474-b9dd-4569562e94bf");

        //        gencho.FollowedUsers.Add(courage);
        //        courage.Followers.Add(gencho);
        //        gencho.FollowedUsers.Add(ginka);
        //        ginka.Followers.Add(gencho);
        //        tonko.FollowedUsers.Add(toshko);
        //        toshko.Followers.Add(tonko);

        //        context.SaveChanges();
        //    }

        //    if (!context.Messages.Any())
        //    {
        //        SeedMessages(context);
        //    }

        //    if (!context.Tweets.Any())
        //    {
        //        SeedTweets(context);
        //    }
        //}

        //private void SeedTweets(TwitterContext context)
        //{
        //    var gencho = context.Users.Find("1a626967-4c37-4a49-8b39-c999bb5d531b");

        //    var courage = context.Users.Find("2617f522-237d-4b2c-b9f5-4b5c45fd2e26");

        //    var ginka = context.Users.Find("8d56b767-9fc0-45f9-9914-c0fe1e3e18e3");

        //    var tonko = context.Users.Find("cad32582-693b-40f8-bdd4-aa48cb73d62e");

        //    var toshko = context.Users.Find("cc20d976-b000-4474-b9dd-4569562e94bf");

        //    var tweet1 = new Tweet()
        //    {
        //        Content = "#LOL!!! Titritititriti.",
        //        CreatedAt = new DateTime(2015, 10, 13),
        //        User = gencho,
        //        UserId = "1a626967-4c37-4a49-8b39-c999bb5d531b"
        //    };

        //    var tweet2 = new Tweet()
        //    {
        //        Content = "Kebaaaaaap!!",
        //        CreatedAt = new DateTime(2015, 10, 2),
        //        User = courage,
        //        UserId = "2617f522-237d-4b2c-b9f5-4b5c45fd2e26"
        //    };

        //    var tweet3 = new Tweet()
        //    {
        //        Content = "Каква победа само снощи!",
        //        CreatedAt = new DateTime(2015, 10, 1),
        //        User = ginka,
        //        UserId = "8d56b767-9fc0-45f9-9914-c0fe1e3e18e3"
        //    };

        //    var tweet4 = new Tweet()
        //    {
        //        Content = "Amazing shoes!!",
        //        CreatedAt = new DateTime(2015, 10, 4),
        //        User = tonko,
        //        UserId = "cad32582-693b-40f8-bdd4-aa48cb73d62e"
        //    };

        //    var tweet5 = new Tweet()
        //    {
        //        Content = "What a beautiful day!",
        //        CreatedAt = new DateTime(2015, 10, 7),
        //        User = toshko,
        //        UserId = "cc20d976-b000-4474-b9dd-4569562e94bf"
        //    };

        //    var tweet6 = new Tweet()
        //    {
        //        Content = "Zo-zo-zo-zo magination!@!@!@",
        //        CreatedAt = new DateTime(2015, 10, 9),
        //        User = ginka,
        //        UserId = "8d56b767-9fc0-45f9-9914-c0fe1e3e18e3"
        //    };

        //    var tweet7 = new Tweet()
        //    {
        //        Content = "Where my bitches at!",
        //        CreatedAt = new DateTime(2015, 10, 12),
        //        User = courage,
        //        UserId = "2617f522-237d-4b2c-b9f5-4b5c45fd2e26"
        //    };

        //    var tweet8 = new Tweet()
        //    {
        //        Content = "Nananananananananananaananann!!!@!?",
        //        CreatedAt = new DateTime(2015, 10, 15),
        //        User = toshko,
        //        UserId = "cc20d976-b000-4474-b9dd-4569562e94bf"
        //    };

        //    var tweet9 = new Tweet()
        //    {
        //        Content = "Shake it!!!",
        //        CreatedAt = new DateTime(2015, 10, 14),
        //        User = tonko,
        //        UserId = "cad32582-693b-40f8-bdd4-aa48cb73d62e"
        //    };

        //    var tweet10 = new Tweet()
        //    {
        //        Content = "Nu nu da nu nu da...",
        //        CreatedAt = new DateTime(2015, 10, 13),
        //        User = ginka,
        //        UserId = "8d56b767-9fc0-45f9-9914-c0fe1e3e18e3"
        //    };

        //    var tweet11 = new Tweet()
        //    {
        //        Content = "Nu nu da nu nu da...",
        //        CreatedAt = new DateTime(2015, 10, 11),
        //        User = courage,
        //        UserId = "2617f522-237d-4b2c-b9f5-4b5c45fd2e26"
        //    };
        //}

        //private void SeedMessages(TwitterContext context)
        //{
        //    var message = new Message()
        //    {
        //        Content = "Hello!",
        //        CreatedAt = DateTime.Now,
        //        SenderId = "1a626967-4c37-4a49-8b39-c999bb5d531b",
        //        ReceiverId = "1a626967-4c37-4a49-8b39-c999bb5d531b"
        //    };

        //    context.Messages.Add(message);
        //    context.SaveChanges();
        //}

        //private void SeedUsers(TwitterContext context)
        //{
        //    var gencho = new User()
        //    {
        //        Id = "1a626967-4c37-4a49-8b39-c999bb5d531b",
        //        Email = "gen4o@gmail.com",
        //        PasswordHash = "ABUypgfE79XRhkSO9vI8PBn3pKqDP0XU78n+yC67KMxOD0qrZ+STxtSa90ZpaTBpeA==",
        //        UserName = "gen4o"
        //    };

        //    var courage = new User()
        //    {
        //        UserName = "courage",
        //        Id = "2617f522-237d-4b2c-b9f5-4b5c45fd2e26",
        //        Email = "courage@abv.bg",
        //        PasswordHash = "AF+HUnrqNSY7QEs/4dubNHIRrP732/zUHjAF400ZvN89IwNktM+xLP4CQGwyuSjXpw=="
        //    };

        //    var ginka = new User()
        //    {
        //        UserName = "ginka",
        //        Id = "8d56b767-9fc0-45f9-9914-c0fe1e3e18e3",
        //        Email = "ginka@abv.bg",
        //        PasswordHash = "ABPZB3yFZUGFxmhnwwAunAuvWUCIpH/GyeU122km6Rgfd8D9NjzitNb5ToJ9N3GlTg=="
        //    };

        //    var tonko = new User()
        //    {
        //        UserName = "tonko",
        //        Id = "cad32582-693b-40f8-bdd4-aa48cb73d62e",
        //        Email = "tonko@abv.bg",
        //        PasswordHash = "ABeaZdUAvg8CqYViwtnkBlpSfbxBG1T9GBZo3PRpfoCtfhmkjASNh5stabX2R/JRwQ=="
        //    };

        //    var toshko = new User()
        //    {
        //        UserName = "to6ko",
        //        Id = "cc20d976-b000-4474-b9dd-4569562e94bf",
        //        Email = "to6ko@abv.bg",
        //        PasswordHash = "AGZSo2eisBbQVF8mB0dKNfJJslpP/ODuQ1o0vGrKN+lWLYhCtd3iBYypxUsKEDsajw=="
        //    };

        //    var users = new User[] {ginka, toshko, tonko, courage, gencho};

        //    foreach (var user in users)
        //    {
        //        context.Users.Add(user);
        //    }

        //    context.SaveChanges();
        //}
    }
}