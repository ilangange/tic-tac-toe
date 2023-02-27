using System.ComponentModel.DataAnnotations;

namespace VantageTag.TicTacToe.Core.Entities
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        public string Player1 { get; set; } = string.Empty;
        public string Player2 { get; set; } = string.Empty;
        public string WinningPlayer { get; set; } = string.Empty;
        public string GameSummary { get; set; } = string.Empty;
    }
}
