using System.Configuration;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Twitter.App.Hubs
{
    [HubName("tweets")]
    public class TweetsHub : Hub
    {
        
    }
}