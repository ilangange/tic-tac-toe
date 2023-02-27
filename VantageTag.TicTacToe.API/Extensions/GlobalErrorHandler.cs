using System.Net;
using System.Text.Json;

namespace VantageTag.TicTacToe.API.Extensions
{
    public class GlobalErrorHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public GlobalErrorHandler(RequestDelegate next, ILogger<GlobalErrorHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, @ex.Message);

                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var errorResponse = new
                {
                    message = "Something went wrong. please contact administrator",
                    statusCode = response.StatusCode
                };

                var errorJson = JsonSerializer.Serialize(errorResponse);

                await response.WriteAsync(errorJson);
            }
        }
    }
}
