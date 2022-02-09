namespace Template.Worker;

using Microsoft.Extensions.Hosting;

public class Worker : BackgroundService
{
    private ILogger<Worker> Log { get; }

    public Worker(ILogger<Worker> log)
    {
        Log = log;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            Log.LogInformation("Worker running at: {Time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);
        }
    }
}
