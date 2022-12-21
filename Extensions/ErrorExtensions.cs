using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Treasures.Common.Responses;

namespace Treasures.Common.Extensions;

public static class ErrorExtensions {
    public static IServiceCollection AddErrorResponse<T>(this IServiceCollection services)
        where T : ApiBehaviorOptions {
        services.Configure<T>(options => {
                options.InvalidModelStateResponseFactory = actionCtx => {
                    var errors = actionCtx.ModelState
                        .Where(e => e.Value!.Errors.Count > 0)
                        .SelectMany(x => x.Value!.Errors)
                        .Select(x => x.ErrorMessage).ToArray();
                    var errorResponse = new ValidationErrorResponse { Errors = errors };
                    return new BadRequestObjectResult(errorResponse);
                };
            }
        );
        return services;
    }
}