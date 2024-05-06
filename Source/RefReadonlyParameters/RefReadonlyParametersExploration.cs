// https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-12#ref-readonly-parameters

// ReSharper disable InconsistentNaming

namespace Core.Source.RefReadonlyParameters;

public class ByteRegistry
{
    // ReSharper disable once CollectionNeverQueried.Local
    private readonly HashSet<byte> storedBytes = [];

    // Discuss if 'ref readonly' is the equivalent of 'const ptr' parameter in C/C++?
    public void Register(ref readonly byte value)
    {
        // The following line will throw a compilation error since we passed 'value' as readonly.
        // value += 1;

        storedBytes.Add(value);
    }
}