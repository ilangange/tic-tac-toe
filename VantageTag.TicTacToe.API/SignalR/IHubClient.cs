namespace VantageTag.TicTacToe.API.SignalR
{
    public interface IHubClient
    {
        Task SendMessage();
    }
}
