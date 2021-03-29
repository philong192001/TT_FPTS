using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_Signlr.Hubs
{
    public class PollHub : Hub
    {
        public async Task SendMessagePoll(string user, string message, string myProjectId, string myProjectVal)
        {
            await Clients.All.SendAsync("ReceiveMessagePoll", user, message, myProjectId, myProjectVal);
        }
    }
}
