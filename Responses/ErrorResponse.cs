namespace Treasures.Common.Responses;

public class ErrorResponse {
    public int StatusCode { get; set; }
    public string? Message { get; set; }

    public ErrorResponse(int statusCode, string? message = null) {
        StatusCode = statusCode;
        Message = message ?? GetDefaultMessageForStatusCode(statusCode);
    }

    private static string? GetDefaultMessageForStatusCode(int statusCode) {
        return statusCode switch {
            400 => "Bad Request",
            401 => "Unauthorized Request",
            404 => "Resource not Found",
            500 => "Internal Server Error",
            _ => null
        };
    }
}