using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VantageTag.TicTacToe.API.Extensions;
using VantageTag.TicTacToe.Core.Contracts.Requests;
using VantageTag.TicTacToe.Core.Interfaces;

namespace VantageTag.TicTacToe.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [AllowAnonymous]
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                // Only access toke is generated for this exercise. Refresh token is not implemented
                var token = await _authService.LoginAsync(loginModel.Username, loginModel.Password);
                if (token != null)
                {
                    var response = ApiResponse.GenerateResponse(true, token, null);

                    return Ok(response);
                }
                else
                {
                    return Unauthorized();
                }
            }
            return BadRequest();
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            // This is not implemented for this excercise
            return Ok();
        }
    }
}
