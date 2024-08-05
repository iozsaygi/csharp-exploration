// ReSharper disable ReplaceSliceWithRangeIndexer

using System.Diagnostics;

namespace Core.Source.Span;

public abstract class SpanExploration
{
    // Dummy type to work with spans.
    private readonly struct SpanEntry(byte id, byte value)
    {
        internal readonly byte Id = id;
        internal readonly byte Value = value;
    }

    public static void SlicingExistingArray()
    {
        // Construct a basic 'byte' array first.
        const byte maximumNumberOfData = 10;
        var data = new byte[maximumNumberOfData];

        for (byte i = 0; i < maximumNumberOfData; i++)
        {
            data[i] = i;
        }

        // Create Span from byte array.
        Span<byte> dataSpan = data;

        // We can also slice the Spans.
        // Normal Span: 0, 1, 2, 3, 4, 5, 6, 7, 8, 9
        // Sliced Span: 2, 3, 4
        var dataSpanSliced = dataSpan.Slice(2, 3);

        PrintSpan(dataSpan);
        PrintSpan(dataSpanSliced);
    }

    public static unsafe void WorkingWithStackAllocation()
    {
        // C# 7.2 supports 'stackalloc' for spans.
        var data = stackalloc byte[2];
        data[0] = 5;
        data[1] = 10;

        // Index out of range exception.
        data[2] = 15;
    }

    public static void WorkingWithStrings()
    {
        const string exampleSentence = "I am an example sentence.";

        // This creates a lot of allocations for GC to collect.
        var firstMessage = exampleSentence.Substring(0, 3);
        var secondMessage = exampleSentence.Substring(5, 8);
        var thirdMessage = exampleSentence.Substring(7, 12);

        // Instead let's use spans.
        // Create a read-only span from existing sentence string and slice it to receive first message.
        ReadOnlySpan<char> exampleSentenceAsSpan = exampleSentence;
        var firstMessageSpan = exampleSentenceAsSpan.Slice(0, 3);
    }

    public static void WorkingWithCustomType()
    {
        var dataEntries = new SpanEntry[5];

        Span<SpanEntry> dataEntriesAsSpan = dataEntries;
        var slicedEntries = dataEntriesAsSpan.Slice(0, 2);

        Console.WriteLine("Sliced custom span entry length: " + slicedEntries.Length);
    }

    public static ReadOnlySpan<char> GetStringBetween(byte start, byte end)
    {
        Debug.Assert(start < end && start != end);
        const string magicWord = "Amigos";
        Debug.Assert(start < magicWord.Length && end < magicWord.Length);
        ReadOnlySpan<char> magicWordAsSpan = magicWord;
        return magicWordAsSpan.Slice(start, end);
    }

    private static void PrintSpan<T>(Span<T> span) where T : IComparable
    {
        for (var i = 0; i < span.Length; i++)
        {
            Console.WriteLine($"The value at {i} in span is {span[i]}");
        }

        Console.WriteLine("------------------------------");
    }
}