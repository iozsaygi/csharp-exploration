namespace Core.Source.Async;

public class AsyncWorker
{
    public void ExecuteFromMain()
    {
        // WaitForSecondAsync();
        CrashApplicationAfterSecondAsync();
    }

    private async void WaitForSecondAsync()
    {
        await Task.Delay(1000);
        Console.WriteLine("Worked waited for a second");
    }

    private async void CrashApplicationAfterSecondAsync()
    {
        // Declare a null instance of 'async worker'.
        var asyncWorker = default(AsyncWorker);

        await Task.Delay(1000);

        // Try to operate on null instance to crash application.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        asyncWorker.WaitForSecondAsync();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }
}