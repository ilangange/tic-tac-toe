using Microsoft.EntityFrameworkCore;
using VantageTag.TicTacToe.Core.Entities;

namespace VantageTag.TicTacToe.Infrastructure.Persistence
{
    public class VantageTagDBContext : DbContext
    {
        public VantageTagDBContext(DbContextOptions<VantageTagDBContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameRoom> GameRooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<Game>()
                .HasKey(u => u.GameId);

            modelBuilder.Entity<GameRoom>()
                .HasKey(u => u.RoomId);

            modelBuilder.Entity<Game>().HasData(
                new Game
                {
                    GameId = 1,
                    Player1 = "John",
                    Player2 = "Steve",
                    WinningPlayer = "John",
                    GameSummary = "John won the game"
                },
                new Game
                {
                    GameId = 2,
                    Player1 = "John",
                    Player2 = "Jason",
                    WinningPlayer = "Jason",
                    GameSummary = "Jason won the game"
                },
                new Game
                {
                    GameId = 3,
                    Player1 = "Henry",
                    Player2 = "Steve",
                },
                new Game
                {
                    GameId = 4,
                    Player1 = "John",
                    Player2 = "Henry",
                },
                new Game
                {
                    GameId = 5,
                    Player1 = "John",
                    Player2 = "Mathew",
                    WinningPlayer = "Mathew",
                    GameSummary = "Mathew won the game"
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Name = "John"
                },
                new User
                {
                    UserId = 2,
                    Name = "Henry"
                },
                new User
                {
                    UserId = 3,
                    Name = "Mathew"
                },
                new User
                {
                    UserId = 5,
                    Name = "Steve"
                }
            );
        }
    }
}
