using AdminLogApi.Src.Shared.Application.Middlewares;
using AdminLogApi.Src.Shared.Infrastructure.Logger;
using AdminLogApi.Src.Shared.Infrastructure.Logger.Adapters;
using AdminLogApi.Src.Shared.Infrastructure.Queue;
using AdminLogApi.Src.Shared.Infrastructure.Queue.Adapters;
using AdminLogApi.Src.Shared.Infrastructure.Queue.Init;
using AdminLogApi.Src.Shared.Infrastructure.Security.Hasher;
using AdminLogApi.Src.Shared.Infrastructure.Security.Hasher.Adapters;
using AdminLogApi.Src.Shared.Infrastructure.Security.Token;
using AdminLogApi.Src.Shared.Infrastructure.Security.Token.Adapters;

namespace AdminLogApi.Src.Shared.Infrastructure.DI;

public static class GlobalDependecyInjection
{
    public static IServiceCollection AddSharedModuleServices(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
        });
        services.AddVersionedApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });
        services.AddSingleton<IQueueService, RabbitMqAdapter>();
        services.AddSingleton<InitQueue>();
        services.AddSingleton<ILoggerService, SerilogLoggerAdapter>();
        services.AddSingleton<IHasher, BcryptHasherAdapter>();
        services.AddSingleton<ITokenService, JwtTokenServiceAdapter>();
        services.AddTransient<RequestLoggingMiddleware>();
        return services;
    }
}
