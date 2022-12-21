using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Treasures.Common.Helpers;

namespace Treasures.Common.Extensions;

public static class SwaggerExtensions {
    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, string key, string issuer) {
        services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
        ).AddJwtBearer(opt => {
                opt.Events = new JwtBearerEvents {
                    OnChallenge = context => {
                        context.Response.OnStarting(async () => {
                            // Write to the response in any way you wish
                            await context.Response.WriteAsJsonAsync(new ProblemDetails {
                                Title = "Unauthorized request", Detail = "Please check your credentials and try again",
                                Status = 401
                            });
                        });
                        return Task.CompletedTask;
                    }
                };
                opt.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuer = true, ValidateAudience = false, ValidateLifetime = true,
                    ValidateIssuerSigningKey = true, ValidIssuer = issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                };
            }
        );
        return services;
    }

    public static IServiceCollection AddSwaggerAuthenticated(this IServiceCollection svs, string title, string vs) {
        svs.AddSwaggerGen(c => {
                c.OrderActionsBy(apiDesc => $"{apiDesc.RelativePath}");
                c.SwaggerDoc(vs, new OpenApiInfo { Title = title, Version = vs });
                c.OperationFilter<OperationFilter>();

                var securityScheme = new OpenApiSecurityScheme {
                    Description = "JWT Auth Bearer Scheme", Name = "Authorization", In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http, Scheme = "bearer",
                    Reference = new OpenApiReference { Id = "bearer", Type = ReferenceType.SecurityScheme }
                };

                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
            }
        );
        return svs;
    }

    public static IApplicationBuilder UseSavanaSwaggerDoc(this IApplicationBuilder app, string title) {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: title));
        return app;
    }
}