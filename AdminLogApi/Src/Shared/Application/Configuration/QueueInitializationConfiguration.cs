using AdminLogApi.Src.Shared.Infrastructure.Queue.Init;

namespace AdminLogApi.Src.Shared.Application.Configuration;

public static class QueueInitializationExtension
{
    public static async Task InitializeQueue(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var initQueue = scope.ServiceProvider.GetRequiredService<InitQueue>();
        await initQueue.InitializeAsync();
    }
}
