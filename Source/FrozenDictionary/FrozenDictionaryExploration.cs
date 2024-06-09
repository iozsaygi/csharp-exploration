// https://learn.microsoft.com/en-us/dotnet/api/system.collections.frozen.frozendictionary-2?view=net-8.0

using System.Collections.Frozen;

namespace Core.Source.FrozenDictionary;

public static class FrozenDictionaryExploration
{
    public static void ExecuteFromMain()
    {
        // Create a basic dictionary first.
        var personsWithId = new Dictionary<byte, string>()
        {
            { 0, "First İsmail" },
            { 1, "Second İsmail" },
            { 2, "Third İsmail" },
            { 3, "Fourth İsmail" },
            { 4, "Fifth İsmail" }
        };

        // The following line is perfectly fine.
        // personsWithId.Add(14, "Randomized İsmail");

        // The following line is also perfectly fine.
        // personsWithId[3] = "Am I Fourth İsmail?";

        // Convert normal dictionary to frozen dictionary.
        // Frozen dictionaries are good for frequent look-ups, but they should not be created frequently.
        var frozenPersonsWithId = personsWithId.ToFrozenDictionary();

        // The following line is giving compilation error since the dictionary is frozen.
        // frozenPersonsWithId[3] = "Am I Fourth İsmail?";

        Console.WriteLine("Contains: " + frozenPersonsWithId.ContainsKey(3));
        Console.WriteLine("Count: " + frozenPersonsWithId.Count);
    }
}