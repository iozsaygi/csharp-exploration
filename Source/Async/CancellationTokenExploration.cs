namespace Core.Source.Async;

public class Cancellable
{
    public async Task ExecuteFromMain()
    {
        // Allocate cancellation token and source.
        var cancellationTokenSource = new CancellationTokenSource();
        var cancellationToken = cancellationTokenSource.Token;

        // Start running the task with interval on another thread.
        var task = Task.Run(async () => { await WorkerWithInterval(cancellationToken); }, cancellationToken);

        // Wait a few seconds and then cancel the task.
        await Task.Delay(5000, cancellationToken);
        await cancellationTokenSource.CancelAsync();

        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Cancellation requested for a task with interval!");
        }
    }

#pragma warning disable CA1822
    // ReSharper disable once MemberCanBeMadeStatic.Local
    private async Task WorkerWithInterval(CancellationToken cancellationToken)
#pragma warning restore CA1822
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            await Task.Delay(1000, cancellationToken);
            Console.WriteLine("I am task with an interval, I am still running.");
        }
    }
}