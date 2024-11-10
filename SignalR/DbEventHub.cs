using API.Data;
using Microsoft.AspNetCore.SignalR;

namespace API.SignalR;

public class DbEventHub(IDbEventRepository dbEventRepository): Hub
{
    public override async Task OnConnectedAsync()
    {
        var dbEvents = await dbEventRepository.GetDbEventsAsync();

        await Clients.Caller.SendAsync("ReceiveAllDbEvents", dbEvents ); 
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        return base.OnDisconnectedAsync(exception);
    }


}
