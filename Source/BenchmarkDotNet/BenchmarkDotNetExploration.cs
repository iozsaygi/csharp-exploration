using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Core.Source.BenchmarkDotNet;

// Class that will be the target for benchmarking operations.
public class BenchmarkTarget(int limit)
{
    // ReSharper disable once ReplaceWithPrimaryConstructorParameter
    // ReSharper disable once InconsistentNaming
    private readonly int limit = limit;

    // Basic method that merges the strings.
    [Benchmark]
    public string ExecuteBenchmarkForThis()
    {
        var mergedString = string.Empty;

        for (var i = 0; i < limit; i++)
        {
            mergedString = string.Concat(mergedString, i.ToString());
        }

        return mergedString;
    }
}

// Class to execute benchmarking on the target.
public static class BenchmarkDotNetExploration
{
    public static void ExecuteFromMain()
    {
        // ReSharper disable once UnusedVariable
        var summary = BenchmarkRunner.Run<BenchmarkTarget>();
    }
}