using VantageTag.TicTacToe.Core.DTOs;
using VantageTag.TicTacToe.Core.Entities;
using VantageTag.TicTacToe.Core.Interfaces;

namespace VantageTag.TicTacToe.Core.Services
{
    public class GameService : IGameService
    {
        private readonly IGenericRepository<Game> _gameRepository;
        private readonly IGenericRepository<GameRoom> _gameRoomRepository;
        private static readonly int[,] _winningCombinations = new int[8, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 1, 4, 7 }, { 2, 5, 8 }, { 3, 6, 9 }, { 1, 5, 9 }, { 7, 5, 3 } };

        public GameService(IGenericRepository<Game> gameRepository, IGenericRepository<GameRoom> gameRoomRepository)
        {
            _gameRepository = gameRepository;
            _gameRoomRepository = gameRoomRepository;
        }

        public async Task<List<Game>> GetGames()
        {
            return (await _gameRepository.GetAllAsync()).ToList();
        }

        public MoveAckDTO Move(PayerMoveDTO move)
        {
            if (move.MovesPlayed >= 3)
            {
                for (int i = 0; i < _winningCombinations.GetLength(0); i++)
                {
                    int matchCount = 0;
                    for (int j = 0; j < _winningCombinations.GetLength(1); j++)
                    {
                        if (_winningCombinations[i, j] == move.AllPositions[0] || _winningCombinations[i, j] == move.AllPositions[1] || _winningCombinations[i, j] == move.AllPositions[2] || (move.AllPositions.Count() == 4 && _winningCombinations[i, j] == move.AllPositions[3]) || (move.AllPositions.Count() == 5 && _winningCombinations[i, j] == move.AllPositions[4])) {
                            matchCount++;
                        }
                    }
                    if (matchCount == 3)
                    {
                        return new MoveAckDTO
                        {
                            Position = move.Position,
                            PlayedSymbol = move.PlayedSymbol,
                            Winner = $"Player '{move.PlayedSymbol}' won!!!"
                        };
                    }
                }
            }
            return new MoveAckDTO
            {
                Position = move.Position,
                PlayedSymbol = move.PlayedSymbol,
                Winner = ""
            };
        }

        public async Task<string> JoinRoomByIdAsync(int id)
        {
            var gameRoom = (await _gameRoomRepository.GetAllAsync()).Where(a => a.RoomId == id).FirstOrDefault();
            if (gameRoom == null)
            {
                var newRoom = new GameRoom
                {
                    RoomId = id,
                    Player1 = "O"
                };
                await _gameRoomRepository.InsertAsync(newRoom);
                await _gameRoomRepository.SaveAsync();
                return newRoom.Player1;
            }
            else
            {
                gameRoom.Player2 = "X";
                await _gameRoomRepository.Update(gameRoom);
                await _gameRoomRepository.SaveAsync();
                return gameRoom.Player2;
            }
        }
    }
}
