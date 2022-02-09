using Serilog;

using Template.Worker;

#pragma warning disable CA1812

var host = Host.CreateDefaultBuilder(args)
    .ConfigureLogging((_, logging) =>
    {
        logging.ClearProviders();
    })
    .UseSerilog((hostingContext, loggerConfiguration) =>
    {
        loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration);
    })
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
