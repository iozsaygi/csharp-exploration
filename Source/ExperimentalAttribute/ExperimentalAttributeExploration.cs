// https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-12#experimental-attribute

namespace Core.Source.ExperimentalAttribute;

[System.Diagnostics.CodeAnalysis.Experimental("ExperimentalEntryRiskyForUsageId")]
public class ExperimentalEntryRiskyForUsage
{
}

public class ClientThatUsesOnlyRiskyFeatures
{
    public static void UseRiskyFeature()
    {
        // The following line throws compilation error since we marked the class with 'Experimental' attribute.
        // var experimentalEntryRiskyForUsage = new ExperimentalEntryRiskyForUsage();
    }
}