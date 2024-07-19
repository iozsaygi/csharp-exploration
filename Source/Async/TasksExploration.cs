namespace Core.Source.Async;

public class TaskWorker
{
    public async void ExecuteFromMain()
    {
        var firstTask = WorkAsync();
        var secondTask = AnotherWorkAsync();

        await Task.WhenAll(firstTask, secondTask);
    }

    private async Task<int> WorkAsync()
    {
        var totalWaitedMilliSeconds = 0;
        const int waitDuration = 1000;

        await WaitForGivenSeconds(waitDuration);
        totalWaitedMilliSeconds += waitDuration;
        await WaitForGivenSeconds(waitDuration);
        totalWaitedMilliSeconds += waitDuration;

        return totalWaitedMilliSeconds;
    }

    private async Task<SceneEntityData> AnotherWorkAsync()
    {
        await WaitForGivenSeconds(1000);
        var sceneEntityData = new SceneEntityData(await ProduceRandomNumberAsync());
        return sceneEntityData;
    }

    private async Task WaitForGivenSeconds(int milliSeconds)
    {
        await Task.Delay(milliSeconds);
    }

    private async Task<int> ProduceRandomNumberAsync()
    {
        var random = new Random();
        await Task.Delay(1000);
        return random.Next(1, 1000);
    }

    public readonly struct SceneEntityData(int numberOfActiveEntities)
    {
        public readonly int NumberOfActiveEntities = numberOfActiveEntities;
    }
}