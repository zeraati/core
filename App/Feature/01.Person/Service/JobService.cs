using App.Feature.Domain;

namespace App.Feature;

public sealed class JobService(IServiceScopeFactory factory, ILogger<JobService> logger) : BackgroundService, IHosted
{
    private readonly SemaphoreSlim _receiveLock = new(1, 1);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
                await Work(factory, stoppingToken);
            }
            catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested) { break; }
            catch (Exception exception) { logger.LogError(exception, "Error while polling updates"); }
        }
    }

    private async Task Work(IServiceScopeFactory factory, CancellationToken cancellation)
    {
        await _receiveLock.WaitAsync(cancellation);
        try
        {
            // service
            await using var scope = factory.CreateAsyncScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var person = await db.Set<Person>().OrderBy(x => x.Id).FirstOrDefaultAsync();
        }
        finally { _receiveLock.Release(); }
    }
}