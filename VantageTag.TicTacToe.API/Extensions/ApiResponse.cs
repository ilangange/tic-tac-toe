namespace VantageTag.TicTacToe.API.Extensions
{
    public class ApiResponse
    {
        public static object GenerateResponse(bool isSuccess, object data, List<string> errors)
        {
            return new
            {
                success = isSuccess,
                data = data,
                errors = errors
            };
        }
    }
}
