namespace Learn.Csharp.AsyncAwait.Console;

public class DemoCpuBoundProcessor
{
    public async Task<long> CalculateRandomNumbersAsync()
    {
        return await Task.Run(() =>
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            watch.Start();

            foreach (var i in Enumerable.Range(1, 10000000))
            {
                var random = new Random();
                var number = random.Next(1, 100);
            }

            watch.Stop();

            return watch.ElapsedMilliseconds;
        });
    }
}
