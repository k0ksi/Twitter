using System;
using System.Data.Entity.Migrations;
using System.Linq;
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
            if (!context.Users.Any())
            {
                SeedUsers(context);

                var gencho = context.Users.Find("1a626967-4c37-4a49-8b39-c999bb5d531b");

                var courage = context.Users.Find("2617f522-237d-4b2c-b9f5-4b5c45fd2e26");

                var ginka = context.Users.Find("8d56b767-9fc0-45f9-9914-c0fe1e3e18e3");

                var tonko = context.Users.Find("cad32582-693b-40f8-bdd4-aa48cb73d62e");

                var toshko = context.Users.Find("cc20d976-b000-4474-b9dd-4569562e94bf");

                gencho.FollowedUsers.Add(courage);
                courage.Followers.Add(gencho);
                gencho.FollowedUsers.Add(ginka);
                ginka.Followers.Add(gencho);
                tonko.FollowedUsers.Add(toshko);
                toshko.Followers.Add(tonko);

                context.SaveChanges();
            }

            if (!context.Messages.Any())
            {
                SeedMessages(context);
            }

            if (!context.Tweets.Any())
            {
                SeedTweets(context);
            }
        }

        private void SeedTweets(TwitterContext context)
        {
            var gencho = context.Users.Find("1a626967-4c37-4a49-8b39-c999bb5d531b");

            var courage = context.Users.Find("2617f522-237d-4b2c-b9f5-4b5c45fd2e26");

            var ginka = context.Users.Find("8d56b767-9fc0-45f9-9914-c0fe1e3e18e3");

            var tonko = context.Users.Find("cad32582-693b-40f8-bdd4-aa48cb73d62e");

            var toshko = context.Users.Find("cc20d976-b000-4474-b9dd-4569562e94bf");

            var tweet1 = new Tweet()
            {
                Content = "#LOL!!! Titritititriti.",
                CreatedAt = new DateTime(2015, 10, 13),
                User = gencho,
                UserId = "1a626967-4c37-4a49-8b39-c999bb5d531b"
            };

            var tweet2 = new Tweet()
            {
                Content = "Kebaaaaaap!!",
                CreatedAt = new DateTime(2015, 10, 2),
                User = courage,
                UserId = "2617f522-237d-4b2c-b9f5-4b5c45fd2e26"
            };

            var tweet3 = new Tweet()
            {
                Content = "Каква победа само снощи!",
                CreatedAt = new DateTime(2015, 10, 1),
                User = ginka,
                UserId = "8d56b767-9fc0-45f9-9914-c0fe1e3e18e3"
            };

            var tweet4 = new Tweet()
            {
                Content = "Amazing shoes!!",
                CreatedAt = new DateTime(2015, 10, 4),
                User = tonko,
                UserId = "cad32582-693b-40f8-bdd4-aa48cb73d62e"
            };

            var tweet5 = new Tweet()
            {
                Content = "What a beautiful day!",
                CreatedAt = new DateTime(2015, 10, 7),
                User = toshko,
                UserId = "cc20d976-b000-4474-b9dd-4569562e94bf"
            };

            var tweet6 = new Tweet()
            {
                Content = "Zo-zo-zo-zo magination!@!@!@",
                CreatedAt = new DateTime(2015, 10, 9),
                User = ginka,
                UserId = "8d56b767-9fc0-45f9-9914-c0fe1e3e18e3"
            };

            var tweet7 = new Tweet()
            {
                Content = "Where my bitches at!",
                CreatedAt = new DateTime(2015, 10, 12),
                User = courage,
                UserId = "2617f522-237d-4b2c-b9f5-4b5c45fd2e26"
            };

            var tweet8 = new Tweet()
            {
                Content = "Nananananananananananaananann!!!@!?",
                CreatedAt = new DateTime(2015, 10, 15),
                User = toshko,
                UserId = "cc20d976-b000-4474-b9dd-4569562e94bf"
            };

            var tweet9 = new Tweet()
            {
                Content = "Shake it!!!",
                CreatedAt = new DateTime(2015, 10, 14),
                User = tonko,
                UserId = "cad32582-693b-40f8-bdd4-aa48cb73d62e"
            };

            var tweet10 = new Tweet()
            {
                Content = "Nu nu da nu nu da...",
                CreatedAt = new DateTime(2015, 10, 13),
                User = ginka,
                UserId = "8d56b767-9fc0-45f9-9914-c0fe1e3e18e3"
            };

            var tweet11 = new Tweet()
            {
                Content = "Nu nu da nu nu da...",
                CreatedAt = new DateTime(2015, 10, 11),
                User = courage,
                UserId = "2617f522-237d-4b2c-b9f5-4b5c45fd2e26"
            };
        }

        private void SeedMessages(TwitterContext context)
        {
            var message = new Message()
            {
                Content = "Hello!",
                CreatedAt = DateTime.Now,
                SenderId = "1a626967-4c37-4a49-8b39-c999bb5d531b",
                ReceiverId = "1a626967-4c37-4a49-8b39-c999bb5d531b"
            };

            context.Messages.Add(message);
            context.SaveChanges();
        }

        private void SeedUsers(TwitterContext context)
        {
            var gencho = new User()
            {
                Id = "1a626967-4c37-4a49-8b39-c999bb5d531b",
                Email = "gen4o@gmail.com",
                PasswordHash = "ABUypgfE79XRhkSO9vI8PBn3pKqDP0XU78n+yC67KMxOD0qrZ+STxtSa90ZpaTBpeA==",
                UserName = "gen4o"
            };

            var courage = new User()
            {
                UserName = "courage",
                Id = "2617f522-237d-4b2c-b9f5-4b5c45fd2e26",
                Email = "courage@abv.bg",
                PasswordHash = "AF+HUnrqNSY7QEs/4dubNHIRrP732/zUHjAF400ZvN89IwNktM+xLP4CQGwyuSjXpw=="
            };

            var ginka = new User()
            {
                UserName = "ginka",
                Id = "8d56b767-9fc0-45f9-9914-c0fe1e3e18e3",
                Email = "ginka@abv.bg",
                PasswordHash = "ABPZB3yFZUGFxmhnwwAunAuvWUCIpH/GyeU122km6Rgfd8D9NjzitNb5ToJ9N3GlTg=="
            };

            var tonko = new User()
            {
                UserName = "tonko",
                Id = "cad32582-693b-40f8-bdd4-aa48cb73d62e",
                Email = "tonko@abv.bg",
                PasswordHash = "ABeaZdUAvg8CqYViwtnkBlpSfbxBG1T9GBZo3PRpfoCtfhmkjASNh5stabX2R/JRwQ=="
            };

            var toshko = new User()
            {
                UserName = "to6ko",
                Id = "cc20d976-b000-4474-b9dd-4569562e94bf",
                Email = "to6ko@abv.bg",
                PasswordHash = "AGZSo2eisBbQVF8mB0dKNfJJslpP/ODuQ1o0vGrKN+lWLYhCtd3iBYypxUsKEDsajw=="
            };

            var users = new User[] {ginka, toshko, tonko, courage, gencho};

            foreach (var user in users)
            {
                context.Users.Add(user);
            }

            context.SaveChanges();
        }
    }
}