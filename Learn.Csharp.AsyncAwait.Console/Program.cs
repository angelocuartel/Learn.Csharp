using Learn.Csharp.AsyncAwait.Console;
using Microsoft.EntityFrameworkCore;

// See https://aka.ms/new-console-template for more information

var options = new DbContextOptionsBuilder<ApplicationDbContext>()
    .UseInMemoryDatabase("AppDb") // For demo; replace with .UseSqlServer(...) for real DB
    .Options;

var context = new ApplicationDbContext(options);
var repo = new ApplicationRepository(context);




//// Non-async usage
//repo.Add(new Application { Name = "SyncApp", CreatedAt = DateTime.UtcNow });

//var apps = repo.GetAll();

//Console.WriteLine($"Sync count: {apps.Count}");

//// Async usage
//await repo.AddAsync(new Application { Name = "AsyncApp", CreatedAt = DateTime.UtcNow });

//var asyncApps = await repo.GetAllAsync();

//Console.WriteLine($"Async count: {asyncApps.Count}");


//var result = await new DemoCpuBoundProcessor().CalculateRandomNumbersAsync();

//Console.WriteLine($"Calculated {result} random numbers.");

Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}, Is Thread Pool Thread: {Thread.CurrentThread.IsThreadPoolThread}");

var longProcessTask = new Task(() =>
{
    Thread.Sleep(5000);

    Console.WriteLine("long process completed");
});

longProcessTask.Start();
await longProcessTask;


Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}, Is Thread Pool Thread: {Thread.CurrentThread.IsThreadPoolThread}");

Console.WriteLine("main thread completed");

Console.ReadLine();