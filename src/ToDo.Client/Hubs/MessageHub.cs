using Microsoft.AspNetCore.SignalR;

namespace ToDo.Client.Hubs;

public class MessageHub : Hub
{
    public async Task RefreshMessages(string message)
    {
        await Clients.All.SendAsync("refreshMessages", message);
    }
}
