using LoginWithStatus.Model;
using Microsoft.AspNetCore.SignalR;

namespace LoginWithStatus.Hubs
{
    public class NotificationHub :Hub
    {
        public override async Task OnConnectedAsync()
        {
            ConnectedUser.users.Add()
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
