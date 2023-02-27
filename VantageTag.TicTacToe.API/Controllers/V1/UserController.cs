using Microsoft.AspNetCore.Mvc;
using VantageTag.TicTacToe.API.Extensions;
using VantageTag.TicTacToe.Core.Interfaces;

namespace VantageTag.TicTacToe.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(ApiResponse.GenerateResponse(true, users, null));
        }
    }
}
