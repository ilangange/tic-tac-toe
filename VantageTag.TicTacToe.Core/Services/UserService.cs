using VantageTag.TicTacToe.Core.Entities;
using VantageTag.TicTacToe.Core.Interfaces;

namespace VantageTag.TicTacToe.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userRepository;

        public UserService(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetUsers()
        {
            return (await _userRepository.GetAllAsync()).ToList();
        }
    }
}
