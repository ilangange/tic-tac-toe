using System.ComponentModel.DataAnnotations;

namespace VantageTag.TicTacToe.Core.Contracts.Requests
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
