using HotChocolate;
using VantageTag.TicTacToe.Core.Entities;
using VantageTag.TicTacToe.Core.Interfaces;

namespace VantageTag.TicTacToe.Core.GraphQL
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<User>> GetUsers([Service] IGenericRepository<User> genericRepository) =>
            await genericRepository.GetAllAsync();

        public async Task<IQueryable<Game>> GetGames([Service] IGenericRepository<Game> genericRepository) =>
            await genericRepository.GetAllAsync();
    }
}
 