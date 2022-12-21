using Treasures.Common.Responses;

namespace Treasures.Common.Helpers;

public class ApiException : ErrorResponse {
    public string? Details { get; set; }

    public ApiException(int code, string? msg = null, string? details = null) : base(code, msg) => Details = details;
}