// https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sortedset-1?view=net-8.0

namespace Core.Source.SortedSet;

public static class SortedSetExploration
{
    private readonly struct DatabaseEntry(byte id) : IComparable<DatabaseEntry>
    {
        // ReSharper disable once MemberCanBePrivate.Local
        public readonly byte Id = id;

        public int CompareTo(DatabaseEntry other)
        {
            return Id.CompareTo(other.Id);
        }
    }

    public static void BasicExample()
    {
        var data = new SortedSet<byte>()
        {
            4, 3, 7, 2
        };


        foreach (var context in data)
        {
            Console.WriteLine($"Data Entry: {context}");
        }
    }

    public static void ExampleWithCustomType()
    {
        var databaseEntries = new SortedSet<DatabaseEntry>()
        {
            new(3),
            new(1),
            new(7),
            new(4)
        };
        
        foreach (var context in databaseEntries)
        {
            Console.WriteLine($"Database Entry: {context.Id}");
        }
    }
}