namespace VantageTag.TicTacToe.Core.DTOs
{
    public class MoveAckDTO
    {
        public int Position { get; set; }
        public string PlayedSymbol { get; set; } = string.Empty;
        public string Winner { get; set; } = string.Empty;
    }
}
