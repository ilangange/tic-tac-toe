namespace VantageTag.TicTacToe.Core.DTOs
{
    public class PayerMoveDTO
    {
        public int RoomId { get; set; }
        public string PlayedSymbol { get; set; } = string.Empty;
        public int Position { get; set; }
        public int MovesPlayed { get; set; }
        public int[] AllPositions { get; set; } = new int[6];
    }
}
