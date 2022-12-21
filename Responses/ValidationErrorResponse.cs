namespace Treasures.Common.Responses;

public class ValidationErrorResponse: ErrorResponse {
    public IEnumerable<string>? Errors { get; set; }
    public ValidationErrorResponse() : base(400) { }
}