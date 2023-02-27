namespace VantageTag.TicTacToe.Core.Interfaces
{
    public interface IAuthService
    {
        /// <summary>
        /// Validate Login credentials and return JWT token
        /// Refresh Token function will no be implemented for this exercise
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<string> LoginAsync(string username, string password);
    }
}
