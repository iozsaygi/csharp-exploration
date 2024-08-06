// https://learn.microsoft.com/en-us/dotnet/api/system.collections.sortedlist?view=net-8.0

namespace Core.Source.SortedList;

public static class SortedListExploration
{
    // Random dummy type to use in sorted list.
    private readonly struct Credit(byte context) : IComparable<Credit>
    {
        public readonly byte Context = context;

        public int CompareTo(Credit other)
        {
            return Context.CompareTo(other.Context);
        }
    }

    // Another dummy type for sorted list, 'length' property of 'Data' field will be used for comparison.
    private readonly struct ScanResultBuffer(byte[] data) : IComparable<ScanResultBuffer>
    {
        public readonly byte[] Data = data;

        public int CompareTo(ScanResultBuffer other)
        {
            return Data.Length.CompareTo(other.Data.Length);
        }
    }

    public static void BasicExample()
    {
        // Persons sorted list that works with ID and Name pair.
        var persons = new SortedList<byte, string>
        {
            // Adding new persons with unsorted order.
            { 3, "Saul" },
            { 5, "Goodman" },
            { 0, "Better" },
            { 2, "Call" },
            { 1, "Gustavo" },
            { 4, "Salamanca" }
        };

        // Now print the sorted list. It will be sorted by the keys basically.
        for (var i = 0; i < persons.Count; i++)
        {
            Console.WriteLine($"Person with ID {persons.GetKeyAtIndex(i)} is {persons.GetValueAtIndex(i)}");
        }
    }

    public static void ExampleWithCustomType()
    {
        var credits = new SortedList<Credit, string>()
        {
            { new Credit(3), "İsmail" },
            { new Credit(1), "İsmael" },
            { new Credit(0), "Ismael" }
        };

        // List is sorted based on how we implement the 'IComparable' interface in 'Credit' struct.
        for (var i = 0; i < credits.Count; i++)
        {
            Console.WriteLine($"Person with credit {credits.GetKeyAtIndex(i).Context} is {credits.GetValueAtIndex(i)}");
        }
    }

    public static void ExampleWithCustomTypeByProperty()
    {
        var scanResults = new SortedList<ScanResultBuffer, string>()
        {
            { new ScanResultBuffer(new byte[4]), "İsmail" },
            { new ScanResultBuffer(new byte[1]), "İsmael" },
            { new ScanResultBuffer(new byte[7]), "Ismael" },
        };

        // List is sorted based on how we implement the 'IComparable' interface in 'ScanResultBuffer' struct.
        // It will use the 'length' of 'Data' property.
        for (var i = 0; i < scanResults.Count; i++)
        {
            Console.WriteLine(
                $"Person with scan result {scanResults.GetKeyAtIndex(i).Data.Length} is {scanResults.GetValueAtIndex(i)}");
        }
    }
}