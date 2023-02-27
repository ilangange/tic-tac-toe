using System.ComponentModel.DataAnnotations;

namespace VantageTag.TicTacToe.Core.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Game> Games { get; set; } = new List<Game>();
    }
}
