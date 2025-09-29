using Learn.GenericHost.Console.Service;
using Learn.GenericHost.Console.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Program
{
    public static async Task Main(string[] args)
    {
        using var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddSingleton<IApplicationService, ApplicationService>();
                services.AddHostedService<MainWorker>();
            })
            .Build();

        await host.RunAsync();
    }
}