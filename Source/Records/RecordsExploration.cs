// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record

namespace Core.Source.Records;

// Allocated on heap, just like classes.
public record User
{
    public readonly byte Index;

    // ReSharper disable once ConvertToPrimaryConstructor
    public User(byte index)
    {
        Index = index;
    }
}

// Shorter version of the 'User' record. (Don't need 'class' keyword but putting it in any way)
public record class ShorterUser(byte Index);

// C# 10 also supports record structs.
public record struct ValueTypeRecordForUser(byte Index);

// Basic person definition as record.
public record Person(string Name, string Surname);

public record struct DataEntry(byte Sign, byte Index)
{
    public readonly byte Index = Index;
    public readonly byte Sign = Sign;
}

public static class RecordsExploration
{
    public static void ExecuteFromMain()
    {
        var firstPerson = new Person("İsmail", "Özsaygı");
        var secondPerson = new Person("İsmail", "Özsaygı");
        var thirdPerson = new Person("Anti", "Mage");

        // Will print 'true' since both records has the same properties.
        Console.WriteLine(firstPerson == secondPerson);

        // Will return 'false' because records are different in terms of properties.
        Console.WriteLine(firstPerson == thirdPerson);

        // Defining struct related records.
        var firstDataEntry = new DataEntry(0, 0);
        var secondDataEntry = new DataEntry(0, 0);
        var thirdDataEntry = new DataEntry(0, 1);

        // Will print 'true' because properties are same.
        Console.WriteLine(firstDataEntry == secondDataEntry);

        // Will print 'false' because properties are not same.
        Console.WriteLine(firstDataEntry == thirdDataEntry);
    }
}