using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieReviewsBackend.Hubs
{
    public class ChatHub : Hub
    {
        public void Announce(string AnnouncementIn)
        {
            Clients.All.Announce(AnnouncementIn);
        }
    }
}