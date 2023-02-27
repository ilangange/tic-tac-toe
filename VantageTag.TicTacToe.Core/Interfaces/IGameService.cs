using VantageTag.TicTacToe.Core.DTOs;
using VantageTag.TicTacToe.Core.Entities;

namespace VantageTag.TicTacToe.Core.Interfaces
{
    public interface IGameService
    {
        /// <summary>
        /// Get all the Games
        /// </summary>
        /// <returns></returns>
        public Task<List<Game>> GetGames();

        /// <summary>
        /// Player Makes a Move
        /// </summary>
        /// <param name="move"></param>
        /// <returns></returns>
        public MoveAckDTO Move(PayerMoveDTO move);

        /// <summary>
        /// Join Game Room by Id and return player's symbol
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<string> JoinRoomByIdAsync(int id);
    }
}
