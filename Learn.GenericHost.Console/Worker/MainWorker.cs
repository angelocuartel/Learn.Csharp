using Learn.GenericHost.Console.Service;
using Microsoft.Extensions.Hosting;

namespace Learn.GenericHost.Console.Worker;

public class MainWorker : BackgroundService
{

    private readonly IApplicationService _applicationService;

    public MainWorker(IApplicationService applicationService)
    => _applicationService = applicationService;
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        System.Console.WriteLine("MainWorker is starting.");

        if (_applicationService.ApplicationIsValid())
        {
            System.Console.WriteLine("Application is valid.");
        }
        else
        {
            System.Console.WriteLine("Application is not valid.");
        }

        return Task.CompletedTask;
    }
}
