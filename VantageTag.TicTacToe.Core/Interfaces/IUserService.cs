using VantageTag.TicTacToe.Core.Entities;

namespace VantageTag.TicTacToe.Core.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Get all the users
        /// </summary>
        /// <returns></returns>
        public Task<List<User>> GetUsers();
    }
}
