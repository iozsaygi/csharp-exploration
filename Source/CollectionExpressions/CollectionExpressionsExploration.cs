// https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-12#collection-expressions

// ReSharper disable UnusedVariable

namespace Core.Source.CollectionExpressions;

public class CollectionPlayground
{
    // ReSharper disable once UnusedMember.Global
    public static void Example()
    {
        // Creating a byte array with the initializer.
        // ReSharper disable once UseCollectionExpression
        byte[] message = { 0, 15, 22, 33 };

        // Define another byte array by using collection expressions.
        // Note that we can't use 'var' keyword here.
        byte[] receivedPackage = [4, 5, 6, 7];
    }
}