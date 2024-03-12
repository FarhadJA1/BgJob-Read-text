using B.Service.Services.Abstractions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace C.BgWorker.ServiceWorkers;
public class BackgroundWorkerService : BackgroundService
{
    private readonly ILogger _logger;
    private readonly IDataService _dataService;
    private readonly ISettingsService _settingsService;

    public BackgroundWorkerService(IDataService dataService, ISettingsService settingsService)
    {
        _dataService = dataService;
        _settingsService = settingsService;
    }

    public BackgroundWorkerService(ILogger logger)
    {
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            _logger.LogInformation("Start");
        }, cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            _logger.LogInformation("End");
        }, cancellationToken);
    }

    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        do
        {
            _logger.LogInformation("Working");

            var settings = await _settingsService.GetSettingsAsync();

            await _dataService.CheckDataAsync();

            await Task.Delay(TimeSpan.FromHours(settings.Data.CheckInterval), stoppingToken);
        }
        while (!stoppingToken.IsCancellationRequested);

    }
}
