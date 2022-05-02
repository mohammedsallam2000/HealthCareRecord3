using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace UI.Hubs
{
    public class RealtimeHub:Hub
    {
        public override Task OnConnectedAsync()
        {
            Context.Items.Add(Context.UserIdentifier,Context.ConnectionId);
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            Context.Items.Remove(Context.UserIdentifier);
            return base.OnDisconnectedAsync(exception);
        }

    }
}
