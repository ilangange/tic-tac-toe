using Microsoft.AspNetCore.SignalR;

namespace VantageTag.TicTacToe.API.SignalR
{
    public class BroadcastHub : Hub<IHubClient>
    {
        public string GetConnectionId() => Context.ConnectionId;
    }
}
