using System.IdentityModel.Tokens.Jwt;
using VantageTag.TicTacToe.Core.Entities;
using VantageTag.TicTacToe.Core.Interfaces;
using VantageTag.TicTacToe.Core.Services;
using VantageTag.TicTacToe.Data.Repository;

namespace VantageTag.TicTacToe.API.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection RegisterCoreDependencies(this IServiceCollection services)
        {
            services.AddScoped<JwtSecurityTokenHandler, JwtSecurityTokenHandler>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
            services.AddScoped<IGenericRepository<Game>, GenericRepository<Game>>();
            services.AddScoped<IGenericRepository<GameRoom>, GenericRepository<GameRoom>>();

            return services;
        }
    }
}
