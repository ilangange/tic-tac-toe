using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using VantageTag.TicTacToe.API.Extensions;
using VantageTag.TicTacToe.API.SignalR;
using VantageTag.TicTacToe.Core.DTOs;
using VantageTag.TicTacToe.Core.Interfaces;

namespace VantageTag.TicTacToe.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class GameController : BaseController
    {
        private readonly IGameService _gameService;
        private readonly IHubContext<BroadcastHub> _gameHub;

        public GameController(IGameService gameService, IHubContext<BroadcastHub> gameHub)
        {
            _gameService = gameService;
            _gameHub = gameHub;
        }

        [HttpGet]
        public async Task<IActionResult> GetGames()
        {
            var games = await _gameService.GetGames();
            return Ok(ApiResponse.GenerateResponse(true, games, null));
        }

        [HttpPost("join-room/{id}")]
        public async Task<IActionResult> JoinRoom(int id)
        {
            var response = await _gameService.JoinRoomByIdAsync(id);
            await _gameHub.Clients.All.SendAsync("start-game");
            return Ok(ApiResponse.GenerateResponse(true, response, null));
        }

        [HttpPost("move")]
        public async Task<IActionResult> Move([FromBody] PayerMoveDTO move)
        {
            var response = _gameService.Move(move);
            await _gameHub.Clients.All.SendAsync("receive-move", response);
            return Ok();
        }
    }
}
