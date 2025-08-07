namespace AdminLogApi.Src.Shared.Application.Configuration;

public static class CorsConfiguration
{
    public static IServiceCollection AddCorsConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AdminLogFront", policy =>
            {
                var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                if (environment == "Development" || environment == "Staging")
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                }
                else
                {
                    policy
                        .WithOrigins(
                            "https://admin-log-api.com.br"
                        )
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                }
            });
        });
        return services;
    }
}
