// https://learn.microsoft.com/en-us/dotnet/api/system.collections.frozen.frozenset-1?view=net-8.0

using System.Collections.Frozen;

namespace Core.Source.FrozenSet;

// ReSharper disable once ClassNeverInstantiated.Global
public class FrozenSetExploration
{
    // ReSharper disable once UnusedMember.Global
    public static void ExecuteFromMain()
    {
        // Create a basic 'byte' array.
        const byte bufferSize = 10;
        var data = new byte[bufferSize];

        for (byte i = 0; i < bufferSize; i++)
        {
            data[i] = i;
        }

        // Convert the byte array to frozen set.
        var frozenData = data.ToFrozenSet();

        // Try to get value from it.
        frozenData.TryGetValue(3, out var secondFrozenData);
        Console.WriteLine("Second frozen data: " + secondFrozenData);

        // Try to see that if 13 is available in the set. (Will result with 'False' since 13 is not available in the set)
        Console.WriteLine("Contains: " + frozenData.Contains(13));

        // Create another frozen set from existing one.
        var anotherFrozenData = frozenData.ToFrozenSet();

        // Check if the sets are equal. (Will result with 'True' since the elements are the same)
        Console.WriteLine("Are sets equal: " + frozenData.SetEquals(anotherFrozenData));
    }
}