using System.ComponentModel.DataAnnotations;

namespace VantageTag.TicTacToe.Core.Entities
{
    public class GameRoom
    {
        public int RoomId { get; set; }
        public string Player1 { get; set; } = string.Empty;
        public string Player2 { get; set; } = string.Empty;
        public string Winner { get; set; } = string.Empty;
    }
}
