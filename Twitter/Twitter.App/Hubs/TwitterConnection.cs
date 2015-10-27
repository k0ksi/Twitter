﻿using System.Configuration;
using System.IO;
using Microsoft.AspNet.SignalR;
using Stream = Tweetinvi.Stream;

namespace Twitter.App.Hubs
{
    public class TwitterConnection
    {
        private string _consumerKey = ConfigurationManager.AppSettings.Get("consumerKey");
        private string _consumerSecret = ConfigurationManager.AppSettings.Get("consumerSecret");
        private string _accessKey = ConfigurationManager.AppSettings.Get("accessToken");
        private string _accessToken = ConfigurationManager.AppSettings.Get("accessTokenSecret");

        private IHubContext _context = GlobalHost.ConnectionManager.GetHubContext<TweetsHub>();

        public TwitterConnection()
        {
            var filteredStream = Stream.CreateFilteredStream();

            filteredStream.MatchingTweetReceived += (sender, args) =>
            {
                _context.Clients.All.broadcast(args.Tweet.Text);
            };

            filteredStream.StartStreamMatchingAllConditions();
        }
    }
}